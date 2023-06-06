using System.ComponentModel.DataAnnotations;

namespace SinFTE.Models
{
    public class LogCard
    {
        [Key]
        public string Marcas { get; set; }
        public int Qte_off { get; set; }
        public int Qte_on { get; set; }
        public int Data_criacao { get; set; }


    }
}
