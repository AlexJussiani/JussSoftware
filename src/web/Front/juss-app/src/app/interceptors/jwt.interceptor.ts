import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { UsuarioRespostaLogin } from '../models/identity/User';
import { AccountService } from '../services/account.service';
import { catchError, take } from 'rxjs/operators';

@Injectable()
export class JwtInterceptor implements HttpInterceptor {

  constructor(private accountService: AccountService) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    let currentUser: UsuarioRespostaLogin | null;

    this.accountService.currentUser$.pipe(take(1)).subscribe(user => {
      currentUser = user

      if (currentUser) {
        request = request.clone({
            setHeaders: {
              Authorization: `Bearer ${currentUser.usuarioToken}`
            }
          }
        );
      }
    });

    return next.handle(request).pipe(
      catchError(error => {
        if (error) {
          localStorage.removeItem('user')
        }
        return throwError(error);
      })
    );
  }
}
