using Simofun.DevCaseStudy.Unity.Assets.DragReleaseToThrow.Scripts.Runtime.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Simofun.DevCaseStudy.Unity.Assets.DragReleaseToThrow.Scripts.Runtime.Controllers.ThrowableController
{
	public class ThrowableShooterRotator : MonoBehaviour
	{
		private bool _preventRotate = false;

		private void OnEnable()
		{
			GameplayEvents.DragVector += RotateThrowableByInput;
		}

		private void OnDisable()
		{
			GameplayEvents.DragVector -= RotateThrowableByInput;
		}

		private void RotateThrowableByInput(Vector2 dragVector)
		{
			if (_preventRotate) return;

			Vector2 directionInScreenSpaceDirection = dragVector.normalized;
			Vector3 directionWorldSpace = new Vector3(directionInScreenSpaceDirection.x, 0, directionInScreenSpaceDirection.y);

			//Reverse input for opposite direction
			directionWorldSpace *= -1;

			transform.rotation = Quaternion.LookRotation(directionWorldSpace);

		}

		public void SetPreventRotate(bool isPreventRotate)
		{
			_preventRotate = isPreventRotate;
		}
	}
}
