import { PagedViewModel } from './../../../../models/PagedViewModel';
import { ContasService } from './../../../../services/contas.service';
import { Component, OnInit, TemplateRef } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { Conta } from 'src/app/models/conta';

@Component({
  selector: 'app-pagar-lista',
  templateUrl: './pagar-lista.component.html',
  styleUrls: ['./pagar-lista.component.scss']
})
export class PagarListaComponent implements OnInit {

  private page: PagedViewModel<Conta>;
  private contas: Conta[];

  constructor(
    private spinner: NgxSpinnerService,
    private contasServices: ContasService
  ) { }

  ngOnInit() {
    console.log('teste')
    this.page = {
      pageIndex: 1,
      pageSize: 8,
      totalResults: 1
    } as PagedViewModel<Conta>;

    this.carregarContas();
  }

  public filtrarContas(evt: any): void {

  }

  public carregarContas(): void{
    this.spinner.show();
    this.contasServices
      .getContasPagar(this.page.pageIndex, this.page.pageSize)
      .subscribe(
        res => {this.page = res
        this.contas = this.page.list
       });
       console.log(JSON.stringify(this.contas));
  }

  openModal(event: any, template: TemplateRef<any>, eventoId: number): void {
    // event.stopPropagation();
    // this.eventoId = eventoId;
    // this.modalRef = this.modalService.show(template, { class: 'modal-sm' });
  }

}
