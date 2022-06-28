import { NotFoundComponent } from './not-found/not-found.component';
import { FooterComponent } from './footer/footer.component';
import { HomeComponent } from './home/home.component';
import { MenuComponent } from './menu/menu.component';
import { NgModule } from "@angular/core";
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

@NgModule({
  declarations: [
    MenuComponent,
    HomeComponent,
    FooterComponent,
    NotFoundComponent,
  ],
  imports:[
    CommonModule,
    RouterModule,
    NgbModule
  ],
  exports:[
    MenuComponent,
    HomeComponent,
    FooterComponent,
    NotFoundComponent,
  ]
})
export class NavegacaoModule{  }