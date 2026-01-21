export interface IPersonaUseCase {
  getPersonas(): Promise<PersonaDTO[]>;
}