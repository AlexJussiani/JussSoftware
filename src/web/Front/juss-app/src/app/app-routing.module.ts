import { DashboardComponent } from './components/dashboard/dashboard.component';
import { LoginComponent } from './components/user/login/login.component';
import { MovimentacoesListaComponent } from './components/financeiro/movimentacoes/movimentacoes-lista/movimentacoes-lista.component';
import { ReceberListaComponent } from './components/financeiro/receber/receber-lista/receber-lista.component';
import { ReceberComponent } from './components/financeiro/receber/receber.component';
import { PagarListaComponent } from './components/financeiro/pagar/pagar-lista/pagar-lista.component';
import { PagarComponent } from './components/financeiro/pagar/pagar.component';
import { MovimentacoesComponent } from './components/financeiro/movimentacoes/movimentacoes.component';
import { HomeComponent } from './components/home/home.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UserComponent } from './components/user/user.component';

const routes: Routes = [
  {path: '', redirectTo: 'home', pathMatch: 'full'},
{
  path: 'user',
  component: UserComponent,
  children: [
    {path: 'login', component: LoginComponent}
  ]
},
  {path: 'dashboard', component: DashboardComponent},
  {path: 'home', component: HomeComponent},
  {path: 'movimentacoes', component: MovimentacoesComponent},
  {
    path: 'pagar',
    component: PagarComponent,
    children: [
      { path: 'lista', component: PagarListaComponent },
    ],
  },
  {
    path: 'receber',
    component: ReceberComponent,
    children: [
      { path: 'lista', component: ReceberListaComponent },
    ],
  },
  {
    path: 'movimentacoes',
    component: MovimentacoesComponent,
    children: [
      { path: 'lista', component: MovimentacoesListaComponent },
    ],
  },
  { path: '**', redirectTo: 'home', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
