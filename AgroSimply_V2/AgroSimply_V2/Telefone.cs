using System.ComponentModel.DataAnnotations;

namespace AgroSimply_V2
{
    public class Telefone
    {
        [Key]
        public int IdTel { get; set; }
        public int ProdutorId { get; set; }

        public int Numero { get; set; }
        public string Tipo { get; set; }
    }
}
