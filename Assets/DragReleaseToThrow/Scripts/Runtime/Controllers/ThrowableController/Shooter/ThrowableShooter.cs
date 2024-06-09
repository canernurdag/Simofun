using Simofun.DevCaseStudy.Unity.Assets.DragReleaseToThrow.Scripts.Runtime.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Simofun.DevCaseStudy.Unity.Assets.DragReleaseToThrow.Scripts.Runtime.Controllers.ThrowableController
{
	[RequireComponent(typeof(ThrowableController))]
	public class ThrowableShooter : MonoBehaviour , IShooter
	{
		private ThrowableController _throwableController;

		#region SHOOT SETTINGS
		[field: SerializeField] public float MaxDragMagnitude { get; set; }
		[field: SerializeField] public float ForceMultiplier { get; set; }
		#endregion


		private void Awake()
		{
			_throwableController = GetComponent<ThrowableController>();
		}

		private void OnEnable()
		{
			ThrowGameplayEvents.OnInputUp += Shoot;
		}

		private void OnDisable()
		{
			ThrowGameplayEvents.OnInputUp -= Shoot;
		}

		public void Shoot(Vector2 dragVector)
		{
			if (_throwableController.ActiveThrowable == null) return;


			float dragMagnitude = dragVector.magnitude;
			float ratio = dragMagnitude / MaxDragMagnitude;

			Vector3 directionScreenSpace = dragVector.normalized;

			//Reverse input for opposite direction
			directionScreenSpace *= -1;

			Vector3 directionWorldSpace = new Vector3(directionScreenSpace.x, 0, directionScreenSpace.y);

			Vector3 force = directionWorldSpace * ratio * ForceMultiplier;

			_throwableController.ActiveThrowable.Rigidbody.AddForce(force);



		}
	}
}
