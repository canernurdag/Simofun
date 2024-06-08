using Simofun.DevCaseStudy.Unity.Assets.DragReleaseToThrow.Scripts.Runtime.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Simofun.DevCaseStudy.Unity.Assets.DragReleaseToThrow.Scripts.Runtime.Managers
{
	public class InputManager : MonoBehaviour
	{
		private Vector2 _firstTouchPosition, _lastTouchPosition;
		private bool _isInputExist = false;


		private void Update()
		{
			if (!_isInputExist)
			{
				if (Input.GetMouseButtonDown(0))
				{
					_isInputExist = true;
					_firstTouchPosition = Input.mousePosition;
					GameplayEvents.ExecuteOnInputDown();
				}
			}
			else if (_isInputExist)
			{
				Vector2 dragVector = _lastTouchPosition - _firstTouchPosition;
	

				if (Input.GetMouseButtonUp(0))
				{
					_isInputExist = false;
					_lastTouchPosition = Input.mousePosition;

					GameplayEvents.ExecuteOnInputUp(dragVector);
				}

				if (Input.GetMouseButton(0))
				{
					_lastTouchPosition = Input.mousePosition;
					GameplayEvents.ExecuteDragInput(dragVector);
				}
			}

		}
	}
}
