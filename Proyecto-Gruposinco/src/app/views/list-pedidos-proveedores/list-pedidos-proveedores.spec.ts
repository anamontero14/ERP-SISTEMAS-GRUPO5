import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListPedidosProveedores } from './list-pedidos-proveedores';

describe('ListPedidosProveedores', () => {
  let component: ListPedidosProveedores;
  let fixture: ComponentFixture<ListPedidosProveedores>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ListPedidosProveedores]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ListPedidosProveedores);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
