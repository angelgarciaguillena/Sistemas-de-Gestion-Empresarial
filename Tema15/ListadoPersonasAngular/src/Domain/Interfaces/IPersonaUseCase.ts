import { PersonaDTO } from "../DTOs/PersonaDTO.js";

export interface IPersonaUseCase {
  getPersonas(): Promise<PersonaDTO[]>;
  getPersona(id: number): Promise<PersonaDTO>;
  agregarPersona(persona: PersonaDTO): Promise<number>;
  actualizarPersona(persona: PersonaDTO): Promise<number>;
  eliminarPersona(id: number): Promise<number>;
}