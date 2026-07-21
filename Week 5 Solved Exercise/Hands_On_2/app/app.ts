import { Component } from '@angular/core';
import { HeaderComponent } from './components/header/header';
import { HomeComponent } from './pages/home/home';
import { CourseListComponent } from './pages/course-list/course-list';

@Component({
  selector: 'app-root',
  imports: [
    HeaderComponent,
    HomeComponent,
    CourseListComponent
  ],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
}