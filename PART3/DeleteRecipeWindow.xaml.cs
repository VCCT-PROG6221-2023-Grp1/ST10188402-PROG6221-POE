using PART3.Classes;
using PROGPOE.Classes;
using System.Windows;

namespace PART3
{
    public partial class DeleteRecipeWindow : Window
    {
        public DeleteRecipeWindow()
        {
            InitializeComponent();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            string recipeName = txtRecipeName.Text;

            // Search for the recipe by name
            Recipe recipeToDelete = RecipeManager.GetRecipeByName(recipeName);

            if (recipeToDelete != null)
            {
                // Confirm deletion with the user
                MessageBoxResult result = MessageBox.Show($"Are you sure you want to delete the recipe '{recipeToDelete.getName()}'?", "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    // Delete the recipe
                    RecipeManager.DeleteRecipe(recipeToDelete);
                    MessageBox.Show("Recipe deleted successfully.", "Delete Recipe", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Recipe not found.", "Delete Recipe", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            // Close the window
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            // Close the window
            Close();
        }
    }
}
