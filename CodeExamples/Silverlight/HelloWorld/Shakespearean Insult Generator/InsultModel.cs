using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace ShakespeareanInsultGenerator
{
	public class InsultModel : INotifyPropertyChanged
	{
		public InsultModel()
		{
			_firstAdjectiveList = Words.Adjectives.ToList().AsReadOnly();
			_secondAdjectiveList = Words.HyphenatedAdjectives.ToList().AsReadOnly();
			_nounList = Words.Nouns.ToList().AsReadOnly();

			Randomize();
		}

		public void Randomize()
		{
			FirstAdjective = _firstAdjectiveList.Random();
			SecondAdjective = _secondAdjectiveList.Random();
			Noun = _nounList.Random();
		}

		public string FirstAdjective
		{
			get { return _firstAdjective; }
			set
			{
				if ( _firstAdjective != value )
				{

					_firstAdjective = value;
					OnPropertyChanged( "FirstAdjective" );
				}
			}
		}

		public string SecondAdjective
		{
			get { return _secondAdjective; }
			set
			{
				if ( _secondAdjective != value )
				{

					_secondAdjective = value;
					OnPropertyChanged( "SecondAdjective" );
				}
			}
		}
	
		public string Noun
		{
			get { return _noun; }
			set
			{
				if ( _noun != value )
				{

					_noun = value;
					OnPropertyChanged( "Noun" );
				}
			}
		}

		public IEnumerable<string> FirstAdjectiveList { get { return _firstAdjectiveList; } }
		public IEnumerable<string> SecondAdjectiveList { get { return _secondAdjectiveList; } }
		public IEnumerable<string> NounList { get { return _nounList; } }

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged( string propertyName )
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if ( handler != null ) { handler( this, new PropertyChangedEventArgs( propertyName ) ); }
		}

		private string _firstAdjective;
		private string _secondAdjective;
		private string _noun;
		private readonly IEnumerable<string> _firstAdjectiveList;
		private readonly IEnumerable<string> _secondAdjectiveList;
		private readonly IEnumerable<string> _nounList;
	}
}
