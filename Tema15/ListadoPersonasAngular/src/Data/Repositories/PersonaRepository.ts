import { injectable } from 'inversify';
import { IPersonaRepository } from '../../Domain/Repositories/IPersonaRepository';
import { Persona } from '../../Domain/Entities/Persona';
import { BaseApi } from '../API/BaseApi';

@injectable()
export class PersonaRepository extends BaseApi implements IPersonaRepository {
  
  async getPersonas(): Promise<Persona[]> {
    const response = await fetch(this.getUrl('api/personas'));
    
    if (!response.ok) {
      throw new Error(`Error al obtener personas: ${response.status}`);
    }
    
    const data = await response.json();
    
    return data.map((item: any) => {
      const p = item._persona;
      return new Persona(
        p.id,
        p.nombre,
        p.apellidos,
        new Date(p.fechaNacimiento),
        p.direccion,
        p.telefono,
        p.foto,
        p.idDepartamento
      );
    });
  }

  async getPersona(id: number): Promise<Persona> {
    const response = await fetch(this.getUrl(`api/personas/${id}`));
    
    if (!response.ok) {
      throw new Error(`Error al obtener persona: ${response.status}`);
    }
    
    const item = await response.json();
    const p = item._persona || item;
    
    return new Persona(
      p.id,
      p.nombre,
      p.apellidos,
      new Date(p.fechaNacimiento),
      p.direccion,
      p.telefono,
      p.foto,
      p.idDepartamento
    );
  }

  async agregarPersona(persona: Persona): Promise<number> {
    const response = await fetch(this.getUrl('api/personas'), {
      method: 'POST',
      headers: { 
        'Content-Type': 'application/json'
      },
      body: JSON.stringify({
        nombre: persona.nombre,
        apellidos: persona.apellidos,
        fechaNacimiento: persona.fechaNacimiento.toISOString(),
        direccion: persona.direccion,
        telefono: persona.telefono,
        foto: persona.foto,
        idDepartamento: persona.idDepartamento
      })
    });
    
    if (!response.ok) {
      throw new Error(`Error al crear persona: ${response.status}`);
    }
    
    return 1;
  }

  async actualizarPersona(persona: Persona): Promise<number> {
    const response = await fetch(this.getUrl(`api/personas/${persona.id}`), {
      method: 'PUT',
      headers: { 
        'Content-Type': 'application/json'
      },
      body: JSON.stringify({
        id: persona.id,
        nombre: persona.nombre,
        apellidos: persona.apellidos,
        fechaNacimiento: persona.fechaNacimiento.toISOString(),
        direccion: persona.direccion,
        telefono: persona.telefono,
        foto: persona.foto,
        idDepartamento: persona.idDepartamento
      })
    });
    
    if (!response.ok) {
      throw new Error(`Error al actualizar persona: ${response.status}`);
    }
    
    return 1;
  }

  async eliminarPersona(id: number): Promise<number> {
    const response = await fetch(this.getUrl(`api/personas/${id}`), {
      method: 'DELETE'
    });
    
    if (!response.ok) {
      throw new Error(`Error al eliminar persona: ${response.status}`);
    }
    
    return 1;
  }
}