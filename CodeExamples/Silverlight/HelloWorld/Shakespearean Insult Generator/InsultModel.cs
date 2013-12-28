using HelloWorld;

namespace ShakespeareanInsultGenerator
{
	public class InsultModel
	{
		public InsultModel()
		{
			Pronoun = "Thou";
			FirstAdjective = Words.Adjectives.Random();
			SecondAdjective = Words.HyphenatedAdjectives.Random();
			Noun = Words.Nouns.Random();
		}

		public string Pronoun { get; set; }
		public string FirstAdjective { get; set; }
		public string SecondAdjective { get; set; }
		public string Noun { get; set; }
	}
}
