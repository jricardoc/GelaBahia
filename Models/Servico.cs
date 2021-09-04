using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.ComponentModel.DataAnnotations;

namespace GelaBahia.Models
{
    public class Servico
    {
        public int ID { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public int ClienteID { get; set; }
        public Cliente Cliente { get; set; }
        [Required]
        public DateTime DiaHora { get; set; }
        [Required]
        public float Valor { get; set; }   
        [Required]
        public string Tipo { get; set; }
        public int FuncionarioID { get; set; }
        public Funcionario Funcionario { get; set; }
        
        public string TipoManutencao { get; set; }
    }
}
