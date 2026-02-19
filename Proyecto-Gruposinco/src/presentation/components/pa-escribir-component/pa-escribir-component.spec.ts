import { ComponentFixture, TestBed } from '@angular/core/testing';
import { PaEscribirComponent } from './pa-escribir-component';
import { FormsModule } from '@angular/forms';

describe('PaEscribirComponent', () => {
  let component: PaEscribirComponent;
  let fixture: ComponentFixture<PaEscribirComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PaEscribirComponent, FormsModule]
    }).compileComponents();

    fixture = TestBed.createComponent(PaEscribirComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('debería crearse correctamente', () => {
    expect(component).toBeTruthy();
  });

  it('debería actualizar el valor cuando se escribe en el input', () => {
    const inputElement = fixture.nativeElement.querySelector('input');
    inputElement.value = 'hola@test.com';
    inputElement.dispatchEvent(new Event('input'));

    expect(component.value).toBe('hola@test.com');
  });

  it('debería mostrar el label correctamente', () => {
    component.label = 'Email de Usuario';
    fixture.detectChanges();
    const labelElement = fixture.nativeElement.querySelector('.input-label');
    expect(labelElement.textContent).toContain('Email de Usuario');
  });
});
