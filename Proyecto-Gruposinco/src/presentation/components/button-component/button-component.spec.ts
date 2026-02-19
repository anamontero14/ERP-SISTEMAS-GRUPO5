import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ButtonComponent } from './button-component';

describe('ButtonComponent', () => {
  let component: ButtonComponent;
  let fixture: ComponentFixture<ButtonComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ButtonComponent]
    }).compileComponents();

    fixture = TestBed.createComponent(ButtonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('debería crearse el componente', () => {
    expect(component).toBeTruthy();
  });

  it('debería avisar cuando se hace clic', () => {
    let seHizoClic = 0;

    component.clicked.subscribe(() => {
      seHizoClic = 1;
    });

    const botonElemento = fixture.nativeElement.querySelector('button');
    botonElemento.click();

    expect(seHizoClic).toBe(1);
  });

  it('debería mostrar el texto de carga si está deshabilitado', () => {
    component.disabled = true;
    component.label = 'Entrar';
    fixture.detectChanges();

    const contenido = fixture.nativeElement.textContent;
    expect(contenido).toContain('Cargando...');
  });
});
