using Data.Enum;
using System;

namespace Data.ModelDb
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public DateTime Nascimento { get; set; }
        public Perfil Perfil { get; set; }
        public DateTime Cadastro { get; set; }

        public Usuario()
        {
        }

        public Usuario(int id, string login, string nome, string senha, DateTime nascimento, Perfil perfil, DateTime cadastro)
        {
            Id = id;
            Login = login;
            Nome = nome;
            Senha = senha;
            Nascimento = nascimento;
            Perfil = perfil;
            Cadastro = cadastro;
        }
    }
}
