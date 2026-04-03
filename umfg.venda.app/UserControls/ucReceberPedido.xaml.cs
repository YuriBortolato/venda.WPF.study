using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using umfg.venda.app.Interfaces;
using umfg.venda.app.Models;
using umfg.venda.app.ViewModels;

namespace umfg.venda.app.UserControls
{
    public partial class ucReceberPedido : UserControl
    {
        private ucReceberPedido(IObserver observer, PedidoModel pedido)
        {
            InitializeComponent();
            DataContext = new ReceberPedidoViewModel(this, observer, pedido);
        }

        internal static void Exibir(IObserver observer, PedidoModel pedido)
        {
            (new ucReceberPedido(observer, pedido).DataContext as ReceberPedidoViewModel).Notify();
        }

        private void DatePicker_CalendarOpened(object sender, RoutedEventArgs e)
        {
            var datepicker = sender as DatePicker;
            if (datepicker != null)
            {
                var popup = (Popup)datepicker.Template.FindName("PART_Popup", datepicker);
                if (popup != null && popup.Child is Calendar calendar)
                {
                    calendar.DisplayModeChanged -= Calendar_DisplayModeChanged;
                    calendar.DisplayModeChanged += Calendar_DisplayModeChanged;

                    calendar.DisplayMode = CalendarMode.Year;
                }
            }
        }

        private void Calendar_DisplayModeChanged(object sender, CalendarModeChangedEventArgs e)
        {
            var calendar = sender as Calendar;
            if (calendar != null && calendar.DisplayMode == CalendarMode.Month)
            {
                calendar.DisplayModeChanged -= Calendar_DisplayModeChanged;

                calendar.SelectedDate = new DateTime(calendar.DisplayDate.Year, calendar.DisplayDate.Month, 1);

                dpValidade.IsDropDownOpen = false;

                calendar.DisplayMode = CalendarMode.Year;
            }
        }

        
        private void dpValidade_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dpValidade.SelectedDate.HasValue)
            {
                DateTime data = dpValidade.SelectedDate.Value;

                Dispatcher.BeginInvoke(new Action(() =>
                {
                    dpValidade.Text = data.ToString("MM/yyyy");
                }), System.Windows.Threading.DispatcherPriority.ContextIdle);
            }
        }
    }
}