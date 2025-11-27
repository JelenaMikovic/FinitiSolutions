import { Component, OnInit } from '@angular/core';
import { TermService, TermDTO } from '../term.service';
import { AuthService } from '../auth.service';
import { FormControl } from '@angular/forms';
import { debounceTime } from 'rxjs/operators';

@Component({
  selector: 'app-terms',
  standalone: false,
  templateUrl: './terms.component.html',
  styleUrls: ['./terms.component.css']
})
export class TermsComponent implements OnInit {
  terms: TermDTO[] = [];
  filteredTerms: TermDTO[] = [];
  searchControl = new FormControl('');
  displayedColumns: string[] = ['name', 'definition', 'actions']; 
  isAdmin = false;

  constructor(private termService: TermService, private authService: AuthService) { }

  ngOnInit(): void {
    this.loadTerms();

    this.authService.getUserRole().subscribe(role => {
      this.isAdmin = role === 1;
    });

    this.searchControl.valueChanges.pipe(
      debounceTime(300)
    ).subscribe(searchText => {
      const query = (searchText ?? '').toLowerCase();
      this.filteredTerms = this.terms.filter(term =>
        term.name.toLowerCase().includes(query)
      );
    });
  }

  loadTerms(): void {
    this.termService.getPublishedTerms().subscribe({
      next: (data) => {
        this.terms = data;
        this.filteredTerms = data;
      },
      error: (err) => console.error(err)
    });
  }

  archiveTerm(term: TermDTO): void {
    const confirmed = window.confirm(`Are you sure you want to archive the term "${term.name}"?`);
    if (!confirmed) return;

    this.termService.archiveTerm(term.id).subscribe({
      next: () => {
        alert(`Term "${term.name}" archived successfully.`);
        this.loadTerms(); 
      },
      error: (err) => {
        console.error(err);
        alert('Failed to archive the term.');
      }
    });
  }
}