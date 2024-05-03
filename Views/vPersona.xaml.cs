namespace semana5GPaucar.Views;
using semana5GPaucar.Models;

public partial class vPersona : ContentPage
{
    public vPersona()
    {
        InitializeComponent();
    }

    private  void btnAgregar_Clicked(object sender, EventArgs e)
    {

        Navigation.PushAsync(new Views.vAgregar());
        
    }

    private void btnObtener_Clicked(object sender, EventArgs e)
    {
        // Elimina esta línea
        // lblStatus.Text = "";
        List<Persona> people = App.PersonRepo.GetAllPeople();
        Listapersonas.ItemsSource = people;
    }

    private async void btnBorrar_Clicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var persona = button.BindingContext as Persona;

        // Aquí puedes implementar la lógica para borrar la persona seleccionada
        bool answer = await DisplayAlert("Confirmación", $"¿Estás seguro de borrar a {persona.Name}?", "Sí", "No");

        if (answer)
        {
            App.PersonRepo.DeletePerson(persona.Id);
            // Muestra una alerta con el mensaje de estado
            await DisplayAlert("Información", App.PersonRepo.statusMessage, "Aceptar");
            btnObtener_Clicked(sender, e); // Refrescar la lista después de borrar la persona
        }
    }

    private void btnUpdate_Clicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var persona = button.BindingContext as Persona;
        Navigation.PushAsync(new Views.vEditar(persona.Name, persona.Id));
    }
}
