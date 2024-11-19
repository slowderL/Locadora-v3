using System.ComponentModel.DataAnnotations;

namespace Locadora.Models
{
    public class Genero
    {
        [Key]
        public int GenId { get; set; }
        public string Nome { get; set; }
        public string desc { get; set; }
        public DateTime DtCriacao { get; set; } = DateTime.Now;

    }
}
