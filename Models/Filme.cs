using System.ComponentModel.DataAnnotations.Schema;

namespace Locadora.Models
{
    public class Filme
    {
        public int Id { get; set; }

        public string? Nome { get; set; }

        public string? Genero { get; set; }

        public decimal Preco { get; set; }

        public DateTime Emprestimo { get; set; } = DateTime.Now;


    }

}
