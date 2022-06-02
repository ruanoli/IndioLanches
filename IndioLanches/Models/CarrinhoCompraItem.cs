using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IndioLanches.Models {
    public class CarrinhoCompraItem {
        public int CarrinhoCompraItemId { get; set; }
        public Lanche Lanche { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        [StringLength(200)]
        public string CarrinhoDeCompraId { get; set; } //será um GUID
    }
}
