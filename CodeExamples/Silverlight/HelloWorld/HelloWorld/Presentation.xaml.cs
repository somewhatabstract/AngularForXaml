using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace HelloWorld
{
	public partial class Presentation : UserControl
	{
		public Presentation()
		{
			InitializeComponent();

			LayoutRoot.DataContext = new Model();
		}

		public class Model : INotifyPropertyChanged
		{
			public bool IsShowingSurprise
			{
				get { return _isShowingSurprise; }
				set
				{
					if ( _isShowingSurprise != value )
					{
						_isShowingSurprise = value;
						OnPropertyChanged( "IsShowingSurprise" );
					}
				}
			}

			public bool HasError
			{
				get { return _hasError; }
				set
				{
					if ( _hasError != value )
					{
						_hasError = value;
						OnPropertyChanged( "HasError" );
					}
				}
			}

			public event PropertyChangedEventHandler PropertyChanged;

			private void OnPropertyChanged( string propertyName )
			{
				var handler = PropertyChanged;
				if ( handler != null )
				{
					handler( this, new PropertyChangedEventArgs( propertyName ) );
				}
			}

			private bool _isShowingSurprise;
			private bool _hasError;
		}
	}
}
