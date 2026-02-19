import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProovedorItemComponent } from './proovedor-item-component';

describe('ProovedorItemComponent', () => {
  let component: ProovedorItemComponent;
  let fixture: ComponentFixture<ProovedorItemComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ProovedorItemComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ProovedorItemComponent);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
