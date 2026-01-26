import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { PersonasViewModel } from '../../ViewModels/PersonasViewModel';
import { PersonaListItemComponent } from '../persona-list-item/persona-list-item';
import { PersonaDTO } from '../../../Domain/DTOs/PersonaDTO';

@Component({
  selector: 'app-listado-personas',
  standalone: true,
  imports: [CommonModule, PersonaListItemComponent],
  templateUrl: './listado-personas.html',
  styleUrls: ['./listado-personas.css']
})
export class ListadoPersonasComponent implements OnInit {
  personas$!: Observable<PersonaDTO[]>;
  loading$!: Observable<boolean>;
  error$!: Observable<string | null>;

  constructor(
    private viewModel: PersonasViewModel,
    private router: Router
  ) {
    this.personas$ = this.viewModel.personas$;
    this.loading$ = this.viewModel.loading$;
    this.error$ = this.viewModel.error$;
  }

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