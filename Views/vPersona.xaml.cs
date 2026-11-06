using djaramilloS5.Models;

namespace djaramilloS5.Views
{
    public partial class vPersona : ContentPage
    {
        public vPersona()
        {
            InitializeComponent();
        }

        private void btnAgregar_Clicked(object? sender, EventArgs e)
        {
            App.PersonRepo.AddNewPerson(txtName.Text);
            lblStatusMessage.Text = App.PersonRepo.StatusMessage;
            txtName.Text = string.Empty;
        }

        private void btnMostrar_Clicked(object? sender, EventArgs e)
        {
            listaPersonas.ItemsSource = App.PersonRepo.GetAllPerson();
            lblStatusMessage.Text = App.PersonRepo.StatusMessage;
        }

        private async void btnEliminar_Clicked(object? sender, EventArgs e)
        {
            if (listaPersonas.SelectedItem is not Persona persona)
            {
                lblStatusMessage.Text = "Seleccione una persona de la lista";
                return;
            }

            bool confirmar = await DisplayAlertAsync("Eliminar", $"¿Eliminar a {persona.Name}?", "Sí", "No");
            if (!confirmar)
                return;

            App.PersonRepo.DeletePerson(persona.Id);
            lblStatusMessage.Text = App.PersonRepo.StatusMessage;
            listaPersonas.ItemsSource = App.PersonRepo.GetAllPerson();
        }
    }
}
