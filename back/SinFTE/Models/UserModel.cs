namespace SinFTE.Models
{
    public class UserModel
    {
        public int Id_usuario { get; set; }
        public string? Nome_completo { get; set; }
        public string? Senha { get; set; }
        public string? Email { get; set; }
        public int Inativo { get; set; }

    }
}
