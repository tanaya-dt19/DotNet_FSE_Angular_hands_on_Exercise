import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CourseCardComponent } from '../../components/course-card/course-card';

@Component({
  selector: 'app-course-list',
  imports: [CommonModule, CourseCardComponent],
  templateUrl: './course-list.html',
  styleUrl: './course-list.css'
})
export class CourseListComponent implements OnInit {

  selectedCourseId: number | null = null;

  isLoading = true;

  courses = [
    {
      id: 1,
      name: 'Angular',
      code: 'ANG101',
      credits: 4,
      gradeStatus: 'passed'
    },
    {
      id: 2,
      name: 'React',
      code: 'REA101',
      credits: 4,
      gradeStatus: 'failed'
    },
    {
      id: 3,
      name: 'NodeJS',
      code: 'NOD101',
      credits: 3,
      gradeStatus: 'pending'
    },
    {
      id: 4,
      name: 'Java',
      code: 'JAV101',
      credits: 4,
      gradeStatus: 'passed'
    },
    {
      id: 5,
      name: 'Python',
      code: 'PYT101',
      credits: 1,
      gradeStatus: 'pending'
    }
  ];

  ngOnInit() {
    setTimeout(() => {
      this.isLoading = false;
    }, 1500);
  }

  onEnroll(courseId: number) {
    console.log('Enrolling in course: ' + courseId);
    this.selectedCourseId = courseId;
  }

  // trackBy improves performance by preventing Angular
  // from re-rendering unchanged items in a list.
  trackByCourseId(index: number, course: any) {
    return course.id;
  }
}