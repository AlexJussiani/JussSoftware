import { Component, OnInit, ViewChildren, ElementRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControlName, AbstractControl } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';

import { Observable, fromEvent, merge } from 'rxjs';

import { ToastrService } from 'ngx-toastr';

import { ValidationMessages, GenericValidator, DisplayMessage } from 'src/app/utils/generic-form-validation';
import { Cliente } from '../models/cliente';
import { Endereco } from '../models/endereco';
import { ClienteService } from '../services/cliente.service';

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

  formResult: string = '';

  mudancasNaoSalvas: boolean;

  constructor(private fb: FormBuilder,
    private clienteService: ClienteService,
    private router: Router,
    private toastr: ToastrService,
    private route: ActivatedRoute) {

    this.validationMessages = {
      nome: {
        required: 'Informe o Nome',
      }
    };

    this.genericValidator = new GenericValidator(this.validationMessages);

    this.clienteService.obterPorId(route.params['id'])
      .subscribe(cliente => this.cliente = cliente);
  }

  ngOnInit() {

    this.clienteForm = this.fb.group({
      id: '',
      nome: ['', [Validators.required]],
      cpf: '',
      email: '',
      telefone: ''
    });

    this.enderecoForm = this.fb.group({
      id: '',
      logradouro: '',
      numero: '',
      complemento:  '',
      bairro:  '',
      cep:  '',
      cidade: '',
      estado:  '',
      clienteId: ''
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
}
