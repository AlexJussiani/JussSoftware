import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ClienteAppComponent } from './cliente.app.component';
import { NovoComponent } from './novo/novo.component';
import { ListaComponent } from './lista/lista.component';
import { EditarComponent } from './editar/editar.component';
import { DetalhesComponent } from './detalhes/detalhes.component';
import { ExcluirComponent } from './excluir/excluir.component';

const clienteRouterConfig: Routes = [
    {
        path: '', component: ClienteAppComponent,
        children: [
            { path: 'listar-todos', component: ListaComponent },
            { path: 'adicionar-novo', component: NovoComponent },
            { path: 'editar/:id', component: EditarComponent },
            { path: 'detalhes/:id', component: DetalhesComponent },
            { path: 'excluir/:id', component: ExcluirComponent }
        ]
    }
];

@NgModule({
    imports: [
        RouterModule.forChild(clienteRouterConfig)
    ],
    exports: [RouterModule]
})
export class ClienteRoutingModule { }
