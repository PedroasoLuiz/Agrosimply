using System.ComponentModel.DataAnnotations;

namespace AgroSimply_V2
{
    public class Produtor
    {
        [Key]
        public string IdProdutor { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public string CNPJ { get; set; }
        private string Senha { get; set; }
        public string Atividade {
            get; set;
        }
    }
}
