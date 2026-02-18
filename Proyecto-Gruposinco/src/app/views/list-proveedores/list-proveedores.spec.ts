import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListProveedores } from './list-proveedores';

describe('ListProveedores', () => {
  let component: ListProveedores;
  let fixture: ComponentFixture<ListProveedores>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ListProveedores]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ListProveedores);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
