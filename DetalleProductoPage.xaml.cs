using ProductoApp.Models;
using ProductoApp.Services;

namespace ProductoApp;

public partial class DetalleProductoPage : ContentPage
{
   private Producto _producto;

    private APIService _APIService;
    public DetalleProductoPage(APIService apiservice)
	{
		InitializeComponent();
        _APIService = apiservice;
       
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _producto = BindingContext as Producto;
        Nombre.Text = _producto.Nombre;
        Cantidad.Text = _producto.cantidad.ToString();
        Descripcion.Text = _producto.Descripcion;

    }

    private async void ClickEliminarProducto(object sender, EventArgs e)
    {
        Utils.Utils.ListaProductos.Remove(_producto);
        await Navigation.PopAsync();
    }

    private async void ClickEditarProducto(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new NuevoProductoPage()
        {
            BindingContext = _producto,
        });
    }
}