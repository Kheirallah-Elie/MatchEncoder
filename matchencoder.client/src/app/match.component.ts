import { Component, OnInit } from '@angular/core';
import { Injectable } from '@angular/core';
import { ApiService } from '../services/api.service';

interface Team {
  id: number;
  name: string;
}

@Component({
  selector: 'app-match',
  templateUrl: './match.component.html',
})

@Injectable({
  providedIn: 'root'
})


export class MatchComponent implements OnInit {

  // Ensure matchData is initialized properly
  matchData: any = {
    eventName: '',
    matchDateTime: '',
    country: '',
    city: '',
    teamAId: '',
    teamBId: '',
  };
  // Initialize these arrays to avoid 'null' errors
  teams: Team[] = []; // Specify the type as Team[]
  teamAPlayers: any[] = [];
  teamBPlayers: any[] = [];


  constructor(private apiService: ApiService) { }

  ngOnInit() {
    this.loadTeams();
  }

  loadTeams() {
    this.apiService.getTeams().subscribe({
      next: (data: any) => {
        console.log('Received data:', data);  // Check if this contains a $values property
        // Assuming the response has the format { $values: [array of teams] }
        this.teams = data.$values || [];  // Safeguard in case $values is undefined
      },
      error: (error) => {
        console.error('Error fetching teams:', error);
        this.teams = [];
      }
    });
  }



  // Function to select players based on team selection
  onTeamSelect(team: 'A' | 'B', teamId: number): void {
    this.apiService.getPlayersByTeam(teamId).subscribe({
      next: (players) => {
        if (team === 'A') {
          this.teamAPlayers = players || [];
        } else {
          this.teamBPlayers = players || [];
        }
      },
      error: (error) => {
        console.error(`Error fetching players for Team ${team}:`, error);
        if (team === 'A') {
          this.teamAPlayers = [];
        } else {
          this.teamBPlayers = [];
        }
      }
    });
  }
  submitMatch(): void {
    // Submit match data and log the result
    this.apiService.createMatch(this.matchData).subscribe(
      (response) => {
        console.log('Match created:', response);
      },
      (error) => {
        console.error('Error creating match:', error);
      }
    );
  }
}
