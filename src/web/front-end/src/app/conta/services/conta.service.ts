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
      .post(this.UrlServiceV1 + 'identidade/nova-conta', usuario, this.ObterHeaderJson())
      .pipe(
        map(this.extractData),
        catchError(this.serviceError));

      return response;
  }

  login(usuario: Usuario): Observable<Usuario>{
    let response = this.http
    .post(this.UrlServiceV1 + 'identidade/autenticar', usuario, this.ObterHeaderJson())
    .pipe(
      map(this.extractData),
      catchError(this.serviceError));

    return response;
  }
}
