import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-home',
  imports: [FormsModule],
  templateUrl: './home.html',
  styleUrl: './home.css'
})
export class HomeComponent {
  studentName = 'Shamal';
  courseName = '';

  enrollCourse() {
    alert('Enrolled in ' + this.courseName);
  }
}
