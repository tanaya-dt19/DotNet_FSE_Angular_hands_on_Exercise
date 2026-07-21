import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CourseCardComponent } from '../../components/course-card/course-card';

@Component({
  selector: 'app-course-list',
  imports: [CommonModule, CourseCardComponent],
  templateUrl: './course-list.html',
  styleUrl: './course-list.css'
})
export class CourseListComponent {

  selectedCourseId: number | null = null;

  courses = [
    { id: 1, name: 'Angular', code: 'ANG101', credits: 4 },
    { id: 2, name: 'React', code: 'REA101', credits: 4 },
    { id: 3, name: 'NodeJS', code: 'NOD101', credits: 3 },
    { id: 4, name: 'Java', code: 'JAV101', credits: 4 },
    { id: 5, name: 'Python', code: 'PYT101', credits: 3 }
  ];

  onEnroll(courseId: number) {
    console.log('Enrolling in course: ' + courseId);
    this.selectedCourseId = courseId;
  }
}