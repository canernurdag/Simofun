namespace Simofun.DevCaseStudy.Unity.DependencyInversion.Domain.Model
{
	public class LeaderboardItem : ILeaderboardItem
	{
		#region Properties
		public int Score { get; set; }

		public string Name { get; set; }
		#endregion
	}
}
