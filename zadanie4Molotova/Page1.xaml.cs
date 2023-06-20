using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace zadanie4Molotova
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();
        }

        private void Slider_BindingContextChanged(object sender, EventArgs e)
        {
            try
            {

                procent.Text = Convert.ToString(slider.Value) + "%";
                if (summa == null || srok == null || vid.Items[vid.SelectedIndex] == null) ;
                else
                {
                    if (summa.Text.Length == 0 || srok.Text.Length == 0 || vid.Items[vid.SelectedIndex] == "")
                    {

                    }
                    else
                    {
                        int valueSumma = Convert.ToInt32(summa.Text); // сумма кредита
                        int valueMonth = Convert.ToInt32(srok.Text); //срок в месяцах
                        double valueProcent = slider.Value; //процент
                        if (vid.Items[vid.SelectedIndex] == "Аннуитетный")
                        {

                            double ps = valueProcent / 100 / 12;
                            double p = (ps*(Math.Pow(1+ps,valueMonth)))/(Math.Pow(1+ps,valueMonth)-1);
                            p = p * valueSumma;
                            monthplat.Text = Convert.ToString(p);
                            allsum.Text = Convert.ToString(p * valueMonth);
                            pereplata.Text = Convert.ToString((p * valueMonth) - valueSumma);
                        }
                        else if (vid.Items[vid.SelectedIndex] == "Дифференцированный")
                        {
                            double montliPay = valueSumma / valueMonth;
                            double monthInt = valueSumma * (valueProcent / 100) / 12;
                            double total = valueSumma + (monthInt * valueMonth);
                            allsum.Text = Convert.ToString(total);
                            pereplata.Text = Convert.ToString(total - valueSumma);

                        }
                             else if (vid.Items[vid.SelectedIndex] == "Однократный")
                        {
                            double month = (valueSumma * (valueProcent / 100)) + valueSumma;
                            monthplat.Text = Convert.ToString(month);
                            allsum.Text = Convert.ToString(month);
                            pereplata.Text = Convert.ToString(month - valueSumma);

                        }

                    }
                }
            }
            catch
            {

            }
            
                
        }
    }
}