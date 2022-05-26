import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, ReplaySubject } from 'rxjs';
import { map, take } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { UsuarioRespostaLogin } from '../models/identity/User';

@Injectable(
  //{  providedIn: 'root'}
  )
export class AccountService {
  private currentUserSource = new ReplaySubject<UsuarioRespostaLogin>(1);
  public currentUser$ = this.currentUserSource.asObservable();

  baseUrl = environment.apiAutenticacao + 'api/identidade/autenticar/'

  constructor(private http: HttpClient) { }

  public login(model: any): Observable<void>{
    return this.http.post<UsuarioRespostaLogin>(this.baseUrl, model).pipe(
      take(1),
      map((response: UsuarioRespostaLogin) => {
        const user = response;
        if(user){
          this.setCurrentUser(user)
        }
      })
    );
  }

  logout(): void {
    localStorage.removeItem('user');
    localStorage.removeItem('user.accessToken');
    //this.currentUserSource.next();
    this.currentUserSource.complete();
  }

  public setCurrentUser(user: UsuarioRespostaLogin): void {
    localStorage.setItem('user', JSON.stringify(user.usuarioToken.email));
    localStorage.setItem('user.accessToken', JSON.stringify(user.accessToken));
    this.currentUserSource.next(user);
  }

}
