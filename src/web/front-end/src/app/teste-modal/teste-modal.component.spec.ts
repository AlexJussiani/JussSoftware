import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TesteModalComponent } from './teste-modal.component';

describe('TesteModalComponent', () => {
  let component: TesteModalComponent;
  let fixture: ComponentFixture<TesteModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TesteModalComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TesteModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
