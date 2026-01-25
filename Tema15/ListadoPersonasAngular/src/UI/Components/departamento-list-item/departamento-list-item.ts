import { Component, Input, Output, EventEmitter } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Departamento } from '../../../Domain/Entities/Departamento';
@Component({
  selector: 'app-departamento-list-item',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './departamento-list-item.html',
  styleUrls: ['./departamento-list-item.css']
})
export class DepartamentoListItemComponent {
  @Input() departamento!: Departamento;
  @Output() editar = new EventEmitter<Departamento>();
  @Output() eliminar = new EventEmitter<number>();

  onEditar(): void {
    this.editar.emit(this.departamento);
  }

  onEliminar(): void {
    if (confirm(`¿Está seguro de eliminar el departamento ${this.departamento.nombre}?`)) {
      this.eliminar.emit(this.departamento.id);
    }
  }
}
