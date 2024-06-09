using Simofun.DevCaseStudy.Unity.Assets._Common.Scripts.Managers;
using Simofun.DevCaseStudy.Unity.Assets.DragReleaseToThrow.Scripts.Runtime.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Simofun.DevCaseStudy.Unity.Assets.DragReleaseToThrow.Scripts.Runtime.Managers
{
	public class GameManagerThrow : GameManager
	{
		private void OnEnable()
		{
			ThrowGameplayEvents.OnThrowGameStateChange += SetCurrentGameStateType;
		}

		private void OnDisable()
		{
			ThrowGameplayEvents.OnThrowGameStateChange -= SetCurrentGameStateType;
		}
	}
}
