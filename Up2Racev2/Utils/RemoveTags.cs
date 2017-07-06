using System;
using System.Text.RegularExpressions;

namespace Up2Racev2.Utils
{
	//Clase para limpiar los tags de los item.
	public class RemoveTags
	{
		public static string StripTagsRegex(string source)
		{ 
			return Regex.Replace(source,@"<[^>]+>|&nbsp;|&#8230;|&#8220;|&#8221;|&#8211; 
					|&#8216;|&#8217;|&gt;|&lt;", string.Empty);
		}


		static Regex _tagsRegex = new Regex(@"<[^>]+>|&nbsp;|&#8230;|&#8220;|&#8221;
					|&#8211; |&#8216;|&#8217;|&gt;|&lt;");

		public string StripTagsRegexCompiled(string source)
		{
			return _tagsRegex.Replace(source, string.Empty);
		}
	}
}
