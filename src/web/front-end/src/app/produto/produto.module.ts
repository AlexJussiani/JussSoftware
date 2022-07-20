import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { ListaComponent } from './lista/lista.component';
import { ProdutoAppComponent } from './produto.app.component';
import { ProdutoRoutingModule } from './produto.route';
import { ProdutoService } from './services/produto.service';
import { ClienteResolve } from '../cliente/services/cliente.resolve';
import { ClienteGuard } from './services/produto.guard';
import { NovoComponent } from './novo/novo.component';



@NgModule({
  declarations: [
    ListaComponent,
    ProdutoAppComponent,
    NovoComponent
  ],
  imports: [
    CommonModule,
    ProdutoRoutingModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  providers: [
    ProdutoService,
    ClienteResolve,
    ClienteGuard
  ]
})
export class ProdutoModule { }
