import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { Departamento } from '../../Domain/Entities/Departamento';
import { IDepartamentoUseCase } from '../../Domain/Interfaces/IDepartamentoUseCase';
import { container } from '../../Core/Container';
import { TYPES } from '../../Core/Types';

@Injectable({
  providedIn: 'root'
})
export class DepartamentosViewModel {
  private departamentoUseCase: IDepartamentoUseCase;
  
  private _departamentos = new BehaviorSubject<Departamento[]>([]);
  public departamentos$: Observable<Departamento[]> = this._departamentos.asObservable();
  
  private _departamentoSeleccionado = new BehaviorSubject<Departamento | null>(null);
  public departamentoSeleccionado$: Observable<Departamento | null> = this._departamentoSeleccionado.asObservable();
  
  private _loading = new BehaviorSubject<boolean>(false);
  public loading$: Observable<boolean> = this._loading.asObservable();
  
  private _error = new BehaviorSubject<string | null>(null);
  public error$: Observable<string | null> = this._error.asObservable();

  constructor() {
    this.departamentoUseCase = container.get<IDepartamentoUseCase>(TYPES.IDepartamentoUseCase);
  }

  async cargarDepartamentos(): Promise<void> {
    try {
      this._loading.next(true);
      this._error.next(null);
      const departamentos = await this.departamentoUseCase.getDepartamentos();
      this._departamentos.next(departamentos);
    } catch (error) {
      this._error.next('Error al cargar departamentos');
      console.error(error);
    } finally {
      this._loading.next(false);
    }
  }

  async seleccionarDepartamento(id: number): Promise<void> {
    try {
      this._loading.next(true);
      const departamento = await this.departamentoUseCase.getDepartamento(id);
      this._departamentoSeleccionado.next(departamento);
    } catch (error) {
      this._error.next('Error al cargar departamento');
      console.error(error);
    } finally {
      this._loading.next(false);
    }
  }

  async crearDepartamento(departamento: Departamento): Promise<void> {
    try {
      this._loading.next(true);
      await this.departamentoUseCase.agregarDepartamento(departamento);
      await this.cargarDepartamentos();
    } catch (error) {
      this._error.next('Error al crear departamento');
      console.error(error);
    } finally {
      this._loading.next(false);
    }
  }

  async actualizarDepartamento(departamento: Departamento): Promise<void> {
    try {
      this._loading.next(true);
      await this.departamentoUseCase.actualizarDepartamento(departamento);
      await this.cargarDepartamentos();
    } catch (error) {
      this._error.next('Error al actualizar departamento');
      console.error(error);
    } finally {
      this._loading.next(false);
    }
  }

  async eliminarDepartamento(id: number): Promise<void> {
    try {
      this._loading.next(true);
      await this.departamentoUseCase.eliminarDepartamento(id);
      await this.cargarDepartamentos();
    } catch (error) {
      this._error.next('Error al eliminar departamento');
      console.error(error);
    } finally {
      this._loading.next(false);
    }
  }

  limpiarSeleccion(): void {
    this._departamentoSeleccionado.next(null);
  }
}