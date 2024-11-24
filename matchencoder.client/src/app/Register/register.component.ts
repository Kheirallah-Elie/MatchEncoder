import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  name: string = '';
  password: string = '';
  confirmPassword: string = '';
  errorMessage: string = '';

  constructor(private userService: UserService, private router: Router) { }

  register() {
    if (this.password !== this.confirmPassword) {
      this.errorMessage = "Passwords do not match.";
      return;
    }

    this.userService.createUser({
      name: this.name,
      password: this.password
    }).subscribe({
      next: (response) => {
        // If registration is successful, redirect to login
        setTimeout(() => this.router.navigate(['/login']), 2000);
      },
      error: (error) => {
        // If registration fails, display an error message
        this.errorMessage = 'Registration failed. Please try again.';
      }
    });
  }
}
