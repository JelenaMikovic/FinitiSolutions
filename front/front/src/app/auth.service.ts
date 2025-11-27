import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, catchError, tap, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private loggedIn$ = new BehaviorSubject<boolean>(false);
  private userRole$ = new BehaviorSubject<number | null>(null);

  constructor(private http: HttpClient) { }


  login(credentials: any) {
    return this.http.post<any>('http://localhost:5110/api/user/login', credentials, { withCredentials: true })
      .pipe(
        tap(response => {
          this.loggedIn$.next(true);

          this.userRole$.next(response.role);
        }),
        catchError(err => throwError(() => err))
      );
  }

  logout() {
    return this.http.post('http://localhost:5110/api/user/logout', {}, { withCredentials: true })
      .pipe(
        tap(() => {
          this.loggedIn$.next(false);
          this.userRole$.next(null);
        }),
        catchError(err => throwError(() => err))
      );
  }

  isLoggedIn() {
    return this.loggedIn$.asObservable();
  }

  getUserRole() {
    return this.userRole$.asObservable();
  }


}
