using IndioLanches.Context;
using IndioLanches.Migrations;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace IndioLanches.Models {
    public class CarrinhoCompra {
        private readonly AppDbContext _context;
        public CarrinhoCompra(AppDbContext context) {
            _context = context;
        }
        public string CarrinhoCompraId { get; set; } //GUID
        public List<CarrinhoCompraItem> CarrinhoCompraItems { get; set; }

        //Método importante para obter os carrinhos que o cliente criou na sessão:
        //se o carrinho não existir, eu crio, se ele existir eu obtenho o carrinho.
        public static CarrinhoCompra GetCarrinho(IServiceProvider service) {

            //Define uma sessão
            //se IHttpContextAccessor não for null,
            //eu irei obter uma Session e irei retornar na var session.
            ISession session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            //Obtem um serviço do tipo do nosso contexto.
            var context = service.GetService<AppDbContext>();

            //se session.GetString("CarrinhoId") for null, será criado um novo Guid na variável carrinho id
            string carrinhoId = session.GetString("CarrinhoId")??Guid.NewGuid().ToString();

            //atribui o id do carrinho na sessão.
            session.SetString("CarrinhoId", carrinhoId);

            return new CarrinhoCompra(context) {
                CarrinhoCompraId = carrinhoId
            };
        }


        public void AdicionarAoCarrinho(Lanche lanche) {
            //obtem o item pelo id do lanche e o id do carrinho.
            //se eu conseguir obter o item significa que ele já existe.
            var carrinhoCompraItem = _context.CarrinhoCompraItens
                                             .SingleOrDefault(x => x.Lanche.LancheId == lanche.LancheId &&
                                             x.CarrinhoDeCompraId == CarrinhoCompraId);

            //se for null eu adiociono o Id, o lanche e atribuo a quantidade =1.
            if (carrinhoCompraItem == null) {
                carrinhoCompraItem = new CarrinhoCompraItem {
                    CarrinhoDeCompraId = CarrinhoCompraId,
                    Lanche = lanche,
                    Quantidade = 1
                };
                _context.CarrinhoCompraItens.Add(carrinhoCompraItem);
            } 
            //se o item já existir apenas incrementa a quantidade no carrinho.
            else {
                carrinhoCompraItem.Quantidade++;
            }
            _context.SaveChanges();
        }

        public void RemoverDoCarrinho(Lanche lanche) {
            var carrinhoCompraItem = _context.CarrinhoCompraItens
                                             .SingleOrDefault(x => x.Lanche.LancheId == lanche.LancheId
                                             && x.CarrinhoDeCompraId == CarrinhoCompraId);

            //int quantLocal = 0;
            if(carrinhoCompraItem != null) {
                if (carrinhoCompraItem.Quantidade > 1) { 
                    carrinhoCompraItem.Quantidade--;
                   // quantLocal = carrinhoCompraItem.Quantidade;
                }
                else {
                    _context.CarrinhoCompraItens.Remove(carrinhoCompraItem);
                }
            }
            _context.SaveChanges();
            //return quantLocal;
        }
    
        public List<CarrinhoCompraItem> GetCarrinhoCompraItens() {
            return CarrinhoCompraItems??(CarrinhoCompraItems =
                _context.CarrinhoCompraItens
                .Where(x => x.CarrinhoDeCompraId == CarrinhoCompraId)
                .Include(x => x.Lanche)
                .ToList());
        }

        public void LimparCarrinho() {
            var carrinho = _context.CarrinhoCompraItens
                .Where(x => x.CarrinhoDeCompraId == CarrinhoCompraId);

            _context.RemoveRange(carrinho);
            _context.SaveChanges();
        }
        
        //Valor total dos itens
        public decimal GetCarrinhoCompraTotal() {
            var total = _context.CarrinhoCompraItens
                .Where(x => x.CarrinhoDeCompraId == CarrinhoCompraId)
                .Select(x => x.Lanche.Preco * x.Quantidade).Sum();

            return total;
        }
    }
}

