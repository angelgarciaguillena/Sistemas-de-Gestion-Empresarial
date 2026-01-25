import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { PersonaDTO } from '../../Domain/DTOs/PersonaDTO';
import { IPersonaUseCase } from '../../Domain/Interfaces/IPersonaUseCase';
import { container } from '../../Core/Container';
import { TYPES } from '../../Core/Types';

@Injectable({
  providedIn: 'root'
})
export class PersonasViewModel {
  private personaUseCase: IPersonaUseCase;
  
  private _personas = new BehaviorSubject<PersonaDTO[]>([]);
  public personas$: Observable<PersonaDTO[]> = this._personas.asObservable();
  
  private _personaSeleccionada = new BehaviorSubject<PersonaDTO | null>(null);
  public personaSeleccionada$: Observable<PersonaDTO | null> = this._personaSeleccionada.asObservable();
  
  private _loading = new BehaviorSubject<boolean>(false);
  public loading$: Observable<boolean> = this._loading.asObservable();
  
  private _error = new BehaviorSubject<string | null>(null);
  public error$: Observable<string | null> = this._error.asObservable();

  constructor() {
    this.personaUseCase = container.get<IPersonaUseCase>(TYPES.IPersonaUseCase);
  }

  async cargarPersonas(): Promise<void> {
    try {
      this._loading.next(true);
      this._error.next(null);
      const personas = await this.personaUseCase.getPersonas();
      this._personas.next(personas);
    } catch (error) {
      this._error.next('Error al cargar personas');
      console.error(error);
    } finally {
      this._loading.next(false);
    }
  }

  async seleccionarPersona(id: number): Promise<void> {
    try {
      this._loading.next(true);
      const persona = await this.personaUseCase.getPersona(id);
      this._personaSeleccionada.next(persona);
    } catch (error) {
      this._error.next('Error al cargar persona');
      console.error(error);
    } finally {
      this._loading.next(false);
    }
  }

  async crearPersona(persona: PersonaDTO): Promise<void> {
    try {
      this._loading.next(true);
      await this.personaUseCase.agregarPersona(persona);
      await this.cargarPersonas();
    } catch (error) {
      this._error.next('Error al crear persona');
      console.error(error);
    } finally {
      this._loading.next(false);
    }
  }

  async actualizarPersona(persona: PersonaDTO): Promise<void> {
    try {
      this._loading.next(true);
      await this.personaUseCase.actualizarPersona(persona);
      await this.cargarPersonas();
    } catch (error) {
      this._error.next('Error al actualizar persona');
      console.error(error);
    } finally {
      this._loading.next(false);
    }
  }

  async eliminarPersona(id: number): Promise<void> {
    try {
      this._loading.next(true);
      await this.personaUseCase.eliminarPersona(id);
      await this.cargarPersonas();
    } catch (error) {
      this._error.next('Error al eliminar persona');
      console.error(error);
    } finally {
      this._loading.next(false);
    }
  }

  limpiarSeleccion(): void {
    this._personaSeleccionada.next(null);
  }
}