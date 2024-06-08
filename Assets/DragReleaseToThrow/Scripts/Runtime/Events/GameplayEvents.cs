using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Simofun.DevCaseStudy.Unity.Assets.DragReleaseToThrow.Scripts.Runtime.Events
{
	public static class GameplayEvents
	{
		public static event Action OnInputDown;
		public static event Action<Vector2> DragVector;
		public static event Action<Vector2> OnInputUp;

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

	}
}
