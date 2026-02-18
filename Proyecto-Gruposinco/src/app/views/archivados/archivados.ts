import { Component, OnInit } from '@angular/core';
import { BarraSuperior } from '../../../presentation/components/barra-superior/barra-superior';
import { ArchivadosVM } from '../../../presentation/viewmodels/ArchivadosVM';
import { PedidoItemComponent } from '../../../presentation/components/pedido-item-component/pedido-item-component';
import { CommonModule } from '@angular/common';

@Component({
  standalone: true,
  selector: 'app-archivados-screen',
  imports: [CommonModule, PedidoItemComponent],
  template: `
    <h2>Pedidos archivados</h2>
    <div *ngIf="vm.loading()">Cargando...</div>
    <app-pedido-item
      *ngFor="let p of vm.archivados()"
      [pedido]="p"
    ></app-pedido-item>
  `,
})
export class ArchivadosScreen implements OnInit {
  constructor(public vm: ArchivadosVM) {}

  ngOnInit(): void {
    this.vm.cargarArchivados();
  }
}
