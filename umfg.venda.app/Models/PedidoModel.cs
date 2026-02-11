using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace umfg.venda.app.Models
{
    public sealed class PedidoModel
    {
        private Guid _id = Guid.NewGuid();
        private decimal _total = 0.0m;
        private ObservableCollection<ProdutoModel> _produtos = [];

        public Guid Id { get => _id; set => _id = value; }
        public decimal Total { get => _total; set => _total = value; }

        public ObservableCollection<ProdutoModel> Produtos
            { get => _produtos; set => _produtos = value; }
    }
}
