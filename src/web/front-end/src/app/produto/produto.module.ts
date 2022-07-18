import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListaComponent } from './lista/lista.component';
import { ProdutoAppComponent } from './produto.app.component';
import { ProdutoRoutingModule } from './produto.route';
import { ProdutoService } from './services/produto.service';
import { ClienteResolve } from '../cliente/services/cliente.resolve';
import { ClienteGuard } from './services/produto.guard';



@NgModule({
  declarations: [
    ListaComponent,
    ProdutoAppComponent
  ],
  imports: [
    CommonModule,
    ProdutoRoutingModule
  ],
  providers: [
    ProdutoService,
    ClienteResolve,
    ClienteGuard
  ]
})
export class ProdutoModule { }
