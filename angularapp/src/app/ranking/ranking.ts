import { Component, OnInit } from '@angular/core';
import { VoteService, Candidate } from '../services/vote.service';
import { CommonModule } from '@angular/common';
import { ChartData, ChartOptions } from 'chart.js';
import { BaseChartDirective } from 'ng2-charts'; // <-- use directive only

@Component({
  selector: 'app-ranking',
  standalone: true,
  imports: [CommonModule, BaseChartDirective], // <-- correct for standalone
  templateUrl: './ranking.html',
  styleUrls: ['./ranking.scss']
})
export class RankingComponent implements OnInit {
  candidates: Candidate[] = [];

  // Chart data
  chartData: ChartData<'bar'> = {
    labels: [],
    datasets: [{ label: 'Votes', data: [], backgroundColor: [] }]
  };

  chartOptions: ChartOptions<'bar'> = {
    responsive: true,
    plugins: { legend: { display: false } }
  };

  constructor(private voteService: VoteService) {}

  ngOnInit(): void {
    this.loadRanking();
  }

  loadRanking() {
    this.voteService.getCandidatesByRanking().subscribe({
      next: candidates => {
        this.candidates = candidates;

        this.chartData.labels = candidates.map(c => c.name);
        this.chartData.datasets[0].data = candidates.map(c => c.voteCount);
        this.chartData.datasets[0].backgroundColor = candidates.map(
          (_, i) => `hsl(${(i * 45) % 360}, 70%, 50%)`
        );
      },
      error: err => console.error(err)
    });
  }

  // Medal emoji for top 3
  getRankEmoji(index: number) {
    if (index === 0) return '🥇';
    if (index === 1) return '🥈';
    if (index === 2) return '🥉';
    return '';
  }
}
