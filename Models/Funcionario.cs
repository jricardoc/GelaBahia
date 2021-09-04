using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.ComponentModel.DataAnnotations;

namespace GelaBahia.Models
{
    public class Funcionario
    {
        public int ID { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string CPF { get; set; }
        [Required]
        public float Salario { get; set; }
        [Required]
        public bool Disponivel { get; set; }
        public float Comissao { get; set; }
        
    }
}
