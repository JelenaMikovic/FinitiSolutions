import { Component } from '@angular/core';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-header',
  standalone: false,
  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})
export class HeaderComponent {

  isMenuOpen = false;
  isLoggedIn = false;
  userRole: number | null = null;

  constructor(private auth: AuthService) {}

  ngOnInit() {
    this.auth.isLoggedIn().subscribe(status => {
      this.isLoggedIn = status;
    });

    this.auth.getUserRole().subscribe(role => {
      this.userRole = role;
    });
  }

  toggleMenu() {
    this.isMenuOpen = !this.isMenuOpen;
  }

  logout() {
    this.auth.logout().subscribe({
      next: () => {
        console.log('Logged out');
      },
      error: err => {
        console.error('Logout error:', err);
      }
    });
  }
}
