import { Page } from './../../models/Pagination';
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
      numero: {
        cpf: 'CPF em formato inválido',
      },
      endereco: {
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

    cpf: this.fb.group({
      numero: ['', [NgBrazilValidators.cpf]]
    }),

    email: this.fb.group({
      endereco: ['', [Validators.email]],
    }),

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

      this.cliente.endereco.cep = StringUtils.somenteNumeros(this.cliente.endereco.cep);
      this.cliente.cpf.numero = StringUtils.somenteNumeros(this.cliente.cpf.numero);
      this.cliente.telefone = StringUtils.somenteNumeros(this.cliente.telefone);

      this.clienteService.novoCliente(this.cliente)
        .subscribe({
          next: (sucesso) => { this.processarSucesso(sucesso) },
          error: (falha) => { this.processarFalha(falha) }
        });

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
    if(fail.status === 400)
      this.errors = fail.error.errors.Mensagens;
    else
     this.errors = fail.error.errors;
    this.toastr.error('Ocorreu um erro!', 'Opa :(',{
      progressAnimation: 'increasing',
      progressBar: true
    });
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
