import {
  Component,
  Input,
  Output,
  EventEmitter,
  OnChanges,
  SimpleChanges
} from '@angular/core';

import {
  NgClass,
  NgStyle,
  NgSwitch,
  NgSwitchCase,
  NgSwitchDefault
} from '@angular/common';

import { HighlightDirective } from '../../directives/highlight';
import { CreditLabelPipe } from '../../pipes/credit-label-pipe';

@Component({
  selector: 'app-course-card',
  imports: [
    NgClass,
    NgStyle,
    NgSwitch,
    NgSwitchCase,
    NgSwitchDefault,
    HighlightDirective,
    CreditLabelPipe
  ],
  templateUrl: './course-card.html',
  styleUrl: './course-card.css'
})
export class CourseCardComponent implements OnChanges {

  @Input() course!: {
    id: number;
    name: string;
    code: string;
    credits: number;
    gradeStatus: string;
  };

  @Output()
  enrollRequested = new EventEmitter<number>();

  isExpanded = false;
  isEnrolled = false;

  ngOnChanges(changes: SimpleChanges) {
    console.log('Course Changed', changes);
  }

  enroll() {
    this.isEnrolled = true;
    this.enrollRequested.emit(this.course.id);
  }

  toggleDetails() {
    this.isExpanded = !this.isExpanded;
  }

  get cardClasses() {
    return {
      'card--enrolled': this.isEnrolled,
      'card--full': this.course.credits >= 4,
      'expanded': this.isExpanded
    };
  }

  getBorderColor() {
    switch (this.course.gradeStatus) {
      case 'passed':
        return 'green';

      case 'failed':
        return 'red';

      default:
        return 'grey';
    }
  }
}