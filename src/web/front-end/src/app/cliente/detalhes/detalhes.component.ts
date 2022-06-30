import { Component } from '@angular/core';
import { Cliente } from '../models/cliente';

import { ActivatedRoute } from '@angular/router';
import { ClienteService } from '../services/cliente.service';

@Component({
  selector: 'app-detalhes',
  templateUrl: './detalhes.component.html'
})
export class DetalhesComponent {

  cliente: Cliente = new Cliente();

  constructor(
    private route: ActivatedRoute,
    private clienteService: ClienteService) {

      this.clienteService.obterPorId(route.params['id'])
      .subscribe(cliente => this.cliente = cliente);
  }
}
