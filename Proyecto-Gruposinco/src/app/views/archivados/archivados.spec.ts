import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Archivados } from './archivados';

describe('Archivados', () => {
  let component: Archivados;
  let fixture: ComponentFixture<Archivados>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Archivados]
    })
    .compileComponents();

    fixture = TestBed.createComponent(Archivados);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
