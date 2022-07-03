import { Component, OnInit } from '@angular/core';
import { ClienteService } from '../services/cliente.service';
import { Cliente } from '../models/cliente';
import { Page } from 'src/app/models/Pagination';

@Component({
  selector: 'app-lista',
  templateUrl: './lista.component.html'
})
export class ListaComponent implements OnInit {

  public clientes: Cliente[];
  public page: Page<Cliente>;
  errorMessage: string;

  constructor(private clienteService: ClienteService) { }

  ngOnInit(): void {
    this.clienteService.obterTodos()
      .subscribe({
        next: (page) => {this.page = page,
          this.clientes = this.page.list
          console.log('teste1: ', this.clientes);},

        error: () => this.errorMessage
      });

  }
}
