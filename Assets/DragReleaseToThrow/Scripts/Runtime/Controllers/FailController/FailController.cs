using Simofun.DevCaseStudy.Unity.Assets._Common.Scripts.Managers;
using Simofun.DevCaseStudy.Unity.Assets.DragReleaseToThrow.Scripts.Runtime.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Simofun.DevCaseStudy.Unity
{
	public class FailController : MonoBehaviour
    {
		[SerializeField] private GameManager _gameManager;
		private void OnTriggerEnter(Collider other)
		{
			if (_gameManager.CurrentGameStateType != GameManager.GameStateType.GameRunning) return;

			Throwable throwable = other.GetComponent<Throwable>();
			if (throwable == null) return;

			Debug.Log("The game is failed");
			ThrowGameplayEvents.ExecuteOnThrowGameStateChange(GameManager.GameStateType.GameFinished);
			ThrowGameplayEvents.ExecuteOnLevelFailed();
		}
	}
}
