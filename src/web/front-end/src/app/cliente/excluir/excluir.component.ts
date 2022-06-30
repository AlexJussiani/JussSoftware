import { Component } from '@angular/core';
import { Cliente } from '../models/cliente';

import { ActivatedRoute, Router } from '@angular/router';
import { ClienteService } from '../services/cliente.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-excluir',
  templateUrl: './excluir.component.html'
})
export class ExcluirComponent {

  cliente: Cliente = new Cliente();

  constructor(
    private clienteService: ClienteService,
    private route: ActivatedRoute,
    private router: Router,
    private toastr: ToastrService) {

    this.clienteService.obterPorId(route.params['id'])
      .subscribe(cliente => this.cliente = cliente);
  }

  excluirEvento() {
    this.clienteService.excluirCliente(this.cliente.id)
      .subscribe(
        evento => { this.sucessoExclusao(evento) },
        error => { this.falha() }
      );
  }

  sucessoExclusao(evento: any) {

    const toast = this.toastr.success('Cliente excluido com Sucesso!', 'Good bye :D');
    if (toast) {
      toast.onHidden.subscribe(() => {
        this.router.navigate(['/clientees/listar-todos']);
      });
    }
  }

  falha() {
    this.toastr.error('Houve um erro no processamento!', 'Ops! :(');
  }
}
