export class UsuarioRegistro {
  nome: string;
  cpf: string;
  email: string;
  senha: string;
  senhaConfirmacao: string;
}

export class UsuarioLogin {
  email: string;
  senha: string;
}

export class UsuarioRespostaLogin {
  accessToken: string;
  refreshToken: string;
  expiresIn: number;
  usuarioToken: UsuarioToken;
}

export class UsuarioToken {
  id: string;
  email: string;
}

export class UsuarioClaim {
  Value: string;
  Type: string;
}
