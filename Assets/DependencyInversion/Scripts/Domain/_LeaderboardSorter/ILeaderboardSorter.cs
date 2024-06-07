using Simofun.DevCaseStudy.Unity.DependencyInversion.Domain.Model;
using System.Collections.Generic;


namespace Simofun.DevCaseStudy.Unity
{
    public interface ILeaderboardSorter 
    {
		IEnumerable<ILeaderboardItem> Sort(ILeaderboardProvider leaderboardProvider);
	}
}
