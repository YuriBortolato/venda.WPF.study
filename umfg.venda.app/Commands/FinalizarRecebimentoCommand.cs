using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using umfg.venda.app.Abstracts;
using umfg.venda.app.ViewModels;

namespace umfg.venda.app.Commands
{
    internal sealed class FinalizarRecebimentoCommand : AbstractCommand
    {
        public override void Execute(object? parameter)
        {
            var viewModel = parameter as ReceberPedidoViewModel;
            if (viewModel == null)
            {
                MessageBox.Show("Erro de sistema: Não foi possível ler os dados do formulário.");
                return;
            }

            List<string> erros = new List<string>();

            if (string.IsNullOrWhiteSpace(viewModel.NomeCartao) || viewModel.NomeCartao.Trim().Length < 3)
                erros.Add("- O Nome no Cartão deve ser preenchido por completo.");

            if (string.IsNullOrWhiteSpace(viewModel.CVV) || !Regex.IsMatch(viewModel.CVV, @"^\d{3}$"))
                erros.Add("- O CVV deve conter exatamente 3 dígitos numéricos.");

            if (viewModel.DataValidade == null)
            {
                erros.Add("- A data de validade é obrigatória.");
            }
            else
            {
                var ultimoDiaMesValidade = new DateTime(viewModel.DataValidade.Value.Year, viewModel.DataValidade.Value.Month, DateTime.DaysInMonth(viewModel.DataValidade.Value.Year, viewModel.DataValidade.Value.Month));

                if (ultimoDiaMesValidade.Date < DateTime.Now.Date)
                {
                    erros.Add("- A data de validade do cartão deve ser superior à data atual.");
                }
            }

            if (!ValidarCartaoLuhn(viewModel.NumeroCartao))
                erros.Add("- O número do cartão informado é inválido.");

            if (erros.Any())
            {
                MessageBox.Show("Atenção, pagamento recusado! Verifique os problemas:\n\n" + string.Join("\n", erros),
                                "Dados Incorretos", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            MessageBox.Show("Pagamento aprovado e finalizado com sucesso!", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);

            if (Application.Current.MainWindow is MainWindow mainWindow)
            {
                mainWindow.DataContext = new MainWindowViewModel();
            }
        }

        private bool ValidarCartaoLuhn(string numero)
        {
            if (string.IsNullOrWhiteSpace(numero)) return false;

            numero = Regex.Replace(numero, "[^0-9]", "");

            if (string.IsNullOrWhiteSpace(numero) || numero.Length < 13 || numero.Length > 19) return false;

            int soma = 0;
            bool alternar = false;
            for (int i = numero.Length - 1; i >= 0; i--)
            {
                int n = int.Parse(numero[i].ToString());
                if (alternar)
                {
                    n *= 2;
                    if (n > 9) n -= 9;
                }
                soma += n;
                alternar = !alternar;
            }
            return (soma % 10 == 0);
        }
    }
}