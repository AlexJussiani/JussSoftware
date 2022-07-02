import { Component, OnInit, ViewChildren, ElementRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControlName, AbstractControl } from '@angular/forms';
import { Router } from '@angular/router';

import { Observable, fromEvent, merge } from 'rxjs';
import { MASKS, NgBrazilValidators } from 'ng-brazil';
import { utilsBr } from 'js-brasil';
import { ToastrService } from 'ngx-toastr';

import { ValidationMessages, GenericValidator, DisplayMessage } from 'src/app/utils/generic-form-validation';
import { Cliente } from '../models/cliente';
import { ClienteService } from '../services/cliente.service';
import { CepConsulta } from '../models/endereco';
import { StringUtils } from 'src/app/utils/string-utils';

@Component({
  selector: 'app-novo',
  templateUrl: './novo.component.html'
})
export class NovoComponent implements OnInit {

  @ViewChildren(FormControlName, { read: ElementRef }) formInputElements: ElementRef[];

  errors: any[] = [];
  clienteForm: FormGroup;
  cliente: Cliente = new Cliente();

  validationMessages: ValidationMessages;
  genericValidator: GenericValidator;
  displayMessage: DisplayMessage = {};

  MASKS = utilsBr.MASKS;
  formResult: string = '';

  mudancasNaoSalvas: boolean;

  constructor(private fb: FormBuilder,
    private clienteService: ClienteService,
    private router: Router,
    private toastr: ToastrService) {

    this.validationMessages = {
      nome: {
        required: 'Informe o Nome',
       },
      cpf: {
        cpf: 'CPF em formato inválido',
      },
      email: {
        email: 'Email em formato inválido',
      },
      telefone: {
        telefone: 'Telefone em formato inválido',
      },
      cep: {
        cep: 'logradouro informado inválido',
      }
    };

    this.genericValidator = new GenericValidator(this.validationMessages);
  }

  ngOnInit() {

    this.clienteForm = this.fb.group({
      nome: ['', [Validators.required]],
      cpf: ['', [Validators.required, NgBrazilValidators.cpf]],
      email: ['', [Validators.required, Validators.email]],
      telefone: ['', [NgBrazilValidators.telefone]],

     endereco: this.fb.group({
        logradouro: [''],
        numero: [''],
        complemento: [''],
        bairro: [''],
        cep: ['', [NgBrazilValidators.cep]],
        cidade: [''],
        estado: ['']
      })
    });
  }

  ngAfterViewInit(): void {
    this.configurarElementosValidacao();
  }

  configurarElementosValidacao() {
    let controlBlurs: Observable<any>[] = this.formInputElements
      .map((formControl: ElementRef) => fromEvent(formControl.nativeElement, 'blur'));

    merge(...controlBlurs).subscribe(() => {
      this.validarFormulario();
    });
  }

  validarFormulario() {
    this.displayMessage = this.genericValidator.processarMensagens(this.clienteForm);
    this.mudancasNaoSalvas = true;
  }

   adicionarCliente() {
    if (this.clienteForm.dirty && this.clienteForm.valid) {
      this.cliente = Object.assign({}, this.cliente, this.clienteForm.value);
      this.formResult = JSON.stringify(this.cliente);

      this.clienteService.novoCliente(this.cliente)
        .subscribe(
          sucesso => { this.processarSucesso(sucesso) },
          falha => { this.processarFalha(falha) }
        );

      this.mudancasNaoSalvas = false;
    }
  }

  processarSucesso(response: any) {
    this.clienteForm.reset();
    this.errors = [];

    let toast = this.toastr.success('Cliente cadastrado com sucesso!', 'Sucesso!');
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

  buscarCep(cep: any){
  cep = StringUtils.somenteNumeros(cep.value);
  if(cep.length < 8) return;

    this.clienteService.consultaCep(cep)
    .subscribe({
      next: (cepRetorno) => this.preencherEnderecoConsulta(cepRetorno),
      error: (erro) => this.errors.push(erro)
    });
  }

  preencherEnderecoConsulta(cepConsulta: CepConsulta){
    this.clienteForm.patchValue({
      endereco: {
        logradouro: cepConsulta.logradouro,
        bairro: cepConsulta.bairro,
        cep: cepConsulta.cep,
        cidade: cepConsulta.localidade,
        estado: cepConsulta.uf
      }
    });
  }
}
