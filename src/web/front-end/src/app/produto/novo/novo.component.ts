import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { DisplayMessage } from 'src/app/utils/generic-form-validation';

@Component({
  selector: 'app-novo',
  templateUrl: './novo.component.html',
  styleUrls: []
})
export class NovoComponent implements OnInit {

  displayMessage: DisplayMessage = {};
  errors: any[] = [];
  produtoForm: FormGroup;
  imagemNome: string;

  constructor(
    private fb: FormBuilder
  ) { }

  ngOnInit(): void {
    this.produtoForm = this.fb.group({
      fornecedorId: ['', [Validators.required]],
      nome: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(200)]],
      descricao: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(1000)]],
      imagem: ['', [Validators.required]],
      valor: ['', [Validators.required]],
      ativo: [true]
    });
  }

  adicionarProduto(){

  }

  fileChangeEvent(event: any): void {
    
  }

}
