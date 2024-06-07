namespace Simofun.DevCaseStudy.Unity.DependencyInversion.Presentation.View
{
	using Simofun.DevCaseStudy.Unity.DependencyInversion.Domain;
	using Simofun.DevCaseStudy.Unity.DependencyInversion.Domain.Model;
	using System.Linq;
	using System.Text;
	using UnityEngine;

	public class LeaderboardView : MonoBehaviour
	{
		#region Fields
		int index;
		#endregion

		#region Unity Methods		
		/// <inheritdoc />
		protected virtual void Start()
		{
			var leaderboardController = new LeaderboardController(
				new LeaderboardSorterByName(),
				new LeaderboardSorterByScore(),
				new FakeLeaderboardProvider());

			leaderboardController.GetItems()
				.ToList()
				.ForEach(i => Debug.Log(this.PrintLeaderboardItem(i)));
		}
		#endregion

		#region Methods
		string PrintLeaderboardItem(ILeaderboardItem leaderboardItem)
		{
			var stringBuilder = new StringBuilder();
			stringBuilder.Append($"Index: {++this.index}, ");
			stringBuilder.Append($"{nameof(ILeaderboardItem.Name)}: {leaderboardItem.Name}, ");
			stringBuilder.Append($"{nameof(ILeaderboardItem.Score)}: {leaderboardItem.Score}, ");

			return stringBuilder.ToString();
		}
		#endregion
	}
}
