// src/app/voterdashboard/voterdashboard.ts
import { Component, OnInit, NgZone } from '@angular/core';
import { CommonModule } from '@angular/common'; // for *ngIf, *ngFor
import { FormsModule } from '@angular/forms';   // for [(ngModel)]
import { AuthService, User } from '../services/auth.service';
import { VoteService, Candidate } from '../services/vote.service';

@Component({
  selector: 'app-voter-dashboard',
  standalone: true,
  imports: [CommonModule, FormsModule], // <-- important!
  templateUrl: './voterdashboard.html',
  styleUrl: './voterdashboard.scss'
})
export class VoterDashboardComponent implements OnInit {
  user: User | null = null;
  candidates: Candidate[] = [];
  selectedCandidateId: number | null = null;
  message = '';

  constructor(
    private auth: AuthService,
    private voteService: VoteService,
    private ngZone: NgZone // for reliable message disappearing
  ) {
    this.user = this.auth.getUser();
  }

  ngOnInit() {
    this.loadCandidates();
  }

  loadCandidates() {
    this.voteService.getCandidates().subscribe({
      next: data => this.candidates = data,
      error: err => this.showMessage('Failed to load candidates', false)
    });
  }

  vote() {
    if (!this.user || this.selectedCandidateId === null) {
      this.showMessage('Please select a candidate', false);
      return;
    }

    this.voteService.castVote({ userId: this.user.id, candidateId: this.selectedCandidateId }).subscribe({
      next: _ => this.showMessage('Vote cast successfully!', true),
      error: err => this.showMessage(err.error || 'Failed to cast vote', false)
    });
  }

  // Show message popup and auto-hide after 3 seconds
  showMessage(msg: string, success: boolean) {
    this.message = msg;

    // Auto-hide after 3 seconds
    this.ngZone.runOutsideAngular(() => {
      setTimeout(() => {
        this.ngZone.run(() => {
          this.message = '';
        });
      }, 3000);
    });
  }
}
