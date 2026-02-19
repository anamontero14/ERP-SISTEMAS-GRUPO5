import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { UpdatePedidosProveedoresVM } from '../../../presentation/viewmodels/UpdatePedidosProveedoresVM';

@Component({
  standalone: true,
  selector: 'app-update-pedidos-proveedores-screen',
  imports: [CommonModule, FormsModule],
  templateUrl: './update-pedidos-proveedores.html',
  styleUrl: './update-pedidos-proveedores.css'
})
export class UpdatePedidosProveedoresScreen implements OnInit {

  idPedido!: number;
  modalVisible = false;
  modalConfig = { tipo: '', titulo: '', desc: '', confirmarTexto: '' };

  constructor(
    public vm: UpdatePedidosProveedoresVM,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  async ngOnInit() {
    this.idPedido = Number(this.route.snapshot.paramMap.get('id'));
    await this.vm.cargarDatos(this.idPedido);
  }

  pedirConfirmacion(tipo: 'guardar' | 'eliminar') {
    this.modalConfig = tipo === 'guardar'
      ? { tipo, titulo: '¿Guardar cambios?', desc: 'Se actualizarán los datos del pedido.', confirmarTexto: 'Sí, guardar' }
      : { tipo, titulo: '¿Archivar pedido?', desc: 'Esta acción es permanente y no se puede deshacer.', confirmarTexto: 'Sí, archivar' };
    this.modalVisible = true;
  }

  async confirmar() {
    this.modalVisible = false;
    if (this.modalConfig.tipo === 'guardar') {
      const ok = await this.vm.guardarDetalles();
      if (ok) this.router.navigate(['/pedidos']);
    } else {
      const ok = await this.vm.eliminarPedidoDesdeDetalle(0);
      if (ok) this.router.navigate(['/pedidos']);
    }
  }

  cancelar() {
    this.modalVisible = false;
  }
}