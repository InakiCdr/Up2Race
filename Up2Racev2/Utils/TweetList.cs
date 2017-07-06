using System;
using System.Collections.Generic;
using Up2Racev2.Models;

namespace Up2Racev2.Utils
{
	public interface TweetList
	{
		void Save(System.Collections.Generic.List<Tweet> tweets);
	}
}
