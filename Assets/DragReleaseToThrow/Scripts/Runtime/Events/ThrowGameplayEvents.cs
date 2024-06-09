using Simofun.DevCaseStudy.Unity.Assets._Common.Scripts.Managers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Simofun.DevCaseStudy.Unity.Assets.DragReleaseToThrow.Scripts.Runtime.Events
{
	public static class ThrowGameplayEvents
	{
		public static event Action OnInputDown;
		public static event Action<Vector2> DragVector;
		public static event Action<Vector2> OnInputUp;
		public static event Action OnCameraChangeToResult;
		public static event Action<GameManager.GameStateType> OnThrowGameStateChange;
		public static event Action OnLevelSucceed;
		public static event Action OnLevelFailed;
		public static void ExecuteOnInputDown()
		{
			OnInputDown?.Invoke();
		}

		public static void ExecuteDragInput(Vector2 dragVector)
		{
			DragVector?.Invoke(dragVector);
		}

		public static void ExecuteOnInputUp(Vector2 dragVector)
		{
			OnInputUp?.Invoke(dragVector);
		}

		public static void ExecuteOnCameraChangeToResult()
		{
			OnCameraChangeToResult?.Invoke();
		}

		public static void ExecuteOnThrowGameStateChange(GameManager.GameStateType gameStateType)
		{
			OnThrowGameStateChange?.Invoke(gameStateType);
		}

		public static void ExecuteOnLevelSucceed()
		{
			OnLevelSucceed?.Invoke();
		}

		public static void ExecuteOnLevelFailed()
		{
			OnLevelFailed?.Invoke();
		}
	}
}
