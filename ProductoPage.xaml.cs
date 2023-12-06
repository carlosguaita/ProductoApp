using static System.Net.Mime.MediaTypeNames;
using System.Threading.Tasks;
using System.Threading;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using ProductoApp.Models;
using System.Collections.ObjectModel;
using ProductoApp.Services;

namespace ProductoApp;

public partial class ProductoPage : ContentPage
{
    ObservableCollection<Producto> products;
    private readonly APIService _APIService;
	public ProductoPage(APIService apiservice)
	{
		InitializeComponent();
        _APIService = apiservice;
       
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        string username = Preferences.Get("username", "0");
        Username.Text = username;
        List<Producto> ListaProducts = await _APIService.GetProductos();
        products = new ObservableCollection<Producto>(ListaProducts);
        listaProductos.ItemsSource = products;
    }
    private async void OnClickNuevoProducto(object sender, EventArgs e)
    {

        var toast = Toast.Make("On Click Boton Nuevo Producto", ToastDuration.Short, 14);
        await toast.Show();
        await Navigation.PushAsync(new NuevoProductoPage(_APIService));
    }
    private async void OnClickShowDetails(object sender, SelectedItemChangedEventArgs e)
    {
        var toast = CommunityToolkit.Maui.Alerts.Toast.Make("Click en ver producto", ToastDuration.Short, 14);

        await toast.Show();
        Producto producto = e.SelectedItem as Producto;
        await Navigation.PushAsync(new DetalleProductoPage(_APIService)
        {
            BindingContext = producto,
        });
    }



}