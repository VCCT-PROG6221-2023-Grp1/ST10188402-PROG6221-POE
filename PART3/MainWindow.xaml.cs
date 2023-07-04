using System.Windows;
using PART3.Windows;

namespace PART3
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCreateRecipe_Click(object sender, RoutedEventArgs e)
        {
            CreateRecipeWindow createRecipeWindow = new CreateRecipeWindow();
            createRecipeWindow.ShowDialog();
        }

        private void btnFilter_Click(object sender, RoutedEventArgs e)
        {
            FilteredWindow filteredWindow = new FilteredWindow();
            filteredWindow.ShowDialog();
        }

        private void btnScaleRecipe_Click(object sender, RoutedEventArgs e)
        {
            ScaleRecipeWindow scaleRecipeWindow = new ScaleRecipeWindow();
            scaleRecipeWindow.ShowDialog();
        }

        private void btnResetRecipe_Click(object sender, RoutedEventArgs e)
        {
            ResetRecipeWindow resetRecipeWindow = new ResetRecipeWindow();
            resetRecipeWindow.ShowDialog();
        }

        private void btnShowAllRecipes_Click(object sender, RoutedEventArgs e)
        {
            ShowAllRecipesWindow showAllRecipesWindow = new ShowAllRecipesWindow();
            showAllRecipesWindow.ShowDialog();
        }

        private void btnDeleteRecipe_Click(object sender, RoutedEventArgs e)
        {
            DeleteRecipeWindow deleteRecipeWindow = new DeleteRecipeWindow();
            deleteRecipeWindow.ShowDialog();
        }
    }
}
