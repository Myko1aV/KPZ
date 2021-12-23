using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Lab6KPZ
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Drug drug = new Drug();
        public DrugStorage drSrg = new DrugStorage();
        public MainWindow()
        {
            InitializeComponent();
            DataGridDrug.ItemsSource = new ModelHospital().Drugs.ToList();
            DataGridDrugStorage.ItemsSource = new ModelHospital().DrugStorages.ToList();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            drug.DrugID = Convert.ToInt32(TextBoxDrugId.Text);
            drug.ProductName = TextBoxProductName.Text;
            drug.ProductCode = TextBoxProductCode.Text;
            drug.ExpirationData = Convert.ToDateTime(TextBoxExpirationDate.Text);
            drug.DrugStorageID = Convert.ToInt32(TextBoxDrugStorageId.Text);


            using (ModelHospital db = new ModelHospital())
            {
                db.Drugs.Add(drug);
                db.SaveChanges();
            }
            Refresh();
        }

              private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            drug.DrugID = Convert.ToInt32(TextBoxDrugId.Text);
            drug.ProductName = TextBoxProductName.Text;
            drug.ProductCode = TextBoxProductCode.Text;
            drug.ExpirationData = Convert.ToDateTime(TextBoxExpirationDate.Text);
            drug.DrugStorageID = Convert.ToInt32(TextBoxDrugStorageId.Text);

            using (ModelHospital db = new ModelHospital())
            {
                db.Entry(drug).State = EntityState.Modified;
                db.SaveChanges();
            }
            Refresh();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            drug.DrugID = Convert.ToInt32(TextBoxDrugId.Text);
            using (ModelHospital db = new ModelHospital())
            {
                var entry = db.Entry(drug);
                if (entry.State == EntityState.Detached)
                {
                    db.Drugs.Attach(drug);
                }
                db.Drugs.Remove(drug);
                db.SaveChanges();
            }
            Refresh();
        }
        private void Refresh()
        {

            using (ModelHospital db = new ModelHospital())
            {
                DataGridDrug.ItemsSource = db.Drugs.ToList();
                DataGridDrugStorage.ItemsSource = db.DrugStorages.ToList();
            }
        }

        private void DataGridLocation_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
  private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            drSrg.ID = Convert.ToInt32(id.Text);
            drSrg.Capacity = Convert.ToInt32(Capacity.Text);
            drSrg.Renewal = Convert.ToDateTime(Renewal.Text);
            drSrg.Supply = Convert.ToDateTime(Supply.Text);

            using (ModelHospital db = new ModelHospital())
            {
                db.DrugStorages.Add(drSrg);
                db.SaveChanges();
            }
            Refresh();
        }



        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            drSrg.ID = Convert.ToInt32(id.Text);
            drSrg.Capacity = Convert.ToInt32(Capacity.Text);
            drSrg.Renewal = Convert.ToDateTime(Renewal.Text);
            drSrg.Supply = Convert.ToDateTime(Supply.Text);

            using (ModelHospital db = new ModelHospital())
            {
                db.Entry(drSrg).State = EntityState.Modified;
                db.SaveChanges();
            }
            Refresh();
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            drSrg.ID = Convert.ToInt32(id.Text);

            using (ModelHospital db = new ModelHospital())
            {
                var entry = db.Entry(drSrg);
                if (entry.State == EntityState.Detached)
                {
                    db.DrugStorages.Attach(drSrg);
                }
                db.DrugStorages.Remove(drSrg);
                db.SaveChanges();
            }
            Refresh();
        }
    }
}