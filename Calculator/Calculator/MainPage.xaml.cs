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
            operations = new Dictionary<string, Operation>
            {
                { "+", Model.ADD },
                { "-", Model.SUB },
                { "*", Model.MUL },
                { "÷", Model.DIV },

                { "√", Model.SQR },
                { "%", Model.PRC },
            };

            InitializeComponent();
            for (int i = 1; i < 10; i++)
            {
                int offset = i - 1;

                Button btn = new Button
                {
                    Text = i.ToString()
                };

                btn.Clicked += HandleNumClick;

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
                if (child.GetType() != typeof(Button)) continue;

                int column = Grid.GetColumn(child);
                child.SetDynamicResource(StyleProperty, column == 3 ? "Right" : "Left");

                Button btn = child as Button;
                if(!int.TryParse(btn.Text, out _))
                {
                    btn.Clicked += (s, e) => operations.TryGetValue(btn.Text, out model.Op);
                }
            }


        }

        private void HandleNumClick(object sender, EventArgs e)
        {
            int num = Convert.ToInt32((sender as Button).Text);
            if(resultText.Text.Equals("0"))
            {
                resultText.Text = num.ToString();
                return;
            }
            resultText.Text += num.ToString();
        }

        private void HandleEqualsClick(object sender, EventArgs e)
        {
            model.SecondNum = Convert.ToDecimal(resultText.Text);
            resultText.Text = model?.Calculate().ToString() ?? "0";
            model.Reset();
        }

        private void HandleClear(object sender, EventArgs e)
        {
            model.Reset();
            resultText.Text = "0";
        }
    }
}
