using System;
using System.Collections.Generic;
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
	public class StatusMessage : Control
	{
		public StatusMessage()
		{
			this.DefaultStyleKey = typeof(StatusMessage);
		}

		public static readonly DependencyProperty MessageProperty =
			DependencyProperty.Register( "Message", typeof ( string ), typeof ( StatusMessage ), new PropertyMetadata( default( string ) ) );

		public string Message
		{
			get { return (string) GetValue( MessageProperty ); }
			set { SetValue( MessageProperty, value ); }
		}
	}
}
