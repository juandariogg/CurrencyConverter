using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CConverterClient.Components
{
    public class NumericTextInput : TextBox
    {
        public double? Value
        {
            get { return (double?)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        public double MinValue
        {
            get { return (double)GetValue(MinValueProperty); }
            set { SetValue(MinValueProperty, value); }
        }
        public double MaxValue
        {
            get { return (double)GetValue(MaxValueProperty); }
            set { SetValue(MaxValueProperty, value); }
        }
        public string Regex
        {
            get { return (string)GetValue(RegexProperty); }
            set { SetValue(RegexProperty, value); }
        }

        public static readonly DependencyProperty RegexProperty = DependencyProperty.Register("Regex", typeof(string), typeof(NumericTextInput));
        public static readonly DependencyProperty MinValueProperty = DependencyProperty.Register("MinValue", typeof(double), typeof(NumericTextInput));
        public static readonly DependencyProperty MaxValueProperty = DependencyProperty.Register("MaxValue", typeof(double), typeof(NumericTextInput));
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(double?), typeof(NumericTextInput), new PropertyMetadata(null, ValuePropertyChanged));

        private static Regex NumberOrComma = new Regex("^(\\d+|,)$");
        private Regex _inputMaskInstance;
        private Regex InputMask 
        {
            get 
            {
                if (_inputMaskInstance == null)
                    _inputMaskInstance = new Regex(Regex);
                return _inputMaskInstance;
            }
        }

        private static void ValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((NumericTextInput)d).ValuePropertyChanged((double?)e.NewValue);
        }

        private void ValuePropertyChanged(double? value)
        {
            Value = value;
        }


        protected override void OnPreviewTextInput(TextCompositionEventArgs e)
        {
            e.Handled = !NumberOrComma.IsMatch(e.Text);
            base.OnPreviewTextInput(e);
        }

        protected override void OnTextChanged(TextChangedEventArgs e)
        {
            if (!InputMask.IsMatch(Text) || !double.TryParse(Text, out double result) || !CheckInput(result))
            {
                e.Handled = true;
                Text = Value.ToString();
            }
            else
                Value = result;

            base.OnTextChanged(e);
        }

        private bool CheckInput(double? value)
        {
            return value >= MinValue && value <= MaxValue;
        }
    }
}
