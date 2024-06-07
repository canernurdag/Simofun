namespace Simofun.DevCaseStudy.Unity.DependencyInversion.Domain
{
	using Simofun.DevCaseStudy.Unity.DependencyInversion.Domain.Model;
	using System.Collections.Generic;
	using UnityEngine;

	public class LeaderboardController
	{
		#region Public Methods

		private ILeaderboardSorter _preferedLeaderboardSorter;
		private ILeaderboardSorter _restLeaderboardSorter;
		private ILeaderboardProvider _leaderboardProvider;

		public LeaderboardController(ILeaderboardSorter preferedLeaderboardSorter, ILeaderboardSorter restLeaderboardSorter, ILeaderboardProvider leaderboardProvider)
		{
			_preferedLeaderboardSorter = preferedLeaderboardSorter;
			_restLeaderboardSorter = restLeaderboardSorter;
			_leaderboardProvider = leaderboardProvider;
		}

		public IEnumerable<ILeaderboardItem> GetItems()
		{;
			var sortType = PlayerPrefs.GetInt("SortType", 0);
			if (sortType == 0)
			{
				return _preferedLeaderboardSorter.Sort(_leaderboardProvider);
			}

			return _restLeaderboardSorter.Sort(_leaderboardProvider);
		}
		#endregion
	}
}
