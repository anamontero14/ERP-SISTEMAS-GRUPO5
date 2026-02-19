import { ComponentFixture, TestBed } from '@angular/core/testing';
import { BarraSuperior } from './barra-superior';
import { RouterTestingModule } from '@angular/router/testing';
import { AuthService } from '../../services/AuthService';

describe('BarraSuperior', () => {
  let component: BarraSuperior;
  let fixture: ComponentFixture<BarraSuperior>;

  // Mock manual simple
  const authMock = { logout: () => {} };

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [BarraSuperior, RouterTestingModule],
      providers: [{ provide: AuthService, useValue: authMock }]
    }).compileComponents();

    fixture = TestBed.createComponent(BarraSuperior);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('debería crearse correctamente', () => {
    expect(component).toBeTruthy();
  });

  it('debería cambiar el estado del menú al hacer toggle', () => {
    component.toggleMenu();
    expect(component.menuAbierto).toBe(true);
    component.toggleMenu();
    expect(component.menuAbierto).toBe(false);
  });
});
