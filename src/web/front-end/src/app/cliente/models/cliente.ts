import { Endereco } from './endereco';

export class Cliente {
    id: string;
    nome: string;
    email: string;
    cpf: string;
    telefone: string;
    excluido: boolean;
    endereco: Endereco;
}

