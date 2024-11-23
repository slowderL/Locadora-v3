using System.ComponentModel.DataAnnotations;

namespace Locadora.Models
{
    public class Genero
    {
        [Key]
        public int GenId { get; set; }
        public string? Nome { get; set; }
        public string? desc { get; set; }

        [DataCriacaoValida]
        public DateTime DtCriacao { get; set; } = DateTime.Now;

        public class DataCriacaoValidaAttribute : ValidationAttribute
        {
            public override bool IsValid(object value)
            {
                // Verifica se o valor é uma data e se é posterior à data atual
                if (value is DateTime dataCriacao)
                {
                    return dataCriacao <= DateTime.Now;
                }

                return false;
            }

            public override string FormatErrorMessage(string name)
            {
                return "A data de criação do gênero não pode ser posterior à data atual.";
            }
        }


    // Lista de filmes relacionados a este gênero
    public List<Filme> Filmes { get; set; } = new List<Filme>();
    }
}
