using ApiCatalogo.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCatalogo.Models {
    [Table("Produtos")]
    public class Produto : IValidatableObject {
        [Key]
        public int ProdutoId { get; set; }
        [Required]
        [MaxLength(80)]
        [PrimeiraLetraMaiuscula]
        public string Nome { get; set; }
        [Required]
        [MaxLength(300)]
        public string Descricao { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [Range(1, 1000, ErrorMessage = "O preço deve estar entre {1} e {2}")]
        [Column(TypeName = "decimal(8,2)")]
        public decimal Preco { get; set; }
        [Required]
        [MaxLength(500)]
        public string ImageUrl { get; set; }
        public float Estoque { get; set; }
        public DateTime DataCadastro { get; set; }
        public Categoria Categoria { get; set; }
        public int CategoriaId { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) {
            if (!string.IsNullOrEmpty(this.Nome)) {
                var primeiraLetra = this.Nome[0].ToString();
                if (primeiraLetra != primeiraLetra.ToUpper()) {
                    yield return new ValidationResult("A primeira letra do produto deve ser maiúscula", new[] { nameof(this.Nome) });
                }
            }
        }
    }
}
