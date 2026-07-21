import {
  Component,
  Input,
  Output,
  EventEmitter,
  OnChanges,
  SimpleChanges
} from '@angular/core';

@Component({
  selector: 'app-course-card',
  imports: [],
  templateUrl: './course-card.html',
  styleUrl: './course-card.css'
})
export class CourseCardComponent implements OnChanges {

  @Input() course!: {
    id: number,
    name: string,
    code: string,
    credits: number
  };

  @Output()
  enrollRequested = new EventEmitter<number>();

  ngOnChanges(changes: SimpleChanges) {
    console.log('Course Changed', changes);
  }

  enroll() {
    this.enrollRequested.emit(this.course.id);
  }
}