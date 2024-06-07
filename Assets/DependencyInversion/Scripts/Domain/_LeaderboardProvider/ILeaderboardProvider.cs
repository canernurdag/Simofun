using Simofun.DevCaseStudy.Unity.DependencyInversion.Domain.Model;
using System.Collections.Generic;

namespace Simofun.DevCaseStudy.Unity
{
	public interface ILeaderboardProvider 
	{
		IEnumerable<ILeaderboardItem> GetItems();
	}
}
