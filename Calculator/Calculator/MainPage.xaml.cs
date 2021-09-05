using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Calculator
{
    public partial class MainPage : ContentPage
    {
        Model model;
        Dictionary<string, Operation> operations;
        public MainPage()
        {

            model = new Model();
            operations = new Dictionary<string, Operation>();

            operations["+"] = Model.ADD;
            operations["-"] = Model.SUB;
            operations["*"] = Model.MUL;
            operations["÷"] = Model.DIV;
            operations["√"] = Model.SQR;
            operations["%"] = Model.PRC;
            operations["X2"] = Model.DBL;

            InitializeComponent();
            BindingContext = model;

            for (int i = 1; i < 10; i++)
            {
                int offset = i - 1;

                Button btn = new Button
                {
                    Text = i.ToString()
                };

                int col = offset % 3;
                int row = 4 - offset / 3;

                CalcGrid.Children.Add(
                    btn,
                    col,
                    row
                );
            }

            foreach (var child in CalcGrid.Children)
            {
                if (!(child is Button)) continue;

                int column = Grid.GetColumn(child);
                child.SetDynamicResource(StyleProperty, column == 3 ? "Right" : "Left");

                Button btn = child as Button;
                if (!int.TryParse(btn.Text, out _))
                {
                    btn.Clicked += HandleOpClick;
                }
                else
                {
                    btn.Clicked += HandleNumClick;
                }
            }


        }

        private void HandleOpClick(object sender, EventArgs e)
        {
            if (!(sender is Button)) return;
            Button btn = sender as Button;

            bool valid = operations.TryGetValue(btn.Text, out Operation tempOp);
            bool isPerc = btn.Text.Equals("%");

            if (!valid) return;

            model.Op = tempOp;

            if(isPerc)
            {
                model.SecondNum = LabelAsDecimal;
                resultText.Text = model?.Calculate().ToString() ?? "0";
                return;
            }
            else
            {
                model.FirstNum = LabelAsDecimal;
            }

            if(model.Op is SingleArgumentOperation)
            {
                resultText.Text = model?.Calculate().ToString() ?? "0";
                model.Reset();
                return;
            }

            resultText.Text = "0";
        }

        private void HandleNumClick(object sender, EventArgs e)
        {
            int num = Convert.ToInt32((sender as Button).Text);
            if (resultText.Text.Equals("0"))
            {
                resultText.Text = num.ToString();
                return;
            }
            resultText.Text += num.ToString();
        }

        private void HandleEqualsClick(object sender, EventArgs e)
        {
            model.SecondNum = LabelAsDecimal;
            resultText.Text = model?.Calculate().ToString() ?? "0";
            model.Reset();
        }

        private void HandleClear(object sender, EventArgs e)
        {
            model.Reset();
            resultText.Text = "0";
        }

        private decimal LabelAsDecimal => Convert.ToDecimal(resultText.Text);
    }
}
