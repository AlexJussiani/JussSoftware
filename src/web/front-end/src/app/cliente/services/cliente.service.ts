import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";

import { Observable } from "rxjs";
import { catchError } from "rxjs/operators";

import { BaseService } from 'src/app/services/base.service';
import { Cliente } from '../models/cliente';

@Injectable()
export class ClienteService extends BaseService {

  cliente: Cliente = new Cliente();

    constructor(private http: HttpClient) { super()

        this.cliente.nome = "Teste Fake"
        this.cliente.cpf = "32165498754"
        this.cliente.excluido = false
        this.cliente.telefone = '43999365610'
    }

    obterTodos(): Observable<Cliente[]> {
        return this.http
            .get<Cliente[]>(this.UrlServiceV1 + "clientes")
            .pipe(catchError(super.serviceError));
    }

    obterPorId(id: string): Observable<Cliente> {
        return new Observable<Cliente>();
    }

    novoCliente(cliente: Cliente): Observable<Cliente> {
        return new Observable<Cliente>();
    }

    atualizarCliente(cliente: Cliente): Observable<Cliente> {
        return new Observable<Cliente>();
    }

    excluirCliente(id: string): Observable<Cliente> {
        return new Observable<Cliente>();
    }
}
