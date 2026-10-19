using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ПР4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private List<Weapon> weapons = new List<Weapon>();
        Random rnd = new Random();

        private void ButtonCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int.TryParse(TextBoxLevel.Text, out int Level);
                double.TryParse(TextBoxDamage.Text, out double Damage);
                Weapon weapon = new Weapon(TextBoxName.Text, Level, Damage, (ComboBoxType.SelectedIndex).ToString());
                weapons.Add(weapon);
                ListBoxWeapons.Items.Add(weapon.ToString());
                ComboBoxWeapon1.Items.Add(weapon.ToString());
                ComboBoxWeapon2.Items.Add(weapon.ToString());
                ComboBoxWeapon1.SelectedIndex = 0;

                ComboBoxTypeP.Items.Add(weapon.ToString());
                ComboBoxTypeP.SelectedIndex = 0;

                PersonageTab.IsEnabled = true;

                if (weapons.Count == 2)
                {
                    SeparatorUpgrade.Visibility = Visibility.Visible;
                    ComboBoxWeapon1.Visibility = Visibility.Visible;
                    ButtonUpgrade.Visibility = Visibility.Visible;
                    ComboBoxWeapon2.Visibility = Visibility.Visible;

                    ComboBoxWeapon2.SelectedIndex = 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }


        }


        List<string> list = new List<string>() {
            @"Images/img1.jpg",
            @"Images/img2.jpg"
        };

        private void ButtonCreatePers_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!int.TryParse(TextBoxLevelP.Text, out int Level)) Level = 0;
                if (!int.TryParse(TextBoxStrenghtP.Text, out int Strength)) Strength = 0;
                if (!int.TryParse(TextBoxAgilityP.Text, out int Agility)) Agility = 0;
                if (!int.TryParse(TextBoxIntellectP.Text, out int Intellect)) Intellect = 0;

                if (ComboBoxTypeP.SelectedIndex == -1) ComboBoxTypeP.SelectedIndex = 0;

                Personage personage = new Personage(TextBoxNameP.Text, Level, Strength, Agility, Intellect, weapons[ComboBoxTypeP.SelectedIndex]);

                //ButtonCreatePers.IsEnabled = false;

                TextBoxNameP.Text = personage.Name;
                //TextBoxNameP.IsEnabled = false;
                TextBoxLevelP.Text = personage.Level.ToString();
                //TextBoxLevelP.IsEnabled = false;
                TextBoxStrenghtP.Text = personage.Strength.ToString();
                //TextBoxStrenghtP.IsEnabled = false;
                TextBoxAgilityP.Text = personage.Agility.ToString();
                //TextBoxAgilityP.IsEnabled = false;
                TextBoxIntellectP.Text = personage.Intellect.ToString();
                //TextBoxIntellectP.IsEnabled = false;
                //ComboBoxTypeP.IsEnabled = false;

                ImageP.Source = new BitmapImage(new Uri(list[rnd.Next(2)], UriKind.Relative));
                ImagePLabel.Content = personage.ToString();
                PowerP.Content = personage.Power();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }


        }

        private void ButtonUpgrade_Click(object sender, RoutedEventArgs e)
        {
            if (ComboBoxWeapon1.SelectedValue != null && ComboBoxWeapon2.SelectedValue != null)
            {

                weapons.Add(weapons[ComboBoxWeapon1.SelectedIndex] + weapons[ComboBoxWeapon2.SelectedIndex]);

                if (ComboBoxWeapon1.SelectedIndex > ComboBoxWeapon2.SelectedIndex)
                {
                    weapons.RemoveAt(ComboBoxWeapon1.SelectedIndex);
                    weapons.RemoveAt(ComboBoxWeapon2.SelectedIndex);
                }
                else
                {
                    weapons.RemoveAt(ComboBoxWeapon1.SelectedIndex);
                    weapons.RemoveAt(ComboBoxWeapon2.SelectedIndex - 1);
                }


                ComboBoxWeapon1.Items.Clear();
                ComboBoxWeapon2.Items.Clear();
                ComboBoxTypeP.Items.Clear();

                ListBoxWeapons.Items.Clear();

                foreach (var weapon in weapons)
                {
                    ListBoxWeapons.Items.Add(weapon.ToString());
                    ComboBoxWeapon1.Items.Add(weapon.ToString());
                    ComboBoxWeapon2.Items.Add(weapon.ToString());
                    ComboBoxTypeP.Items.Add(weapon.ToString());
                }


            }
            else
            {
                MessageBox.Show("Выберите оружия");
                return;
            }
        }


    }


}
