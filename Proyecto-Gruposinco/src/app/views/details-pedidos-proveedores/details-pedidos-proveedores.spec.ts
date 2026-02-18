import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DetailsPedidosProveedoresScreen } from './details-pedidos-proveedores';

describe('DetailsPedidosProveedoresScreen', () => {
  let component: DetailsPedidosProveedoresScreen;
  let fixture: ComponentFixture<DetailsPedidosProveedoresScreen>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DetailsPedidosProveedoresScreen]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DetailsPedidosProveedoresScreen);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
