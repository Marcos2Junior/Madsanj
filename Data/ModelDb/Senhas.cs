using Data.Enum;
using System;

namespace Data.ModelDb
{
    public class Senha
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Arquivo { get; set; }
        public TipoSenha TipoSenha { get; set; }
        public DateTime DataRegistro { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public Senha()
        {
        }

        public Senha(int id, string nome, string arquivo, TipoSenha tipoSenha, DateTime dataRegistro, Usuario usuario)
        {
            Id = id;
            Nome = nome;
            Arquivo = arquivo;
            TipoSenha = tipoSenha;
            DataRegistro = dataRegistro;
            Usuario = usuario;
        }
    }
}
