import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, ActivatedRoute } from '@angular/router';
import { DetailsPedidosProveedoresVM } from '../../../presentation/viewmodels/DetailsPedidosProveedoresVM';

@Component({
  standalone: true,
  selector: 'app-details-pedidos-proveedores-screen',
  imports: [CommonModule, RouterModule],
  templateUrl: './details-pedidos-proveedores.html',
})
export class DetailsPedidosProveedoresScreen implements OnInit {

  idPedido!: number;

  constructor(
    public vm: DetailsPedidosProveedoresVM,
    private route: ActivatedRoute
  ) {}

  async ngOnInit() {
    this.idPedido = Number(this.route.snapshot.paramMap.get('id'));
    await this.vm.cargarDatos(this.idPedido);
  }
}
