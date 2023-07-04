using PROGPOE.Classes;
using System.Windows;

namespace PART3
{
    public partial class AddStepWindow : Window
    {
        public Step NewStep { get; private set; }

        public AddStepWindow()
        {
            InitializeComponent();
            NewStep = null;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            // Create a new Step object with the entered description
            string stepDescription = txtStepDescription.Text;
            NewStep = new Step(stepDescription);

            // Close the window
            DialogResult = true;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            // Close the window without creating a new step
            DialogResult = false;
        }
    }
}
