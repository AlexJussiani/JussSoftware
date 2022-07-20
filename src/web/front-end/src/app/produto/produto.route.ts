
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ListaComponent } from './lista/lista.component';
import { NovoComponent } from './novo/novo.component';
import { ProdutoAppComponent } from './produto.app.component';

const produtoRouterConfig: Routes = [
    {
        path: '', component: ProdutoAppComponent,
        children: [
          { path: 'listar-todos', component: ListaComponent },
          { path: 'adicionar-novo', component: NovoComponent },
        ]
    }
];

@NgModule({
    imports: [
        RouterModule.forChild(produtoRouterConfig)
    ],
    exports: [RouterModule]
})
export class ProdutoRoutingModule { }
