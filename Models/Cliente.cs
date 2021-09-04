using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.ComponentModel.DataAnnotations;

namespace GelaBahia.Models
{
    public class Cliente
    {
        public int ID { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Endereco { get; set; }
        [Required]
        public string Telefone { get; set; }
        public string Descricao { get; set; }
        public string Tipo { get; set; }
    }
}
