import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule }   from '@angular/forms';

import { NgBrazil } from 'ng-brazil'
import { TextMaskModule } from 'angular2-text-mask';

import { ClienteRoutingModule } from './cliente.route';
import { ClienteAppComponent } from './cliente.app.component';
import { ListaComponent } from './lista/lista.component';
import { ClienteService } from './services/cliente.service';
import { EditarComponent } from './editar/editar.component';
import { ExcluirComponent } from './excluir/excluir.component';
import { DetalhesComponent } from './detalhes/detalhes.component';
import { NovoComponent } from './novo/novo.component';

@NgModule({
  declarations: [
    ClienteAppComponent,
    NovoComponent,
    ListaComponent,
    EditarComponent,
    ExcluirComponent,
    DetalhesComponent
  ],
  imports: [
    CommonModule,
    ClienteRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    TextMaskModule,
    NgBrazil
  ],
  providers: [
    ClienteService
  ]
})
export class clienteModule { }
