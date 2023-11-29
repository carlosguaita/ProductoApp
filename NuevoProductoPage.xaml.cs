
using ProductoApp.Models;
using ProductoApp.Services;
using ProductoApp.Utils;

namespace ProductoApp;

public partial class NuevoProductoPage : ContentPage
{

    private Producto _producto;
    private readonly APIService _APIService;

    public NuevoProductoPage(APIService apiservice)
	{
		InitializeComponent();
        _APIService = apiservice;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _producto = BindingContext as Producto;
        if ( _producto != null )
        {
            Nombre.Text = _producto.Nombre;
            Cantidad.Text = _producto.cantidad.ToString();
            Descripcion.Text = _producto.Descripcion;
        }
    }

    private async void OnClickGuardarProducto(object sender, EventArgs e)
    {
        if ( _producto != null )
        {
            _producto.Nombre = Nombre.Text;
            _producto.Descripcion = Descripcion.Text;
            _producto.cantidad = Int32.Parse(Cantidad.Text);
            await _APIService.PutProducto(_producto.IdProducto, _producto);
        }
        else
        {
            int id = Utils.Utils.ListaProductos.Count + 1;
            Producto producto = new Producto
            {
                IdProducto = 0,
                Nombre = Nombre.Text,
                Descripcion = Descripcion.Text,
                cantidad = Int32.Parse(Cantidad.Text),
                urlImage = ""
            };
            await _APIService.PostProducto(producto);
            /*
            Utils.Utils.ListaProductos.Add(
            );
            */
        }
        await Navigation.PopAsync();
        
    }

}
