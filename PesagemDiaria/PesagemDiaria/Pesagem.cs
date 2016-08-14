using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PesagemDiaria
{
    public class Pesagem
    {
        public Pesagem() { }

        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public DateTime data { get; set; }
        public int periodo { get; set; }
        public float peso { get; set; }
    }
}
