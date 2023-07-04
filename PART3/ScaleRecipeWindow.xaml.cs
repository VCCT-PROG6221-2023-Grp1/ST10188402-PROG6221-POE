using System.Windows;
using System.Windows.Controls;
using PART3.Classes;
using PROGPOE.Classes;

namespace PART3
{
    public partial class ScaleRecipeWindow : Window
    {
        private Recipe selectedRecipe;

        public ScaleRecipeWindow()
        {
            InitializeComponent();
        }

        private void btnSearchRecipe_Click(object sender, RoutedEventArgs e)
        {
            string searchRecipeName = txtSearchRecipe.Text;

            selectedRecipe = RecipeManager.GetRecipeByName(searchRecipeName);

            if (selectedRecipe != null)
            {
                txtOriginalRecipeName.Text = selectedRecipe.getName();
                txtOriginalTotalCalories.Text = selectedRecipe.getTotalCalories().ToString();
            }
            else
            {
                MessageBox.Show("Recipe not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnScaleRecipe_Click(object sender, RoutedEventArgs e)
        {
            if (selectedRecipe != null)
            {
                double scaleFactor;
                switch (cmbScaleFactor.SelectedIndex)
                {
                    case 0: // Halving
                        scaleFactor = 0.5;
                        break;
                    case 1: // Doubling
                        scaleFactor = 2;
                        break;
                    case 2: // Tripling
                        scaleFactor = 3;
                        break;
                    default:
                        MessageBox.Show("Please select a scale factor.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                }

                RecipeManager.ScaleRecipeIngredients(selectedRecipe, scaleFactor);


                MessageBox.Show("Recipe scaled successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                // Close the window
                Close();
            }
            else
            {
                MessageBox.Show("No recipe selected.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            // Close the window
            Close();
        }
    }
}
