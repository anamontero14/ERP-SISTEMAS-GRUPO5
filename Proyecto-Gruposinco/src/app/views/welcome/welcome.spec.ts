import { ComponentFixture, TestBed } from '@angular/core/testing';
import { WelcomeComponent } from './welcome';
import { RouterTestingModule } from '@angular/router/testing';

describe('WelcomeComponent', () => {
  let component: WelcomeComponent;
  let fixture: ComponentFixture<WelcomeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [WelcomeComponent, RouterTestingModule]
    }).compileComponents();

    fixture = TestBed.createComponent(WelcomeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('debería crearse el componente de bienvenida', () => {
    expect(component).toBeTruthy();
  });

  it('debería mostrar el título de la empresa', () => {
    const el = fixture.nativeElement.querySelector('.titulo-bienvenida');
    expect(el.textContent).toContain('Gruposinco');
  });
});
