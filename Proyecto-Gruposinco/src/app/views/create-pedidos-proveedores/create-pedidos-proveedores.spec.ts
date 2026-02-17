import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreatePedidosProveedores } from './create-pedidos-proveedores';

describe('CreatePedidosProveedores', () => {
  let component: CreatePedidosProveedores;
  let fixture: ComponentFixture<CreatePedidosProveedores>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CreatePedidosProveedores]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CreatePedidosProveedores);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
