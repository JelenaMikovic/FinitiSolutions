import { Component, OnInit } from '@angular/core';
import { TermService, TermDTO, CreateTermDTO, UpdateTermDTO } from '../term.service';

@Component({
  selector: 'app-drafts',
  standalone: false,
  templateUrl: './drafts.component.html',
  styleUrls: ['./drafts.component.css']
})
export class DraftsComponent implements OnInit {

  displayedColumns = ['name', 'definition', 'actions'];
  drafts: TermDTO[] = [];

  newDraft: CreateTermDTO = { name: '', definition: '' };
  editDraft: UpdateTermDTO | null = null;

  constructor(private termService: TermService) {}

  ngOnInit() {
    this.loadDrafts();
  }

  loadDrafts() {
    this.termService.getDraftTerms().subscribe({
      next: (data) => this.drafts = data,
      error: (err) => alert('Error loading drafts: ' + err.message)
    });
  }

  createDraft() {
    if (!this.newDraft.name.trim() || !this.newDraft.definition.trim()) {
      alert("Please enter a name and definition.");
      return;
    }

    this.termService.createTerm(this.newDraft).subscribe({
      next: () => {
        this.newDraft = { name: '', definition: '' };
        this.loadDrafts();
        alert('Draft created successfully!');
      },
      error: (err) => alert('Failed to create draft: ' + err.message)
    });
  }

  startEdit(draft: TermDTO) {
    this.editDraft = {
      id: draft.id,
      name: draft.name,
      definition: draft.definition
    };
  }

  cancelEdit() {
    this.editDraft = null;
  }

  updateDraft() {
    if (!this.editDraft) return;

    this.termService.updateTerm(this.editDraft).subscribe({
      next: () => {
        this.editDraft = null;
        this.loadDrafts();
        alert('Draft updated successfully!');
      },
      error: (err) => alert('Failed to update draft: ' + err.message)
    });
  }

  deleteDraft(id: number) {
    if (!confirm("Delete this draft?")) return;

    this.termService.deleteDraft(id).subscribe({
      next: () => {
        this.loadDrafts();
        alert('Draft deleted successfully!');
      },
      error: (err) => alert('Failed to delete draft: ' + err.message)
    });
  }

  publishDraft(id: number) {
    if (!confirm("Publish this draft?")) return;

    this.termService.publishTerm(id).subscribe({
      next: () => {
        this.loadDrafts();
        alert('Draft published successfully!');
      },
      error: (err) => alert('Failed to publish draft: ' + err.message)
    });
  }

}
