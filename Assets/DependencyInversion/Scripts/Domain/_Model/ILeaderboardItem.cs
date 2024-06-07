namespace Simofun.DevCaseStudy.Unity.DependencyInversion.Domain.Model
{
	public interface ILeaderboardItem
	{
		#region Properties
		int Score { get; set; }

		string Name { get; set; }
		#endregion
	}
}
