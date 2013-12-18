using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace HelloWorld
{
	public partial class Controls : UserControl, INotifyPropertyChanged
	{
		public Controls()
		{
			InitializeComponent();
			this.DataContext = this;
		}

		public bool HasError
		{
			get
			{
				return _hasError;
			}

			set
			{
				if ( value != _hasError )
				{
					if ( value )
					{
						VisualStateManager.GoToState( this, "Error", true );
					}
					else
					{
						VisualStateManager.GoToState( this, "Normal", true );
					}

					_hasError = value;

					OnPropertyChanged( "HasError" );
				}
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged( string propertyName )
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if ( handler != null ) { handler( this, new PropertyChangedEventArgs( propertyName ) ); }
		}

		private bool _hasError;
	}
}
