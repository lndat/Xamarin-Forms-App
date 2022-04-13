using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMitAlles
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BruttoNetto : ContentPage
    {
        public BruttoNetto()
        {
            InitializeComponent();
        }

        private void nettoBtn_Clicked(object sender, EventArgs e)
        {
            decimal einkommen = Convert.ToDecimal(bruttoEntry.Text);

            if (bruttoEntry.Text != string.Empty)
            {
                if (einkommen >= 446.81m && einkommen <= 1681m)
                {
                    bruttoLabel.Text = string.Format("{0:#,0.00} €", einkommen);

                    var resultSV = einkommen * 0.1512m;
                    var resultNetto = einkommen - resultSV;
                    var resultLS = LohnSteuerRechner(resultNetto);
                   
                    sozialLabel.Text = string.Format("{0:#,0.00} €", resultSV);
                    lohnLabel.Text = string.Format("{0:#,0.00} €", resultLS);
                    nettoLabel.Text = string.Format("{0:#,0.00} €", (resultNetto - resultLS));

                }
                else if (einkommen > 1681m && einkommen <= 1834m)
                {
                    bruttoLabel.Text = string.Format("{0:#,0.00} €", einkommen);

                    var resultSV = einkommen * 0.1612m;
                    var resultNetto = einkommen - resultSV;
                    var resultLS = LohnSteuerRechner(resultNetto);

                    sozialLabel.Text = string.Format("{0:#,0.00} €", resultSV);
                    lohnLabel.Text = string.Format("{0:#,0.00} €", resultLS);
                    nettoLabel.Text = string.Format("{0:#,0.00} €", (resultNetto - resultLS));
                }
                else if (einkommen > 1834m && einkommen <= 1987m)
                {
                    bruttoLabel.Text = string.Format("{0:#,0.00} €", einkommen);

                    var resultSV = einkommen * 0.1712m;
                    var resultNetto = einkommen - resultSV;
                    var resultLS = LohnSteuerRechner(resultNetto);

                    sozialLabel.Text = string.Format("{0:#,0.00} €", resultSV);
                    lohnLabel.Text = string.Format("{0:#,0.00} €", resultLS);
                    nettoLabel.Text = string.Format("{0:#,0.00} €", (resultNetto - resultLS));
                }
                else if (einkommen > 1987m && einkommen <= 5220m)
                {
                    bruttoLabel.Text = string.Format("{0:#,0.00} €", einkommen);

                    var resultSV = einkommen * 0.1812m;
                    var resultNetto = einkommen - resultSV;
                    var resultLS = LohnSteuerRechner(resultNetto);

                    sozialLabel.Text = string.Format("{0:#,0.00} €", resultSV);
                    lohnLabel.Text = string.Format("{0:#,0.00} €", resultLS);
                    nettoLabel.Text = string.Format("{0:#,0.00} €", (resultNetto - resultLS));
                }
                else
                {
                    DisplayAlert("Falsche eingabe", "Zwischen 446€ und 5220€ Eingeben!", "Ok");
                }
            }
        }

        private decimal LohnSteuerRechner(decimal gehalt)
        {
            decimal ergebnisSteuer = 0m;
            decimal steuersatz1 = 0m;
            decimal steuersatz2 = 0m;
            decimal steuersatz3 = 0m;
            decimal steuersatz4 = 0m;
            decimal steuersatz5 = 0m;
            decimal steuersatz6 = 0m;
            decimal steuersatz7 = 0m;

            if (gehalt <= 1099.33m)
            {
                ergebnisSteuer = 0m;
            }
            else if (gehalt <= 1516.00m)
            {
                steuersatz1 = gehalt - 1099.33m;
                steuersatz2 = (steuersatz1 / 100) * 20;
                ergebnisSteuer = steuersatz2;
            }
            else if (gehalt <= 2599.33m)
            {
                steuersatz1 = gehalt - 1099.33m;
                steuersatz2 = (416.67m / 100) * 20;
                steuersatz3 = ((gehalt - 1516m) / 100) * 35;

                ergebnisSteuer = steuersatz2 + steuersatz3;
            }
            else if (gehalt <= 5016.00m)
            {
                steuersatz1 = gehalt - 1099.33m;
                steuersatz2 = (416.67m / 100) * 20;
                steuersatz3 = (1083.33m / 100) * 35;
                steuersatz4 = ((gehalt - 2599.33m) / 100) * 42;

                ergebnisSteuer = steuersatz2 + steuersatz3 + steuersatz4;
            }
            else if (gehalt <= 7516.00m)
            {
                steuersatz1 = gehalt - 1099.33m;
                steuersatz2 = (416.67m / 100) * 20;
                steuersatz3 = (1083.33m / 100) * 35;
                steuersatz4 = (2416.67m / 100) * 42;
                steuersatz5 = ((gehalt - 5016m) / 100) * 48;

                ergebnisSteuer = steuersatz2 + steuersatz3 + steuersatz4 + steuersatz5;
            }
            else if (gehalt <= 83349.33m)
            {
                steuersatz1 = gehalt - 1099.33m;
                steuersatz2 = (416.67m / 100) * 20;
                steuersatz3 = (1083.33m / 100) * 35;
                steuersatz4 = (2416.67m / 100) * 42;
                steuersatz5 = (2500m / 100) * 48;
                steuersatz6 = ((gehalt - 7516m) / 100) * 50;

                ergebnisSteuer = steuersatz2 + steuersatz3 + steuersatz4 + steuersatz5 + steuersatz6;
            }
            else if (gehalt > 83349.33m)
            {
                steuersatz1 = gehalt - 1099.33m;
                steuersatz2 = (416.67m / 100) * 20;
                steuersatz3 = (1083.33m / 100) * 35;
                steuersatz4 = (2416.67m / 100) * 42;
                steuersatz5 = (2500m / 100) * 48;
                steuersatz6 = (75833.33m / 100) * 50;
                steuersatz7 = ((gehalt - 83349.33m) / 100) * 55;

                ergebnisSteuer = steuersatz2 + steuersatz3 + steuersatz4 + steuersatz5 + steuersatz6 + steuersatz7;
            }

            return ergebnisSteuer;
        }
    }
}
