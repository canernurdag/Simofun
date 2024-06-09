using Simofun.DevCaseStudy.Unity.Assets._Common.Scripts.Managers;
using Simofun.DevCaseStudy.Unity.Assets.DragReleaseToThrow.Scripts.Runtime.Events;
using Simofun.DevCaseStudy.Unity.Assets.TapDragToClean.Scripts.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Simofun.DevCaseStudy.Unity
{
    public class GameManagerClean : GameManager
    {
		
		private void OnEnable()
		{
			CleanGameplayEvents.OnCleanGameStateChange += SetCurrentGameStateType;
			CleanGameplayEvents.OnTextureManipulationRationChanged += FinishTheGame;
		}

		private void OnDisable()
		{
			CleanGameplayEvents.OnCleanGameStateChange += SetCurrentGameStateType;
			CleanGameplayEvents.OnTextureManipulationRationChanged -= FinishTheGame;
		}

		private void FinishTheGame(float ratio)
		{
			if (CurrentGameStateType != GameStateType.GameRunning) return;
			if(ratio > 0.95f)
			{
				CleanGameplayEvents.ExecuteOnThrowGameStateChange(GameStateType.GameFinished);
				CleanGameplayEvents.ExecuteOnLevelSucceed();
			}
		}
	}
}
