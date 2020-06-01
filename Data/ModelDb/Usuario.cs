using Data.Enum;
using System;
using System.Collections.Generic;

namespace Data.ModelDb
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Nome { get; set; }
        public DateTime Nascimento { get; set; }
        public Perfil Perfil { get; set; }
        public DateTime Cadastro { get; set; }
        public List<Senha> Senhas { get; set; }

        public Usuario()
        {
        }

        public Usuario(int id, string login, string nome, DateTime nascimento, Perfil perfil, DateTime cadastro, List<Senha> senhas)
        {
            Id = id;
            Login = login;
            Nome = nome;
            Nascimento = nascimento;
            Perfil = perfil;
            Cadastro = cadastro;
            Senhas = senhas;
        }
    }
}
