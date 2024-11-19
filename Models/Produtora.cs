using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;

namespace Locadora.Models
{
    public class Produtora
    {
        [Key]
        public int ProdId { get; set; }
        public string ProdNome { get; set; }
        public string? ProdCnpj { get; set; }
        public string? ProdEnd { get; set; }

    }
}
