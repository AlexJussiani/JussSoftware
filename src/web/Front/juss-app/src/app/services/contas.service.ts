import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import {  EMPTY, Observable  } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Conta } from '../models/conta';
import { PagedViewModel } from '../models/PagedViewModel';

@Injectable(
  //{providedIn: 'root'}
  )
export class ContasService {
  baseURL = environment.apiContas + 'contas/';
  snackBar: any;

constructor(private http: HttpClient) { }

  public getContasPagar(ps?: number, page?: number, q?: string): Observable<PagedViewModel<Conta>>{

    return this.http
    .get<Conta[]>(`${this.baseURL+'contaPagar'}?ps=${ps}&page=${page}&q=${q}`).pipe(
      map((obj) => obj),
      catchError((e) => this.errorHandler(e))
    );
  }
  errorHandler(e: any): Observable<any> {
    this.showMessage("Ocorreu um erro ao listar", true);
    console.log(e);
    return EMPTY;
  }

  showMessage(msg: string, isError: boolean = false): void {
    this.snackBar.open(msg, "X", {
      duration: 3000,
      horizontalPosition: "right",
      verticalPosition: "top",
      panelClass: isError ? ["msg-error"] : ["msg-success"],
    });
  }

}
