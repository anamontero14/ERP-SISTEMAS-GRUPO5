import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PaEscribirComponent } from './pa-escribir-component';

describe('PaEscribirComponent', () => {
  let component: PaEscribirComponent;
  let fixture: ComponentFixture<PaEscribirComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PaEscribirComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PaEscribirComponent);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
