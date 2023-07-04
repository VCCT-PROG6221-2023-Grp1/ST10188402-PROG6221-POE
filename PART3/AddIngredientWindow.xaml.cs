using PROGPOE.Classes;
using System.Windows;
using System.Xml.Linq;

namespace PART3
{
    public partial class AddIngredientWindow : Window
    {
        public Ingredient NewIngredient = new Ingredient("default", 0, "default", 
            "default", 0);

        public AddIngredientWindow()
        {
            InitializeComponent();
        }

        private void btnAddIngredient_Click(object sender, RoutedEventArgs e)
        {
            // Retrieve ingredient data from the input fields
            NewIngredient.setName(txtName.Text);
            NewIngredient.setQuantity(double.Parse(txtQuantity.Text));
            NewIngredient.setMeasurementUnit(cmbMeasurementUnits.SelectedIndex);
            NewIngredient.setFoodGroup(cmbFoodGroups.SelectedIndex);
            NewIngredient.setCalories(double.Parse(txtCalories.Text));

            // Close the window
            DialogResult = true;
            Close();
        }
    }
}
