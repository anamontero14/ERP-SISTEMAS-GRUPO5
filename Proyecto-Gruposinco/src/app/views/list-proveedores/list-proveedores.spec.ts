import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListProveedoresScreen } from './list-proveedores';

describe('ListProveedores', () => {
  let component: ListProveedoresScreen;
  let fixture: ComponentFixture<ListProveedoresScreen>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ListProveedoresScreen]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ListProveedoresScreen);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
