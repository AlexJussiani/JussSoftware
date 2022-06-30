import { Endereco } from './endereco';

export class Cliente {
    id: string;
    nome: string;
    email: string;
    documento: string;
    telefone: string;
    excluido: boolean;
    endereco: Endereco;
    tipoCliente: string;
}

