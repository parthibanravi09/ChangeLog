import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ChangelogformComponent } from './changelogform.component';

describe('ChangelogformComponent', () => {
  let component: ChangelogformComponent;
  let fixture: ComponentFixture<ChangelogformComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ChangelogformComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ChangelogformComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
