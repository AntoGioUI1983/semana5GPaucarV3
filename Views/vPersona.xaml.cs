namespace semana5GPaucar.Views;
using semana5GPaucar.Models;

public partial class vPersona : ContentPage
{
    public vPersona()
    {
        InitializeComponent();
    }

    private async void btnAgregar_Clicked(object sender, EventArgs e)
    {
        // Elimina estas l�neas
        // lblStatus.Text = "";
        // lblStatus.Text = App.PersonRepo.statusMessage;

        App.PersonRepo.AddNewPerson(txtPersona.Text);
        // Muestra una alerta con el mensaje de estado
        await DisplayAlert("Informaci�n", App.PersonRepo.statusMessage, "Aceptar");
    }

    private void btnObtener_Clicked(object sender, EventArgs e)
    {
        // Elimina esta l�nea
        // lblStatus.Text = "";
        List<Persona> people = App.PersonRepo.GetAllPeople();
        Listapersonas.ItemsSource = people;
    }

    private async void btnBorrar_Clicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var persona = button.BindingContext as Persona;

        // Aqu� puedes implementar la l�gica para borrar la persona seleccionada
        bool answer = await DisplayAlert("Confirmaci�n", $"�Est�s seguro de borrar a {persona.Name}?", "S�", "No");

        if (answer)
        {
            App.PersonRepo.DeletePerson(persona.Id);
            // Muestra una alerta con el mensaje de estado
            await DisplayAlert("Informaci�n", App.PersonRepo.statusMessage, "Aceptar");
            btnObtener_Clicked(sender, e); // Refrescar la lista despu�s de borrar la persona
        }
    }

    private void btnUpdate_Clicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var persona = button.BindingContext as Persona;
        Navigation.PushAsync(new Views.vEditar(persona.Name, persona.Id));
    }
}
