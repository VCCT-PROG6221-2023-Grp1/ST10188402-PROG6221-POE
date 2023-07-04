using System.Windows;
using System.Windows.Controls;
using PART3.Classes;
using PROGPOE.Classes;
using System.Collections.Generic;

namespace PART3.Windows
{
    public partial class ResetRecipeWindow : Window
    {
        private Recipe selectedRecipe;

        public ResetRecipeWindow()
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

        private void btnResetRecipe_Click(object sender, RoutedEventArgs e)
        {
            if (selectedRecipe != null)
            {
                RecipeManager.ResetRecipeIngredients(selectedRecipe);
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
