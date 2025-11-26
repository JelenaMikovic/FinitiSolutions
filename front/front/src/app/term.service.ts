import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

export interface CreateTermDTO {
  name: string;
  definition: string;
}

export interface UpdateTermDTO {
  id: number;
  name: string;
  definition: string;
}

export interface TermDTO {
  id: number;
  name: string;
  definition: string;
  status: string;
  createdAt: string;
  createdBy: string;
}

@Injectable({
  providedIn: 'root'
})
export class TermService {

  private apiUrl = 'http://localhost:5110/api/term';

  constructor(private http: HttpClient) { }

  private handleError(error: HttpErrorResponse) {
    console.error('API Error:', error);
    return throwError(() => new Error(error.message || 'Server error'));
  }

  getPublishedTerms(): Observable<TermDTO[]> {
    return this.http.get<TermDTO[]>(`${this.apiUrl}/published`)
      .pipe(catchError(this.handleError));
  }

  getDraftTerms(): Observable<TermDTO[]> {
    return this.http.get<TermDTO[]>(`${this.apiUrl}/drafts`, { withCredentials: true })
      .pipe(catchError(this.handleError));
  }

  getArchivedTerms(): Observable<TermDTO[]> {
    return this.http.get<TermDTO[]>(`${this.apiUrl}/archived`, { withCredentials: true })
      .pipe(catchError(this.handleError));
  }

  createTerm(term: CreateTermDTO): Observable<void> {
    return this.http.post<void>(`${this.apiUrl}/create`, term, { withCredentials: true })
      .pipe(catchError(this.handleError));
  }

  updateTerm(term: UpdateTermDTO): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/update`, term, { withCredentials: true })
      .pipe(catchError(this.handleError));
  }

  archiveTerm(id: number): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/archive/${id}`, {}, { withCredentials: true })
      .pipe(catchError(this.handleError));
  }

  deleteDraft(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/delete/${id}`, { withCredentials: true })
      .pipe(catchError(this.handleError));
  }

  publishTerm(id: number): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/publish/${id}`, {}, { withCredentials: true })
      .pipe(catchError(this.handleError));
  }
}