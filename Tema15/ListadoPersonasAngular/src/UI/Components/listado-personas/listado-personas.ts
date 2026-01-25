import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { PersonasViewModel } from '../../ViewModels/PersonasViewModel';
import { PersonaDTO } from '../../../Domain/DTOs/PersonaDTO';
import { PersonaListItemComponent } from '../persona-list-item/persona-list-item';

@Component({
  selector: 'app-listado-personas',
  standalone: true,
  imports: [CommonModule, PersonaListItemComponent],
  templateUrl: './listado-personas.html',
  styleUrls: ['./listado-personas.css']
})
export class ListadoPersonasComponent implements OnInit {
  

  constructor(
    private viewModel: PersonasViewModel,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.viewModel.cargarPersonas();
  }

  nuevaPersona(): void {
    this.router.navigate(['/personas/nuevo']);
  }

  editarPersona(persona: PersonaDTO): void {
    this.router.navigate(['/personas/editar', persona.id]);
  }

  async eliminarPersona(id: number): Promise<void> {
    await this.viewModel.eliminarPersona(id);
  }
}