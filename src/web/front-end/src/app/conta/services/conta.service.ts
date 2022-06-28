import { catchError, map, Observable } from 'rxjs';
import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Usuario } from "../models/usuario";
import { BaseService } from 'src/app/services/base.service';

@Injectable()
export class ContaService extends BaseService{

  constructor(private http: HttpClient){ super();}

  registrarUsuario(usuario: Usuario): Observable<Usuario>{
    let response = this.http
      .post(this.UrlServiceV1 + 'nova-conta', usuario, this.ObterHeaderJson())
      .pipe(
        map(result => {}),
        catchError());

      return response;
  }

  login(usuario: Usuario){

  }
}
