using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace ShakespeareanInsultGenerator
{
	public static class EnumerableExtensions
	{
		public static T Random<T>( this IEnumerable<T> sequence )
		{
			var concreteList = sequence as IList<T>;
			if ( concreteList == null )
			{
				concreteList = sequence.ToList();
			}
			var random = new RNGCryptoServiceProvider();
			var buffer = new Byte[sizeof ( int )];

			random.GetBytes(buffer);

			var randomIndex = BitConverter.ToInt32( buffer, 0 ) % concreteList.Count();
			return concreteList[ randomIndex ];
		}
	}
}
