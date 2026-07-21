import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-home',
  imports: [FormsModule],
  templateUrl: './home.html',
  styleUrl: './home.css'
})
export class HomeComponent implements OnInit, OnDestroy {

  portalName = 'Student Course Portal';
  isPortalActive = true;
  searchTerm = '';
  message = '';
  availableCourses = 0;

  ngOnInit() {
    this.availableCourses = 5;
    console.log('HomeComponent initialised — courses loaded');
  }

  ngOnDestroy() {
    console.log('HomeComponent destroyed');
  }

  onEnrollClick() {
    this.message = 'Enrollment opened!';
  }
}