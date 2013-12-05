using System;
using System.Collections.Generic;
using System.ComponentModel;
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

			var collectionView = new CollectionViewSource();
			collectionView.Source = new[] { "Jim", "John", "Bob" };
			collectionView.View.SortDescriptions.Add( new SortDescription { Direction = ListSortDirection.Descending } );
			collectionView.View.Filter = o => String.IsNullOrEmpty( FilterTextBox.Text )
				|| ( (string)o ).StartsWith( FilterTextBox.Text );

			List2.ItemsSource = collectionView.View;
			FilterTextBox.TextChanged += ( sender, args ) => ( (ICollectionView)List2.ItemsSource ).Refresh();
		}
	}
}
