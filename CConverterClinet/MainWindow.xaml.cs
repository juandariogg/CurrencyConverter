using CConverterClient.Components;
using CConverterClient.Utils;
using Microsoft.Extensions.Options;
using System;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CConverterClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(MainWindowViewModel vm)
        {
            InitializeComponent();
            this.DataContext = vm;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            (this.DataContext as IDisposable)?.Dispose();
            base.OnClosing(e);
        }
    }

    public class MainWindowViewModel : BaseViewModel
    {
        private readonly APIConsumer APIConsumer;
        public MainWindowViewModel(IOptions<APIConsumer> consumer)
        {
            Value = 0;
            APIConsumer = consumer.Value;
        }

        private Double _value;
        public Double Value
        {
            get { return _value; }
            set { _value = value; OnPropertyChanged(); }
        }

        private string? _dollarsValue;
        public string? DollarsValue
        {
            get { return _dollarsValue; }
            set { _dollarsValue = value; OnPropertyChanged(); }
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set { _isBusy = value; OnPropertyChanged(); }
        }

        public ICommand OnConvertClick => new ActionCommand(OnConvert, () => !IsBusy);


        private async Task OnConvert()
        {
            IsBusy = true;
            DollarsValue = await APIConsumer.Convert(Value) ?? "Error converting the value";
            IsBusy = false;
        }

        public override void Dispose()
        {
            APIConsumer?.Dispose();
        }
    }
}
