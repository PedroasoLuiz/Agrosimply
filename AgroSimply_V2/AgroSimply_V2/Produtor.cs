using System.ComponentModel.DataAnnotations;

namespace AgroSimply_V2
{
    public class Produtor
    {
        [Key]
        public int IdProdutor { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public int CPF { get; set; }
        public int CNPJ { get; set; }
        private string Senha { get; set; }
        public string Atividade {get; set;}
    }
}
