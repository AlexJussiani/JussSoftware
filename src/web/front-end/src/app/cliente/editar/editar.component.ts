import { NgBrazilValidators } from 'ng-brazil';
import { Component, OnInit, ViewChildren, ElementRef, TemplateRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControlName, AbstractControl } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';

import { Observable, fromEvent, merge } from 'rxjs';


import { utilsBr } from 'js-brasil';
import { ToastrService } from 'ngx-toastr';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { NgxSpinnerService } from 'ngx-spinner';

import { ValidationMessages, GenericValidator, DisplayMessage } from 'src/app/utils/generic-form-validation';
import { Cliente } from '../models/cliente';
import { CepConsulta, Endereco } from '../models/endereco';
import { ClienteService } from '../services/cliente.service';
import { StringUtils } from 'src/app/utils/string-utils';

@Component({
  selector: 'app-editar',
  templateUrl: './editar.component.html'
})
export class EditarComponent implements OnInit {

  @ViewChildren(FormControlName, { read: ElementRef }) formInputElements: ElementRef[];

  errors: any[] = [];
  errorsEndereco: any[] = [];
  clienteForm: FormGroup;
  enderecoForm: FormGroup;

  cliente: Cliente = new Cliente();
  endereco: Endereco = new Endereco();

  validationMessages: ValidationMessages;
  genericValidator: GenericValidator;
  displayMessage: DisplayMessage = {};
  textoCPF: string = '';

  MASKS = utilsBr.MASKS;
  formResult: string = '';

  mudancasNaoSalvas: boolean;

  constructor(private fb: FormBuilder,
    private clienteService: ClienteService,
    private router: Router,
    private toastr: ToastrService,
    private route: ActivatedRoute,
    private modalService: NgbModal,
    private spinner: NgxSpinnerService) {

    this.validationMessages = {
      nome: {
        required: 'Informe o Nome',
      },
      telefone: {
        telefone: 'Telefone em formato inválido',
      },
      numero: {
        cpf: 'Telefone em formato inválido',
      }
    };

    this.genericValidator = new GenericValidator(this.validationMessages);

    this.cliente = this.route.snapshot.data['cliente'];
  }

  ngOnInit() {
    this.spinner.show();

    this.clienteForm = this.fb.group({
      nome: ['', [Validators.required]],

      cpf: this.fb.group({
        numero: ['', [NgBrazilValidators.cpf]]
      }),

      email: this.fb.group({
        endereco: ['', [Validators.email]],
      }),

      telefone: ['', [NgBrazilValidators.telefone]],
    });

    this.enderecoForm = this.fb.group({
      logradouro: [''],
      numero: [''],
      complemento: [''],
      bairro: [''],
      cep: ['', [NgBrazilValidators.cep]],
      cidade: [''],
      estado: [''],
      clienteId: ''
    });

    this.preencherForm();

    setTimeout(() => {
      this.spinner.hide();
    }, 1000);

  }

  preencherForm() {

    this.clienteForm.patchValue({
      id: this.cliente.id,
      nome: this.cliente.nome,
      cpf:{
        numero: this.cliente.cpf?.numero
      },
      email:{
        endereco: this.cliente.email?.endereco,
      },
      telefone: this.cliente?.telefone
    });
    this.enderecoForm.patchValue({
      id: this.cliente.endereco?.id,
      logradouro: this.cliente.endereco?.logradouro,
      numero: this.cliente.endereco?.numero,
      complemento: this.cliente.endereco?.complemento,
      bairro: this.cliente.endereco?.bairro,
      cep: this.cliente.endereco?.cep,
      cidade: this.cliente.endereco?.cidade,
      estado: this.cliente.endereco?.estado
    });
  }

  ngAfterViewInit() {
    let controlBlurs: Observable<any>[] = this.formInputElements
      .map((formControl: ElementRef) => fromEvent(formControl.nativeElement, 'blur'));

    merge(...controlBlurs).subscribe(() => {
      this.displayMessage = this.genericValidator.processarMensagens(this.clienteForm);
      this.mudancasNaoSalvas = true;
    });
  }

  editarCliente() {
    if (this.clienteForm.dirty && this.clienteForm.valid) {

      this.cliente = Object.assign({}, this.cliente, this.clienteForm.value);

      this.clienteService.atualizarCliente(this.cliente)
        .subscribe(
          sucesso => { this.processarSucesso(sucesso) },
          falha => { this.processarFalha(falha) }
        );

      this.mudancasNaoSalvas = false;
    }
  }

  processarSucesso(response: any) {
    this.errors = [];

    let toast = this.toastr.success('Cliente atualizado com sucesso!', 'Sucesso!');
    if (toast) {
      toast.onHidden.subscribe(() => {
        this.router.navigate(['/clientes/listar-todos']);
      });
    }
  }

  processarFalha(fail: any) {
    this.errors = fail.error.errors;
    this.toastr.error('Ocorreu um erro!', 'Opa :(');
  }

  buscarCep(cep: any) {

    cep = StringUtils.somenteNumeros(cep.value);
    if (cep.length < 8) return;

    this.clienteService.consultaCep(cep)
      .subscribe(
        cepRetorno => this.preencherEnderecoConsulta(cepRetorno),
        erro => this.errors.push(erro));
  }

  preencherEnderecoConsulta(cepConsulta: CepConsulta) {

    this.enderecoForm.patchValue({
      logradouro: cepConsulta.logradouro,
      bairro: cepConsulta.bairro,
      cep: cepConsulta.cep,
      cidade: cepConsulta.localidade,
      estado: cepConsulta.uf
    });
  }


  abrirModal(content) {
    this.modalService.open(content);
  }
  editarEndereco(){

  }
}
