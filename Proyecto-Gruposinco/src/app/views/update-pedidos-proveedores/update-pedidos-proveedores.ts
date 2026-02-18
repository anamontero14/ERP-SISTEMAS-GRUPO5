import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { UpdatePedidosProveedoresVM } from '../../../presentation/viewmodels/UpdatePedidosProveedoresVM';

@Component({
  standalone: true,
  selector: 'app-update-pedidos-proveedores-screen',
  imports: [CommonModule, FormsModule],
  templateUrl: './update-pedidos-proveedores.html'
})
export class UpdatePedidosProveedoresScreen implements OnInit {

  constructor(
    public vm: UpdatePedidosProveedoresVM,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  async ngOnInit() {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    await this.vm.cargarDatos(id);
  }

  async guardar() {
    const ok = await this.vm.guardarDetalles();
    if (ok) this.router.navigate(['/pedidos']);
  }

  async eliminar(index: number) {
    const ok = await this.vm.eliminarPedidoDesdeDetalle(index);
    if (ok) this.router.navigate(['/pedidos']);
  }
}
