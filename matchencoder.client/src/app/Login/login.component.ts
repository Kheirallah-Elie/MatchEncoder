import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent {
  name: string = '';
  password: string = '';
  errorMessage: string = '';

  constructor(private userService: UserService, private router: Router) { }

  login() {
    this.userService.login(this.name, this.password).subscribe({
      next: (response: any) => {
        // Assuming `response` includes `isAdmin` and other user details
        const isAdmin = response.isAdmin;

        if (isAdmin) {
          this.router.navigate(['/create-match']); // Route for admin users
        } else {
          this.router.navigate(['/register']); // Route for regular users
        }
      },
      error: (error) => {
        if (error.status === 401) {
          this.errorMessage = 'Invalid username or password. Please try again.';
        } else {
          this.errorMessage = 'An unexpected error occurred. Please try again later.';
        }
      },
    });
  }
}
