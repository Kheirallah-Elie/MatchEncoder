import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, tap } from 'rxjs';

export interface User {
  name: string;
  password: string;
}

@Injectable({
  providedIn: 'root'
})

export class UserService {
  private apiUrl = 'https://localhost:7081/api/User';

  constructor(private http: HttpClient) { }

  getUsers(): Observable<any> {
    return this.http.get(`${this.apiUrl}`);
  }

  getUserById(userId: string): Observable<any> {
    return this.http.get(`${this.apiUrl}/${userId}`);
  }

  createUser(user: User): Observable<User> {
    return this.http.post<User>(`${this.apiUrl}/register`, user);
  }

  login(name: string, password: string): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/login`, { name, password }).pipe(
      tap((response) => {
        // Vérifiez que 'userId' est présent dans la réponse
        if (!response.userId) {
          throw new Error('Authentication failed');
        }
        // Stocke l'ID utilisateur en cas de succès
        localStorage.setItem('userId', response.userId);
      })
    );
  }

  logout(): Observable<any> {
    // Supprime l'ID utilisateur de localStorage à la déconnexion
    localStorage.removeItem('userId');
    return this.http.post(`${this.apiUrl}/logout`, {});
  }

  isAuthenticated(): Observable<boolean> {
    return this.http.get<boolean>(`${this.apiUrl}/isAuthenticated`);
  }

  // Méthode pour récupérer l'ID utilisateur stocké dans localStorage
  getUserId(): string | null {
    return localStorage.getItem('userId');
  }

}

