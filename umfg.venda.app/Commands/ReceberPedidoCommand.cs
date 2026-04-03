using System.Windows;
using umfg.venda.app.Abstracts;
using umfg.venda.app.UserControls;
using umfg.venda.app.ViewModels;

namespace umfg.venda.app.Commands
{
    internal sealed class ReceberPedidoCommand : AbstractCommand
    {
        public override bool CanExecute(object? parameter)
        {
            var vm = parameter as ListarProdutosViewModel;
            if (vm == null || vm.Pedido == null || vm.Pedido.Produtos == null) return false;

            return vm.Pedido.Produtos.Count > 0;
        }

        public override void Execute(object? parameter)
        {
            var vm = parameter as ListarProdutosViewModel;

            if (vm is null) return;

            if (vm.Pedido.Produtos == null || vm.Pedido.Produtos.Count == 0)
            {
                MessageBox.Show("Adicione ao menos um item no pedido antes de receber.");
                return;
            }

            ucReceberPedido.Exibir(vm.MainWindow, vm.Pedido);
        }
    }
}