import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Team {
  id: number;
  name: string;
}

@Injectable({
  providedIn: 'root'
})

export class ApiService {
  private baseUrl = 'https://localhost:7081/api';  // Replace with actual backend URL

  constructor(private http: HttpClient) { }

  getTeams(): Observable<any[]> {
    return this.http.get<any[]>(`${this.baseUrl}/Team`);
  }

  getPlayersByTeam(teamId: number): Observable<any[]> {
    return this.http.get<any[]>(`${this.baseUrl}/Team/${teamId}/Player`);
  }

  createMatch(matchData: any): Observable<any> {
    return this.http.post(`${this.baseUrl}/Match`, matchData);
  }

  createTeam(teamData: any): Observable<any> {
    return this.http.post(`${this.baseUrl}/Team`, teamData);
  }

  createPlayer(playerData: any): Observable<any> {
    return this.http.post(`${this.baseUrl}/Player`, playerData);
  }
}


