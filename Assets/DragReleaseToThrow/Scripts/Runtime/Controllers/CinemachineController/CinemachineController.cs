using Simofun.DevCaseStudy.Unity.Assets.DragReleaseToThrow.Scripts.Runtime.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Simofun.DevCaseStudy.Unity
{
    public class CinemachineController : MonoBehaviour
    {
        [SerializeField] private Animator _stateDrivenAnimator;


		private void OnEnable()
		{
			GameplayEvents.OnInputUp += SetCameraAsResult;
		}

		private void OnDisable()
		{
			GameplayEvents.OnInputUp -= SetCameraAsResult;
		}

		private void SetCameraAsResult(Vector2 dragVector)
		{
			StartCoroutine(SetCameraStateWithDelay(0.8f, "Result"));
		}

		private IEnumerator SetCameraStateWithDelay(float delay, string animValue)
		{
			yield return new WaitForSeconds(delay);
			SetCameraState(animValue);
		}

		private void SetCameraState(string animValue)
        {
            _stateDrivenAnimator.SetTrigger(animValue);
        }
    }
}
