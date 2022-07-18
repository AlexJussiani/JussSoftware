import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";

import { Observable } from "rxjs";
import { catchError, map } from "rxjs/operators";

import { BaseService } from 'src/app/services/base.service';
import { Produto } from '../models/produtos';
import { Page } from "src/app/models/Pagination";

@Injectable()
export class ProdutoService extends BaseService {

  pageIndex = 1;
  pagesize = 50;
  query = ''


    constructor(private http: HttpClient) { super()

        // this.cliente.nome = "Teste Fake"
        // this.cliente.cpf.numero = "32165498754"
        // this.cliente.excluido = false
        // this.cliente.telefone = '43999365610'
    }

    obterTodos(): Observable<Page<Produto>>{
        let teste =  this.http
             .get<Page<Produto>>(`${this.UrlServiceProdutosV1}produtos?ps=${this.pagesize}&page=${this.pageIndex}&q=${this.query}`, this.ObterAuthHeaderJson())
            .pipe(
              map((obj) => obj),
              catchError(super.serviceError)
            );
            return teste;
    }

    obterClientePorId(id: string): Observable<Produto> {
        return this.http
          .get<Produto>(this.UrlServiceClientesV1 +"clientes/" + id, super.ObterAuthHeaderJson())
          .pipe(
            map((obj) => obj),
            catchError(super.serviceError)
          );
    }


    novoCliente(cliente: Produto): Observable<Produto> {
      return this.http
      .post(this.UrlServiceClientesV1 + "clientes", cliente, this.ObterAuthHeaderJson())
      .pipe(
        map(super.extractData),
        catchError(super.serviceError)
      );
    }

    atualizarCliente(cliente: Produto): Observable<Produto> {
        return this.http
          .put(this.UrlServiceClientesV1 + "clientes/" + cliente.id, cliente, super.ObterAuthHeaderJson())
          .pipe(
            map(super.extractData),
            catchError(super.serviceError)
          );
    }

    excluirCliente(id: string): Observable<Produto> {
      return this.http
      .delete(this.UrlServiceClientesV1 + "clientes/" + id, super.ObterAuthHeaderJson())
      .pipe(
        map(super.extractData),
        catchError(super.serviceError)
      );
    }
}
