using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using umfg.venda.app.Abstracts;
using umfg.venda.app.Models;

namespace umfg.venda.app.ViewModels
{
    internal sealed class ListarProdutosViewModel : AbstractViewModel
    {
        private ProdutoModel _produtoSelecionado = new();
        private ObservableCollection<ProdutoModel> _produtos = [];

        public ProdutoModel ProdutoSelecionado
        {
            get => _produtoSelecionado;
            set => SetField(ref _produtoSelecionado, value);
        }

        public ObservableCollection<ProdutoModel> Produtos
        {
            get => _produtos;
            set => SetField(ref _produtos, value);
        }

        public ListarProdutosViewModel() : base("Produtos")
        {
            CarregarProdutos();
        }

        private void CarregarProdutos()
        {
            Produtos.Clear();

            Produtos.Add(new ProdutoModel()
            {
                Imagem = new BitmapImage(
                    new Uri(@"..\net-8.0-windows\Images\batata.png", UriKind.Relative)),
                Descricao = "Batata Frita 300gr",
                Referencia = "0001",
                Valor = 10.90m,
            });

            Produtos.Add(new ProdutoModel()
            {
                Imagem = new BitmapImage(
                    new Uri(@"..\net-8.0-windows\Images\combo.png", UriKind.Relative)),
                Descricao = "Combo Big Mac + Batata 300gr + Refil 500ML",
                Referencia = "0002",
                Valor = 49.90m,
            });

            Produtos.Add(new ProdutoModel()
            {
                Imagem = new BitmapImage(
                    new Uri(@"..\net-8.0-windows\Images\lanche.png", UriKind.Relative)),
                Descricao = "Big Mac 350gr",
                Referencia = "0003",
                Valor = 25.90m,
            });

            Produtos.Add(new ProdutoModel()
            {
                Imagem = new BitmapImage(
                    new Uri(@"..\net-8.0-windows\Images\refrigerante.png", UriKind.Relative)),
                Descricao = "Regrigerante Refil 500ml",
                Referencia = "000                         4",
                Valor = 10.90m,
            });
        }
    }
}
