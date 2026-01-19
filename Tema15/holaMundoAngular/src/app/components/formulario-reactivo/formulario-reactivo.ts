import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-formulario-reactivo',
  imports: [ReactiveFormsModule],
  templateUrl: './formulario-reactivo.html',
  styleUrl: './formulario-reactivo.css',
})
export class FormularioReactivoComponent implements OnInit {

  formulario!: FormGroup;

  constructor() {

  }

  ngOnInit(): void {

    this.formulario=new FormGroup({

      nombre: new FormControl('',[]),

      apellidos:new FormControl('',[])

    });
  }

  saluda(){
    if (this.formulario.valid){
      alert('Hola ' + this.formulario.controls['nombre'].value + ' ' + this.formulario.controls['apellidos'].value);
    }
  }
}