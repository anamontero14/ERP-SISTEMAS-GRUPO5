import { Component, OnInit } from '@angular/core';
import { BarraSuperior } from '../../../presentation/components/barra-superior/barra-superior';
import { ArchivadosVM } from '../../../presentation/viewmodels/ArchivadosVM';
import { PedidoItemComponent } from '../../../presentation/components/pedido-item-component/pedido-item-component';
import { CommonModule } from '@angular/common';

@Component({
  standalone: true,
  selector: 'app-archivados-screen',
  imports: [CommonModule, PedidoItemComponent],
  templateUrl: './archivados.html',
  styleUrl: './archivados.css',
})
export class ArchivadosScreen implements OnInit {
  constructor(public vm: ArchivadosVM) {}

  ngOnInit(): void {
    this.vm.cargarArchivados();
  }
}
