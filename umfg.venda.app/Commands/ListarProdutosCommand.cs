using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using umfg.venda.app.Abstracts;
using umfg.venda.app.UserControls;
using umfg.venda.app.ViewModels;

namespace umfg.venda.app.Commands;

internal sealed class ListarProdutosCommand : AbstractCommand
{
    public override void Execute(object? parameter)
    {
        ucListarProdutos.Show(parameter as MainWindowViewModel);
    }
}