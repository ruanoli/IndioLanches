using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IndioLanches.Models {
    public class Lanche {
        public int LancheId { get; set; }
        [Required(ErrorMessage = "Informe o nome do Lanche.")]
        [Display(Name = "Nome do Lanche")]
        [StringLength(80, MinimumLength = 1, ErrorMessage = "O nome deve ter no mínimo 1 caractere e 80 no máximo.")]
        public string? Nome { get; set; }
        [Required(ErrorMessage = "Informe o valor do Lanche.")]
        [Column(TypeName = "decimal (10, 2)")]
        [Display(Name ="Preço")]
        [Range(1,999.99, ErrorMessage ="O lanche deve ter o valor entre R$1,00 e R$1.999,99")]
        public decimal Preco { get; set; }
        [Required(ErrorMessage = "Informe a descrição do lanche.")]
        [Display(Name = "Descrição")]
        [StringLength(200,MinimumLength = 1, ErrorMessage = "A descrição deve ter no mínimo 1 caractere e 200 no máximo.")]      
        public string? DescricaoCurta { get; set; }

        [Required(ErrorMessage = "Informe a descrição do lanche.")]
        [Display(Name = "Descrição detalhada")]
        [StringLength(500, MinimumLength = 1, ErrorMessage = "A descrição deve ter no mínimo 1 caractere e 500 no máximo.")]
        public string? DescricaoLonga { get; set; }
        [Display(Name = "Caminho da imagem")]
        [StringLength(200, ErrorMessage = "Tamanho máximo de 200 caracteres.")]
        public string? ImagemUrl { get; set; }
        [Display(Name = "Caminho da imagem em miniatura")]
        [StringLength(200, ErrorMessage = "Tamanho máximo de 200 caracteres.")]
        public string? ImagemMiniaturaUrl { get; set; }
        [Display(Name = "Preferido?")]
        public bool LanchePreferido { get; set; }
        [Display(Name ="Possui em estoque?")]
        public bool EmEstoque { get; set; }

        public int CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }
    }
}
