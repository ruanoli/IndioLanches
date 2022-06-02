using System.ComponentModel.DataAnnotations;

namespace IndioLanches.Models {
    public class Categoria {
        public int CategoriaId { get; set; }
        [Required(ErrorMessage ="Informe a categoria do lanche.")]
        [StringLength(100, ErrorMessage = "Tamanho máximo de 100 caracteres")]
        [Display(Name = "Categoria")]
        public string? Nome { get; set; }
  
        [StringLength(300, ErrorMessage = "Tamanho máximo de 300 caracteres")]
        [Display(Name = "Descrição da categoria")]
        public string? Descricao { get; set; }
        public IList<Lanche>? Lanches { get; set; }
    }
}
