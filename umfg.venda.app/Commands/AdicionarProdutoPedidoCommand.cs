using System;
using System.Linq;
using System.Windows;
using umfg.venda.app.Abstracts;
using umfg.venda.app.ViewModels;

namespace umfg.venda.app.Commands
{
    internal sealed class AdicionarProdutoPedidoCommand : AbstractCommand
    {
        public override bool CanExecute(object? parameter)
        {
            var vm = parameter as ListarProdutosViewModel;
            if (vm == null || vm.ProdutoSelecionado == null) return false;

            if (string.IsNullOrWhiteSpace(vm.ProdutoSelecionado.Referencia)) return false;

            return true;
        }

        public override void Execute(object? parameter)
        {
            var vm = parameter as ListarProdutosViewModel;

            if (vm is null || vm.Pedido is null)
            {
                MessageBox.Show("Falha ao carregar o contexto do sistema.");
                return;
            }

            if (vm.ProdutoSelecionado is null || string.IsNullOrWhiteSpace(vm.ProdutoSelecionado.Referencia))
            {
                MessageBox.Show("Nenhum produto selecionado na lista! Clique em um item primeiro.");
                return;
            }

            var result = MessageBox.Show("Deseja realmente incluir este item no carrinho?", "Confirmar", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                vm.Pedido.Produtos.Add(vm.ProdutoSelecionado);
                vm.Pedido.Total = vm.Pedido.Produtos.Sum(x => x.Valor);
                vm.RaiseCanExecuteChanged();
            }
        }
    }
}