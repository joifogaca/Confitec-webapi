using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ConfitecApi.Model
{
    public class Escolaridade
    {

        public Escolaridade()
        {

        }

        public Escolaridade(int id, string descricao)
        {
            this.id = id;
            this.descricao = descricao;
        }

        public int id { get; set; }

        public string descricao { get; set; }
    }
}
