import { Component, OnInit } from '@angular/core';
import { TermService, TermDTO } from '../term.service';
import { FormControl } from '@angular/forms';
import { debounceTime } from 'rxjs/operators';

@Component({
  selector: 'app-archive',
  standalone: false,
  templateUrl: './archive.component.html',
  styleUrls: ['./archive.component.css']
})
export class ArchiveComponent implements OnInit {
  terms: TermDTO[] = [];
  filteredTerms: TermDTO[] = [];
  searchControl = new FormControl('');
  displayedColumns: string[] = ['name', 'definition']; 

  constructor(private termService: TermService) { }

  ngOnInit(): void {
    this.loadArchivedTerms();

    this.searchControl.valueChanges.pipe(
      debounceTime(300)
    ).subscribe(searchText => {
      const query = (searchText ?? '').toLowerCase();
      this.filteredTerms = this.terms.filter(term =>
        term.name.toLowerCase().includes(query)
      );
    });
  }

  loadArchivedTerms(): void {
    this.termService.getArchivedTerms().subscribe({
      next: (data) => {
        this.terms = data;
        this.filteredTerms = data;
      },
      error: (err) => console.error(err)
    });
  }
}
