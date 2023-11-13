using FileProvider;
using ProductoApp.Models;
using ProductoApp.Utils;

namespace ProductoApp;

public partial class NuevoProductoPage : ContentPage
{
	public NuevoProductoPage()
	{
		InitializeComponent();
	}

    private void OnClickGuardarProducto(object sender, EventArgs e)
    {
        int id = Utils.Utils.ListaProductos.Count + 1;
        Utils.Utils.ListaProductos.Add(new Producto
        {
            IdProducto = id,
            Nombre = Nombre.Text,
            Descripcion = Descripcion.Text,
            cantidad = Int32.Parse(Cantidad.Text),
        }
        );
    }

}
