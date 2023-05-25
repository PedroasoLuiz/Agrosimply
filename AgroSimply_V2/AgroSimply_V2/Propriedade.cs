using System.ComponentModel.DataAnnotations;

namespace AgroSimply_V2
{
    public class Propriedade
    {
        [Key]
        public int IdPropriedade { get; set; }
        public string Nome { get; set; }
        public string Cidade { get; set; }
        public string Cultura { get; set; }
        public string Localização { get; set; }
        public float Extensão { get; set; }
    }
}
