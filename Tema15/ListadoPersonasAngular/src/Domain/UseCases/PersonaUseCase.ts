import { IPersonaRepository } from '../Repositories/IPersonaRepository';
import { IPersonaUseCase } from '../Interfaces/IPersonaUseCase';
import { IDepartamentoRepository } from '../Repositories/IDepartamentoRepository';
import { Persona } from '../Entities/Persona';
import { PersonaDTO } from '../DTOs/PersonaDTO';
import { inject, injectable } from 'inversify';
import { TYPES } from '../../Core/Types';

@injectable()
export class PersonaUseCase implements IPersonaUseCase {
  constructor(
    @inject(TYPES.IPersonaRepository) private personaRepository: IPersonaRepository,
    @inject(TYPES.IDepartamentoRepository) private departamentoRepository: IDepartamentoRepository
  ) {}

  async getPersonas(): Promise<PersonaDTO[]> {
    const personas = await this.personaRepository.getPersonas();
    const departamentos = await this.departamentoRepository.getDepartamentos();
    
    return personas.map(persona => {
      const departamento = departamentos.find(d => d.id === persona.idDepartamento);
      return new PersonaDTO(
        persona.id,
        persona.nombre,
        persona.apellidos,
        persona.fechaNacimiento,
        persona.direccion,
        persona.telefono,
        persona.foto,
        persona.idDepartamento,
        departamento?.nombre || 'Sin departamento'
      );
    });
  }

  async getPersona(id: number): Promise<PersonaDTO> {
    const persona = await this.personaRepository.getPersona(id);
    const departamento = await this.departamentoRepository.getDepartamento(persona.idDepartamento);
    
    return new PersonaDTO(
      persona.id,
      persona.nombre,
      persona.apellidos,
      persona.fechaNacimiento,
      persona.direccion,
      persona.telefono,
      persona.foto,
      persona.idDepartamento,
      departamento?.nombre || 'Sin departamento'
    );
  }

  async agregarPersona(personaDTO: PersonaDTO): Promise<number> {
    const persona = new Persona(
      0,
      personaDTO.nombre,
      personaDTO.apellidos,
      personaDTO.fechaNacimiento,
      personaDTO.direccion,
      personaDTO.telefono,
      personaDTO.foto,
      personaDTO.idDepartamento
    );
    
    return await this.personaRepository.agregarPersona(persona);
  }

  async actualizarPersona(personaDTO: PersonaDTO): Promise<number> {
    const persona = new Persona(
      personaDTO.id,
      personaDTO.nombre,
      personaDTO.apellidos,
      personaDTO.fechaNacimiento,
      personaDTO.direccion,
      personaDTO.telefono,
      personaDTO.foto,
      personaDTO.idDepartamento
    );
    
    return await this.personaRepository.actualizarPersona(persona);
  }

  async eliminarPersona(id: number): Promise<number> {
    return await this.personaRepository.eliminarPersona(id);
  }
}