using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Up2Racev2
{

	public interface TwitterFeeds
	{
		bool UserName(string username);
		bool StatusUser(string statusId);
	}

}
