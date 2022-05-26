/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { PagarListaComponent } from './pagar-lista.component';

describe('PagarListaComponent', () => {
  let component: PagarListaComponent;
  let fixture: ComponentFixture<PagarListaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PagarListaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PagarListaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
