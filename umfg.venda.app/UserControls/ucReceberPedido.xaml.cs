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
            DatePicker datepicker = sender as DatePicker;
            if (datepicker != null)
            {
                Popup popup = (Popup)datepicker.Template.FindName("PART_Popup", datepicker);
                if (popup != null && popup.Child is Calendar calendar)
                {
                    calendar.DisplayMode = CalendarMode.Year;

                    calendar.DisplayModeChanged -= Calendar_DisplayModeChanged;
                    calendar.DisplayModeChanged += Calendar_DisplayModeChanged;
                }
            }
        }

        private void Calendar_DisplayModeChanged(object sender, CalendarModeChangedEventArgs e)
        {
            Calendar calendar = sender as Calendar;
            if (calendar != null && calendar.DisplayMode == CalendarMode.Month)
            {
                calendar.SelectedDate = calendar.DisplayDate;
                dpValidade.IsDropDownOpen = false;
                calendar.DisplayMode = CalendarMode.Year;
            }
        }

        private void DatePicker_CalendarClosed(object sender, RoutedEventArgs e)
        {
            var datepicker = sender as DatePicker;
            if (datepicker != null && datepicker.SelectedDate.HasValue)
            {
                DateTime selected = datepicker.SelectedDate.Value;
                datepicker.SelectedDate = new DateTime(selected.Year, selected.Month, 1);
            }
        }
    }
}