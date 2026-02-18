import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListProveedoresVM } from '../../../presentation/viewmodels/ListadoProveedoresVM';
import { ProveedorItemComponent } from '../../../presentation/components/proovedor-item-component/proovedor-item-component';

@Component({
  standalone: true,
  selector: 'app-list-proveedores-screen',
  imports: [CommonModule, ProveedorItemComponent],
  templateUrl: './list-proveedores.html'
})
export class ListProveedoresScreen implements OnInit {

  constructor(public vm: ListProveedoresVM) {}

  async ngOnInit() {
    await this.vm.cargarProveedores();
  }
}
