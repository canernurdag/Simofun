using Simofun.DevCaseStudy.Unity.Assets._Common.Scripts.Managers;
using Simofun.DevCaseStudy.Unity.Assets.TapDragToClean.Scripts.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Simofun.DevCaseStudy.Unity
{
    public class GameManagerSort : GameManager
    {
		private void OnEnable()
		{
			SortGameplayEvents.OnSortGameStateChange += SetCurrentGameStateType;
		}

		private void OnDisable()
		{
			SortGameplayEvents.OnSortGameStateChange += SetCurrentGameStateType;
		}
	}
}
