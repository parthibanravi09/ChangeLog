import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddchangelogComponent } from './addchangelog.component';

describe('AddchangelogComponent', () => {
  let component: AddchangelogComponent;
  let fixture: ComponentFixture<AddchangelogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddchangelogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddchangelogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
