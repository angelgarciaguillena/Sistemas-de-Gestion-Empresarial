import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { TablaPersonas } from './components/tabla-personas/tabla-personas'
import { FormularioPersona } from './components/formulario-persona/formulario-persona';
import { ListadoPersonas } from './components/listado-personas/listado-personas';
import { ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, TablaPersonas, FormularioPersona, ListadoPersonas, ReactiveFormsModule],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('holaMundoAngular');
}
