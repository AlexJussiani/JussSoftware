import { ItensConta } from "./itensConta"

export class Conta {
  id: string
  codigo: number
  clienteId: string
  valorTotal: number
  dataRegistro: string
  dataVencimento: string
  tipoConta: number
  statusConta: number
  itensConta: ItensConta[]
}

