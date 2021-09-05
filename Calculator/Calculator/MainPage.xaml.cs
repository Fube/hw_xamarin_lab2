using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Calculator
{
    public partial class MainPage : ContentPage
    {

        Model model;
        public MainPage()
        {
            model = new Model();
            InitializeComponent();

            for (int i = 1; i < 10; i++)
            {
                int j = i; // Get constant ref

                Button btn = new Button
                {
                    Text = (10 - j).ToString()
                };
                
                btn.Clicked += (e, s) => HandleNumClick(10 - j);

                // Element, Column, Row
                CalcGrid.Children.Add(btn, (j - 1) % 3, 3 + j / 4);
            }

        }

        private void HandleNumClick(int num)
        {
            if(resultText.Text.Equals("0"))
            {
                resultText.Text = num.ToString();
                return;
            }
            resultText.Text += num.ToString();
        }

        private void HandleEqualsClick(object sender, EventArgs e)
        {
            model.SecondNum = Convert.ToDecimal(resultText.Text); ;
            resultText.Text = model?.Calculate().ToString() ?? "0";
            model.Reset();
        }

        private void HandleAddition(object sender, EventArgs e)
        {
            model.FirstNum = Convert.ToDecimal(resultText.Text);
            model.Op = Model.Operation.ADD;
            resultText.Text = "0";
        }

        private void HandleClear(object sender, EventArgs e)
        {
            model.Reset();
            resultText.Text = "0";
        }
    }
}
