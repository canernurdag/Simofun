using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Simofun.DevCaseStudy.Unity.Assets.DragReleaseToThrow.Scripts.Runtime.Managers
{
	public class GameManager : MonoBehaviour
	{
		public GameStateType CurrentGameStateType { get; private set; }

		public void SetCurrentGameStateType(GameStateType gameStateType)
		{
			CurrentGameStateType = gameStateType;
			switch (CurrentGameStateType)
			{
				case GameStateType.None:
					break;
				case GameStateType.GameRunning:
					Debug.Log("Game is Running");
					break;
				case GameStateType.GameFinished:
					Debug.Log("Game is Finished");
					break;
			}
		}
		public enum GameStateType
		{
			None = 0,
			GameRunning = 1,
			GameFinished = 2
		}
	}
}
