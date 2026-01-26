import { injectable } from 'inversify';
import { IDepartamentoRepository } from '../../Domain/Repositories/IDepartamentoRepository';
import { Departamento } from '../../Domain/Entities/Departamento';
import { BaseApi } from '../API/BaseApi';

@injectable()
export class DepartamentoRepository extends BaseApi implements IDepartamentoRepository {
  
  async getDepartamentos(): Promise<Departamento[]> {
    const response = await fetch(this.getUrl('api/departamentos'));
    const data = await response.json();
    
    return data.map((d: any) => new Departamento(d.id, d.nombre));
  }

  async getDepartamento(id: number): Promise<Departamento> {
    const response = await fetch(this.getUrl(`api/departamentos/${id}`));
    const data = await response.json();
    
    return new Departamento(data.id, data.nombre);
  }

  async agregarDepartamento(departamento: Departamento): Promise<number> {
    const response = await fetch(this.getUrl('api/departamentos'), {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify({
        nombre: departamento.nombre
      })
    });
    
    const data = await response.json();
    return data.id || 1;
  }

  async actualizarDepartamento(departamento: Departamento): Promise<number> {
    const response = await fetch(this.getUrl(`api/departamentos/${departamento.id}`), {
      method: 'PUT',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify({
        id: departamento.id,
        nombre: departamento.nombre
      })
    });
    
    return response.ok ? 1 : 0;
  }

  async eliminarDepartamento(id: number): Promise<number> {
    const response = await fetch(this.getUrl(`api/departamentos/${id}`), {
      method: 'DELETE'
    });
    
    return response.ok ? 1 : 0;
  }
}