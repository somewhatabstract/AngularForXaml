using System.Windows.Controls;

namespace HelloWorld
{
	public partial class App : System.Windows.Application
	{
		public App()
		{
			this.Startup += this.Application_Startup;

			InitializeComponent();
		}

		private void Application_Startup( object sender, System.Windows.StartupEventArgs e )
		{
			this.RootVisual = new TextBlock() { FontSize = 24, Text = "Hello World" };
			//this.RootVisual = new Controls();
			//this.RootVisual = new Presentation();
			//this.RootVisual = new Binding1();
			//this.RootVisual = new BindingCollections();
		}
	}
}
