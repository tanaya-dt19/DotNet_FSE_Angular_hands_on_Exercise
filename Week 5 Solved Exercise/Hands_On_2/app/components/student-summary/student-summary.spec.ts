import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StudentSummary } from './student-summary';

describe('StudentSummary', () => {
  let component: StudentSummary;
  let fixture: ComponentFixture<StudentSummary>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [StudentSummary],
    }).compileComponents();

    fixture = TestBed.createComponent(StudentSummary);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
