namespace ProductoApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NuevoProductoPage();
        }
    }
}