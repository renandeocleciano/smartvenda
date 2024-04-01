using System;

namespace SmartVendas.Domain.Entities
{
    public class Usuario
    {
        public Usuario()
        {
            UsuarioId = Guid.NewGuid();
        }
        public Guid UsuarioId { get; set; }

        public string Email { get; set; }
        
        public string UserName { get; set; }
        public string Senha { get; set; }

        //Dados Para Cadastro do Colaborador

        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public string Logradouro { get; set; }
        public string Cep { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Complemento { get; set; }

        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }


        public Guid TipoUsuarioId { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
    }
}
