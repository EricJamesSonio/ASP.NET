// src/app/voterdashboard/voterdashboard.ts
import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common'; // for *ngIf, *ngFor
import { FormsModule } from '@angular/forms';   // for [(ngModel)]
import { AuthService, User } from '../services/auth.service';
import { VoteService, Candidate } from '../services/vote.service';

@Component({
  selector: 'app-voter-dashboard',
  standalone: true,
  imports: [CommonModule, FormsModule], // <-- important!
  templateUrl: './voterdashboard.html'
})
export class VoterDashboardComponent implements OnInit {
  user: User | null = null;
  candidates: Candidate[] = [];
  selectedCandidateId: number | null = null;
  message = '';

  constructor(private auth: AuthService, private voteService: VoteService) {
    this.user = this.auth.getUser();
  }

  ngOnInit() {
    this.loadCandidates();
  }

  loadCandidates() {
    this.voteService.getCandidates().subscribe({
      next: data => this.candidates = data,
      error: err => this.message = 'Failed to load candidates'
    });
  }

  vote() {
    if (!this.user || this.selectedCandidateId === null) {
      this.message = 'Please select a candidate';
      return;
    }

    this.voteService.castVote({ userId: this.user.id, candidateId: this.selectedCandidateId }).subscribe({
      next: _ => this.message = 'Vote cast successfully!',
      error: err => this.message = err.error || 'Failed to cast vote'
    });
  }
}
