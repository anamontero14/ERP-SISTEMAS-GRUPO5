import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListProductosVM } from '../../../presentation/viewmodels/ListadoProductosVM';
import { ProductoItemComponent } from '../../../presentation/components/producto-item-component/producto-item-component';

@Component({
  standalone: true,
  selector: 'app-list-productos-screen',
  imports: [CommonModule, ProductoItemComponent],
  templateUrl: './list-productos.html'
})
export class ListProductosScreen implements OnInit {

  constructor(public vm: ListProductosVM) {}

  async ngOnInit() {
    await this.vm.cargarProductos();
  }
}
