import { ComponentFixture, TestBed } from '@angular/core/testing';
import { EnConstruccionComponent } from './en-construccion';

describe('EnConstruccionView', () => {
  let component: EnConstruccionComponent;
  let fixture: ComponentFixture<EnConstruccionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [EnConstruccionComponent]
    }).compileComponents();

    fixture = TestBed.createComponent(EnConstruccionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('debería crearse correctamente', () => {
    expect(component).toBeTruthy();
  });
});
