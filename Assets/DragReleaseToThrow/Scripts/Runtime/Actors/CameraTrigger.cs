using Simofun.DevCaseStudy.Unity.Assets.DragReleaseToThrow.Scripts.Runtime.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Simofun.DevCaseStudy.Unity.Assets.DragReleaseToThrow.Scripts.Runtime.Actors
{
	public class CameraTrigger : MonoBehaviour
	{
		private void OnTriggerEnter(Collider other)
		{
			var throwable = other.GetComponent<Throwable>();
			if (!throwable) return;

			ThrowGameplayEvents.ExecuteOnCameraChangeToResult();
		}
	}
}
