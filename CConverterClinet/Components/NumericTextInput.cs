using ModernWpf.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public double Value
        {
            get { return (double)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        public string Regex
        {
            get { return (string)GetValue(RegexProperty); }
            set { SetValue(RegexProperty, value); }
        }

        private static DependencyProperty MinValueProperty = DependencyProperty.Register("MinValue", typeof(double), typeof(NumericTextInput));
        private static DependencyProperty MaxValueProperty = DependencyProperty.Register("MaxValue", typeof(double), typeof(NumericTextInput));
        private static DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(double), typeof(NumericTextInput), new PropertyMetadata(ValuePropertyChanged));
        private static DependencyProperty RegexProperty = DependencyProperty.Register("Regex", typeof(string), typeof(NumericTextInput));

        private static void ValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var nb = (NumericTextInput)d;
            nb.Value = (double)e.NewValue;
        }

        private static Regex ValidateNumberOrComma = new Regex("^[0-9,\\,]");
        private Regex _inputValidationInstance;
        private Regex InputValidation
        {
            get 
            { 
                if (_inputValidationInstance == null) 
                    _inputValidationInstance = new Regex(Regex); 
                return _inputValidationInstance;
            }
        }

        protected override void OnPreviewTextInput(TextCompositionEventArgs e)
        {
            e.Handled = !ValidateNumberOrComma.IsMatch(e.Text);

            base.OnPreviewTextInput(e);
        }

        protected override void OnTextChanged(TextChangedEventArgs e)
        {
            if (InputValidation.IsMatch(this.Text) && CheckNumber(this.Text, out double result))
            {
                Value = result;
            }
            else
            {
                Text = Value.ToString();
            }

            base.OnTextChanged(e);
        }

        private bool CheckNumber(string value, out double parsed)
        {
            parsed = 0;

            if (!double.TryParse(value, out double result))
                return false;

            if (result >= MinValue && result <= MaxValue)
            {
                parsed = result;
                return true;
            }

            return false;
        }
    }
}
