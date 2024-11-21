import { Component, OnInit } from '@angular/core';
import { ApiService } from '../services/api.service';

@Component({
  selector: 'app-root',
  templateUrl: './match.component.html',
})
export class MatchComponent implements OnInit {
  matchData: any = {
    eventName: '',
    matchDateTime: '',
    country: '',
    city: '',
    teamAId: '',
    teamBId: '',
  };

  teams: any[] = [];
  teamAPlayers: any[] = [];
  teamBPlayers: any[] = [];

  constructor(private apiService: ApiService) { }

  ngOnInit(): void {
    this.apiService.getTeams().subscribe((data) => (this.teams = data));
  }

  onTeamSelect(team: 'A' | 'B', teamId: number): void {
    this.apiService.getPlayersByTeam(teamId).subscribe((players) => {
      if (team === 'A') {
        this.teamAPlayers = players;
      } else {
        this.teamBPlayers = players;
      }
    });
  }

  submitMatch(): void {
    this.apiService.createMatch(this.matchData).subscribe((response) => {
      console.log('Match created:', response);
    });
  }
}
