namespace SinFTE.Models
{
    public class LogModel
    {
        public int Id_log { get; set; }
        public string Marcas { get; set; }
        public string Loja { get; set; }
        public string? Mensagem { get; set; }
        public int Qte_off { get; set; }
        public int Qte_caixas { get; set; }
        public int Indica_erro { get; set; }

        public DateTime Data_criacao { get; set; }

    }
}
