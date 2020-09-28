using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfitecApi.Model
{
    public class Usuario
    {
        public Usuario()
        {

        }
        public Usuario(int id, string nome, string sobrenome, string email, DateTime dataNascimento, int escolaridade)
        {
            this.id = id;
            this.nome = nome;
            this.sobrenome = sobrenome;
            this.email = email;
            this.dataNascimento = dataNascimento;
            this.escolaridadeId = escolaridade;

        }
        public int id { get; set; }

        public string nome { get; set; }

        public string sobrenome { get; set; }

        public string email { get; set; }

        public DateTime dataNascimento { get; set; }

        public Escolaridade Escolaridade { get; set; }

        public int escolaridadeId { get; set; }

    }
}
