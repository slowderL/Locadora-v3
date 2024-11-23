using System.ComponentModel.DataAnnotations;

namespace Locadora.Models
{
    public class Produtora
    {
        [Key]
        public int ProdId { get; set; }
        public string? ProdNome { get; set; }
        public string? ProdCnpj { get; set; }
        public string? ProdEnd { get; set; }

        [DataCriacaoValida]
        public DateTime DtCriacao { get; set; } 

        public class DataCriacaoValidaAttribute : ValidationAttribute
        {
            public override bool IsValid(object value)
            {
                // Verifica se o valor é uma data e se é posterior à data atual
                if (value is DateTime dataCriacao)
                {
                    // Comparando a data sem considerar hora, minutos e segundos
                    return dataCriacao.Date <= DateTime.Today;
                }

                return false;
            }

            public override string FormatErrorMessage(string name)
            {
                return "A data de criação da produtora não pode ser posterior à data atual.";
            }
        }

        // Relacionamento com Filmes: Uma produtora tem muitos filmes
        public List<Filme> Filmes { get; set; } = new List<Filme>();  // Uma produtora pode ter vários filmes
    }
}
