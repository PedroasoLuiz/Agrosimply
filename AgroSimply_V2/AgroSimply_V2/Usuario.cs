using System.ComponentModel.DataAnnotations;

namespace AgroSimply_V2
{
    public class Usuario
    {
        [Key]
        public string IdUsuario { get; set; }
        public int ProdutorId { get; set; }
        public string CPF { get; set; }
        private string Senha { get; set; }
        public int Tipo { get; set; }
    }
}
