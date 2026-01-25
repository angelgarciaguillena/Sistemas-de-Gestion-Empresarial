import { Persona } from '../Entities/Persona';

export interface IPersonaRepository {
  getPersonas(): Promise<Persona[]>;
  getPersona(id: number): Promise<Persona>;
  agregarPersona(persona: Persona): Promise<number>;
  actualizarPersona(persona: Persona): Promise<number>;
  eliminarPersona(id: number): Promise<number>;
}