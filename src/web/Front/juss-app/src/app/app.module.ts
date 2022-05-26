import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule }   from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { CollapseModule } from 'ngx-bootstrap/collapse';
import { ToastrModule } from 'ngx-toastr';
import { NgxSpinnerModule } from 'ngx-spinner';
import { NgxCurrencyModule } from 'ngx-currency';

import { AccountService } from './services/account.service'

import { JwtInterceptor } from './interceptors/jwt.interceptor';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavComponent } from './shared/nav/nav.component'
import { TituloComponent } from './shared/titulo/titulo.component'
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { LoginComponent } from './components/user/login/login.component'
import { UserComponent } from './components/user/user.component'
import { HomeComponent } from './components/home/home.component'
import { MovimentacoesComponent } from './components/financeiro/movimentacoes/movimentacoes.component'
import { PagarComponent } from './components/financeiro/pagar/pagar.component'
import { PagarListaComponent } from './components/financeiro/pagar/pagar-lista/pagar-lista.component'
import { ReceberComponent } from './components/financeiro/receber/receber.component';


@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    DashboardComponent,
    TituloComponent,
    LoginComponent,
    UserComponent,
    HomeComponent,
    MovimentacoesComponent,
    PagarComponent,
    PagarListaComponent,
    ReceberComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot({
      timeOut: 4000,
      positionClass: 'toast-bottom-right',
      preventDuplicates: true,
      progressBar: true,
    }),
    NgxSpinnerModule,
    NgxCurrencyModule,
    TooltipModule.forRoot(),
    CollapseModule.forRoot(),
    BsDropdownModule.forRoot()
  ],
  providers: [
    AccountService,
    {provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
