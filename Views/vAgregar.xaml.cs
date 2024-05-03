
namespace semana5GPaucar.Views;
using semana5GPaucar.Models;

public partial class vAgregar : ContentPage
{
	public vAgregar()
	{
		InitializeComponent();
	}

    
    

    private async void btnGuardar_Clicked(object sender, EventArgs e)
    {
        App.PersonRepo.AddNewPerson(txtPersona.Text);

        await DisplayAlert("Información", App.PersonRepo.statusMessage, "Aceptar");

    }
}
