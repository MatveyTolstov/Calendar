using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Календарь
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Zametka> zametkas;
        List<Zametka> nowzametka;
        public MainWindow()
        {
            InitializeComponent();
            zametkas = SelandDel.Ser<List <Zametka >>("mama.json");
            if (zametkas == null)
            {
                zametkas = new List<Zametka>();
            }
            DatePicker.Text = DateTime.Now.ToLongDateString();
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            DateTime date = Convert.ToDateTime(DatePicker.Text);
            string name = NameBox.Text;
            string opisanie = OpisanieBox.Text;

            Zametka zametka = new Zametka(name, opisanie, date);

            zametkas.Add(zametka);

            SelandDel.Der(zametkas, "mama.json");

            Update();
            
        }

        private void Update()
        {
            DateTime date = Convert.ToDateTime(DatePicker.Text);
            nowzametka = zametkas.Where(z => z.date == date).ToList();
            List<string> names = nowzametka.Select(z => z.name).ToList();
            ZametkasList.ItemsSource = names;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if(ZametkasList.SelectedIndex != -1)
            {
                string name = NameBox.Text;
                string opisanie = OpisanieBox.Text;
                Zametka zametka = nowzametka[ZametkasList.SelectedIndex];

                zametka.name = name;
                zametka.opisanie = opisanie;


                SelandDel.Der(zametkas, "mama.json");

                Update();

            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if(ZametkasList.SelectedIndex != -1)
            {
                Zametka zametka = nowzametka[ZametkasList.SelectedIndex];

                zametkas.Remove(zametka);

                SelandDel.Der(zametkas, "mama.json");

                Update();
            }
        }

        private void ZametkasList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(ZametkasList.SelectedIndex != -1)
            {
                Zametka zametka = nowzametka[ZametkasList.SelectedIndex];
                NameBox.Text = zametka.name;
                OpisanieBox.Text = zametka.opisanie;
            }
            else
            {
                NameBox.Text = "";
                OpisanieBox.Text = "";
            }
        }

        private void DatePicker_SelectedDateChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            Update();
        }

        private void Leto_Click(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1();
            window1.Show();
            
        }
    }


}
