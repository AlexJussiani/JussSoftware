import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NovoComponent } from './novo/novo.component';
import { FormsModule, ReactiveFormsModule }   from '@angular/forms';
import { ClienteRoutingModule } from './cliente.route';
import { ClienteAppComponent } from './cliente.app.component';
import { ListaComponent } from './lista/lista.component';
import { ClienteService } from './services/cliente.service';

import { EditarComponent } from './editar/editar.component';
import { ExcluirComponent } from './excluir/excluir.component';
import { DetalhesComponent } from './detalhes/detalhes.component';
import { HttpClientModule } from '@angular/common/http';

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
  ],
  providers: [
    ClienteService
  ]
})
export class clienteModule { }
