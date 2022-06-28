import { ContaService } from './../services/conta.service';
import { AfterViewInit, Component, ElementRef, OnInit, ViewChildren } from '@angular/core';
import { FormBuilder, FormControl, FormControlName, FormGroup, Validators } from '@angular/forms';
import { Usuario } from '../models/usuario';
import { DisplayMessage, GenericValidator, ValidationMessages } from 'src/app/utils/generic-form-validation';
import { CustomValidators } from '@narik/custom-validators';
import { fromEvent, merge, Observable } from 'rxjs';

@Component({
  selector: 'app-cadastro',
  templateUrl: './cadastro.component.html',
  styleUrls: []
})
export class CadastroComponent implements OnInit, AfterViewInit {

  @ViewChildren(FormControlName, { read: ElementRef }) formInputElements: ElementRef[];

  errors: any[] = []
  cadastroForm: FormGroup;
  usuario: Usuario;

  displayMessage: DisplayMessage = {};
  genericValidator: GenericValidator;
  validationMessages: ValidationMessages;

  constructor(private fb: FormBuilder,
    private contaService: ContaService) {
      this.validationMessages = {
        nome: {
          required: 'Informe o nome',
          rangeLength: 'O Nome deve possuir pelo menos 5 caracteres'
        },
        cpf:{
          required: 'Informe o CPF',
          cpf: 'CPF inválido'
        },
        email: {
          required: 'Informe o e-mail',
          email: 'Email inválido'
        },
        senha: {
          required: 'Informe a senha',
          rangeLength: 'A senha deve possuir entre 6 e 15 caracteres'
        },
        senhaConfirmacao: {
          required: 'Informe a senha novamente',
          rangeLength: 'A senha deve possuir entre 6 e 15 caracteres',
          equalTo: 'As senhas não conferem'
        }
      };

      this.genericValidator = new GenericValidator(this.validationMessages);
  }

  ngOnInit(): void {

    let pass = new FormControl('', [Validators.required, CustomValidators.rangeLength([6, 15])]);
    let passConfirm = new FormControl('', [Validators.required, CustomValidators.rangeLength([6, 15]), CustomValidators.equalTo(pass)]);

    this.cadastroForm = this.fb.group({
      nome: ['', Validators.required],
      cpf: ['', [Validators.required]],
      email: ['',[Validators.required, Validators.email]],
      senha: pass,
      senhaConfirmacao: passConfirm,
    });
  }

  ngAfterViewInit(): void {

    let controlBlurs: Observable<any>[] = this.formInputElements
      .map((formControl: ElementRef) => fromEvent(formControl.nativeElement, 'blur'));

      merge(...controlBlurs).subscribe(() => {
        this.displayMessage = this.genericValidator.processarMensagens(this.cadastroForm);
    });
  }

  adicionarConta(){
    if(this.cadastroForm.dirty && this.cadastroForm.valid){
      this.usuario = Object.assign({}, this.usuario, this.cadastroForm.value);

      this.contaService.registrarUsuario(this.usuario);
    }
  }

}
