import { injectable } from 'inversify';
import { IPersonaRepository } from '../../Domain/Repositories/IPersonaRepository';
import { Persona } from '../../Domain/Entities/Persona';
import { BaseApi } from '../API/BaseApi';

@injectable()
export class PersonaRepository extends BaseApi implements IPersonaRepository {
  
  async getPersonas(): Promise<Persona[]> {
    const response = await fetch(this.getUrl('personas'));
    const data = await response.json();
    
    return data.map((p: any) => new Persona(
      p.id,
      p.nombre,
      p.apellidos,
      new Date(p.fechaNacimiento),
      p.direccion,
      p.telefono,
      p.foto,
      p.idDepartamento
    ));
  }

  async getPersona(id: number): Promise<Persona> {
    const response = await fetch(this.getUrl(`personas/${id}`));
    const data = await response.json();
    
    return new Persona(
      data.id,
      data.nombre,
      data.apellidos,
      new Date(data.fechaNacimiento),
      data.direccion,
      data.telefono,
      data.foto,
      data.idDepartamento
    );
  }

  async agregarPersona(persona: Persona): Promise<number> {
    const response = await fetch(this.getUrl('personas'), {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify({
        nombre: persona.nombre,
        apellidos: persona.apellidos,
        fechaNacimiento: persona.fechaNacimiento,
        direccion: persona.direccion,
        telefono: persona.telefono,
        foto: persona.foto,
        idDepartamento: persona.idDepartamento
      })
    });
    
    const data = await response.json();
    return data.id || 1;
  }

  async actualizarPersona(persona: Persona): Promise<number> {
    const response = await fetch(this.getUrl(`personas/${persona.id}`), {
      method: 'PUT',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify({
        id: persona.id,
        nombre: persona.nombre,
        apellidos: persona.apellidos,
        fechaNacimiento: persona.fechaNacimiento,
        direccion: persona.direccion,
        telefono: persona.telefono,
        foto: persona.foto,
        idDepartamento: persona.idDepartamento
      })
    });
    
    return response.ok ? 1 : 0;
  }

  async eliminarPersona(id: number): Promise<number> {
    const response = await fetch(this.getUrl(`personas/${id}`), {
      method: 'DELETE'
    });
    
    return response.ok ? 1 : 0;
  }
}