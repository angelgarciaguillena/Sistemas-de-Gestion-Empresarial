import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-welcome-screen',
  standalone: true,
  imports: [CommonModule, RouterLink],
  templateUrl: './welcome-screen.html',
  styleUrls: ['./welcome-screen.css']
})
export class WelcomeScreenComponent {}