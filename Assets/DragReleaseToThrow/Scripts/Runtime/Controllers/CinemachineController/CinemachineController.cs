using Simofun.DevCaseStudy.Unity.Assets.DragReleaseToThrow.Scripts.Runtime.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Simofun.DevCaseStudy.Unity.Assets.DragReleaseToThrow.Scripts.Runtime.Controllers.CinemachineController
{
	public class CinemachineController : MonoBehaviour
	{
		[SerializeField] private Animator _stateDrivenAnimator;


		private void OnEnable()
		{
			ThrowGameplayEvents.OnCameraChangeToResult += SetCameraAsResult;
		}

		private void OnDisable()
		{
			ThrowGameplayEvents.OnCameraChangeToResult -= SetCameraAsResult;
		}

		private void SetCameraAsResult()
		{
			SetCameraState("Result");
		}


		private void SetCameraState(string animValue)
		{
			_stateDrivenAnimator.SetTrigger(animValue);
		}
	}
}
