using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace HelloWorld
{
	public partial class BindingCollections : UserControl
	{
		public BindingCollections()
		{
			InitializeComponent();

			List.ItemsSource = new[] { "Jim", "John", "Bob" };

			var cvs = new CollectionViewSource();
			cvs.Source = new[] { "Jim", "John", "Bob" };

			List2.ItemsSource = cvs.View;
		}
	}
}
