using System;
using System.Collections.Generic;
using System.Text;

namespace Data.ModelDb
{
    public class ExceptionFull
    {
        public int Id { get; set; }
        public string Projeto { get; set; }
        public string Classe { get; set; }
        public string Metodo { get; set; }
        public string Mensagem { get; set; }
        public bool Status { get; set; }
        public DateTime Data { get; set; }
        public Usuario Usuario { get; set; }
        public int? UsuarioId { get; set; }

        public ExceptionFull()
        {
        }

        public ExceptionFull(string projeto, string classe, string metodo, string mensagem, bool status, DateTime data, int? usuarioId)
        {
            Projeto = projeto;
            Classe = classe;
            Metodo = metodo;
            Mensagem = mensagem;
            Status = status;
            Data = data;
            UsuarioId = usuarioId;
        }
    }
}
