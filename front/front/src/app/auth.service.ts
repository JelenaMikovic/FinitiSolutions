import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, tap, catchError, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  
  constructor(private http: HttpClient) { }

  login(credentials: any): Observable<any> {
    return this.http.post<any>('apiHost' + '/user/login', credentials, { withCredentials: true })
      .pipe(
        tap(response => {
          return response;
        }),
        catchError((error: HttpErrorResponse) => {
          console.error('Login error:', error);
          return throwError(error);
        })
      );
  }

}
