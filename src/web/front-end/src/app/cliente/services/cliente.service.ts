import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";

import { Observable } from "rxjs";
import { catchError, map } from "rxjs/operators";

import { BaseService } from 'src/app/services/base.service';
import { Cliente } from '../models/cliente';
import { CepConsulta, Endereco } from "../models/endereco";
import { Page } from "src/app/models/Pagination";

@Injectable()
export class ClienteService extends BaseService {

  pageIndex = 1;
  pagesize = 50;
  query = ''


    constructor(private http: HttpClient) { super()

        // this.cliente.nome = "Teste Fake"
        // this.cliente.cpf.numero = "32165498754"
        // this.cliente.excluido = false
        // this.cliente.telefone = '43999365610'
    }

    obterTodos(): Observable<Page<Cliente>>{
        let teste =  this.http
             .get<Page<Cliente>>(`${this.UrlServiceClientesV1}clientes?ps=${this.pagesize}&page=${this.pageIndex}&q=${this.query}`, this.ObterAuthHeaderJson())
            .pipe(
              map((obj) => obj),
              catchError(super.serviceError)
            );
            return teste;
    }

    obterPorId(id: string): Observable<Cliente> {
        return this.http
          .get<Cliente>(this.UrlServiceClientesV1 +"clientes/" + id, super.ObterAuthHeaderJson())
          .pipe(catchError(super.serviceError));
    }

    novoCliente(cliente: Cliente): Observable<Cliente> {
      return this.http
      .post(this.UrlServiceClientesV1 + "clientes", cliente, this.ObterAuthHeaderJson())
      .pipe(
        map(super.extractData),
        catchError(super.serviceError)
      );
    }

    atualizarCliente(cliente: Cliente): Observable<Cliente> {
        return new Observable<Cliente>();
    }

    atualizarEndereco(endereco: Endereco): Observable<Endereco> {
      return this.http
        .put(this.UrlServiceClientesV1 + "clientes/endereco" + endereco.id, endereco, super.ObterAuthHeaderJson())
        .pipe(
          map(super.extractData),
          catchError(super.serviceError)
        );
  }

    excluirCliente(id: string): Observable<Cliente> {
        return new Observable<Cliente>();
    }

    consultaCep(cep: string): Observable<CepConsulta> {
      return this.http
      .get<CepConsulta>(`http://viacep.com.br/ws/${cep}/json/`)
      .pipe(catchError(super.serviceError))
    }
}
