using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Simofun.DevCaseStudy.Unity.Assets.TapDragToClean.Scripts.Events
{
	public static class CleanGameplayEvents
	{
		public static event Action<Cleaner> OnCleanerSet;

		public static event Action<RaycastHit> OnRaycastHit;
		public static event Action<Vector3> OnRaycastNotHit;

		public static event Action OnInputDown;
		public static event Action OnInputUp;

		public static event Action<float> OnTextureManipulationRationChanged;


		public static void ExecuteOnCleanerSet(Cleaner cleaner)
		{
			OnCleanerSet?.Invoke(cleaner);
		}
		public static void ExecuteOnRaycastHit(RaycastHit raycastHit)
		{
			OnRaycastHit?.Invoke(raycastHit);
		}

		public static void ExecuteOnRaycastNotHit(Vector3 mousePosition)
		{
			OnRaycastNotHit?.Invoke(mousePosition);
		}

		public static void ExecuteOnInputDown()
		{
			OnInputDown?.Invoke();
		}

		public static void ExecuteOnInputUp()
		{
			OnInputUp?.Invoke();
		}

		public static void ExecuteOnTextureManipulationRationChanged(float newRatio)
		{
			OnTextureManipulationRationChanged?.Invoke(newRatio);
		}
	}
}
