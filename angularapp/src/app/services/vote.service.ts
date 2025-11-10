// src/app/services/vote.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

// Match backend CandidateDto
export interface Candidate {
  id: number;
  name: string;
  party?: string;
  voteCount: number; // match backend property exactly
}

export interface VoteRequest {
  userId: number;
  candidateId: number;
}

@Injectable({
  providedIn: 'root'
})
export class VoteService {
  constructor(private http: HttpClient) {}

  // Get all candidates
  getCandidates(): Observable<Candidate[]> {
    return this.http.get<Candidate[]>(`${environment.apiUrl}/candidate`);
  }

  // Cast a vote using query parameters
  castVote(request: VoteRequest): Observable<any> {
    return this.http.post(
      `${environment.apiUrl}/vote?userId=${request.userId}&candidateId=${request.candidateId}`,
      {} // empty body, data is in query string
    );
  }

  // Get vote results
  getResults(): Observable<{ candidate: string; votes: number }[]> {
    return this.http.get<{ candidate: string; votes: number }[]>(`${environment.apiUrl}/vote/results`);
  }
}
