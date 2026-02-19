import { ComponentFixture, TestBed } from '@angular/core/testing';
import { LoginScreen } from './login';
import { LoginVM } from '../../../presentation/viewmodels/LoginVM';
import { signal } from '@angular/core';

describe('LoginScreen', () => {
  let component: LoginScreen;
  let fixture: ComponentFixture<LoginScreen>;
  let mockVM: any;

  beforeEach(async () => {
    // Simulamos el ViewModel con Signals
    mockVM = {
      email: signal(''),
      password: signal(''),
      loading: signal(false),
      error: signal(''),
      login: () => {}
    };

    await TestBed.configureTestingModule({
      imports: [LoginScreen],
      providers: [{ provide: LoginVM, useValue: mockVM }]
    }).compileComponents();

    fixture = TestBed.createComponent(LoginScreen);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('debería crearse correctamente la vista de login', () => {
    expect(component).toBeTruthy();
  });

  it('debería mostrar el mensaje de error cuando el VM tiene un error', () => {
    mockVM.error.set('Credenciales incorrectas');
    fixture.detectChanges();

    const errorElement = fixture.nativeElement.querySelector('.error-msg');
    expect(errorElement.textContent).toContain('Credenciales incorrectas');
  });

  it('no debería mostrar el mensaje de error si el campo está vacío', () => {
    mockVM.error.set('');
    fixture.detectChanges();

    const errorElement = fixture.nativeElement.querySelector('.error-msg');
    expect(errorElement).toBeFalsy(); // toBeFalsy es estándar y seguro
  });
});
