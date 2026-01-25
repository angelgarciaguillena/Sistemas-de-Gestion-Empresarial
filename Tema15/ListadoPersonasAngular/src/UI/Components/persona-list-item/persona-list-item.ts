import { Component, Input, Output, EventEmitter } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PersonaDTO } from '../../../Domain/DTOs/PersonaDTO';

@Component({
  selector: 'app-persona-list-item',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './persona-list-item.html',
  styleUrls: ['./persona-list-item.css']
})
export class PersonaListItemComponent {
  @Input() persona!: PersonaDTO;
  @Output() editar = new EventEmitter<PersonaDTO>();
  @Output() eliminar = new EventEmitter<number>();

  onEditar(): void {
    this.editar.emit(this.persona);
  }

  onEliminar(): void {
    if (confirm(`¿Está seguro de eliminar a ${this.persona.nombre} ${this.persona.apellidos}?`)) {
      this.eliminar.emit(this.persona.id);
    }
  }
}