using System.ComponentModel.DataAnnotations;

namespace Locadora.Models
{
    public class Filme
    {
        
        public int Id { get; set; }
        public string? Nome { get; set; }
        public decimal Preco { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Data de Empréstimo")]
        [CustomValidation(typeof(Filme), nameof(ValidarDataEmprestimo))]
        public DateTime Emprestimo { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Data de Devolução")]
        [CustomValidation(typeof(Filme), nameof(ValidarDataDevolucao))]
        public DateTime Devolucao { get; set; }

        public static ValidationResult ValidarDataEmprestimo(DateTime dataEmprestimo, ValidationContext context)
        {
            if (dataEmprestimo < DateTime.Now.Date)
            {
                return new ValidationResult("A data de empréstimo não pode ser anterior à data atual.");
            }
            return ValidationResult.Success;
        }

        public static ValidationResult ValidarDataDevolucao(DateTime dataDevolucao, ValidationContext context)
        {
            var instance = (Filme)context.ObjectInstance;
            if (dataDevolucao < instance.Emprestimo)
            {
                return new ValidationResult("A data de devolução não pode ser anterior à data de empréstimo.");
            }
            return ValidationResult.Success;
        }

        public int ProdId { get; set; }  
        public Produtora? Produtora { get; set; }
        public ICollection<Genero> Generos { get; set; } = new List<Genero>();
     
    }
}
