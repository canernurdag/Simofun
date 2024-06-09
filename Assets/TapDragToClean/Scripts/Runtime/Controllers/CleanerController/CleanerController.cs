using Simofun.DevCaseStudy.Unity.Assets.TapDragToClean.Scripts.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Simofun.DevCaseStudy.Unity.Assets.TapDragToClean.Scripts.Controllers.CleanerController
{
	public class CleanerController : MonoBehaviour
	{
		[SerializeField] private Cleaner _levelCleaner;
		public Cleaner ActiveCleaner { get; private set; }
		private Camera _mainCamera;

		private void Awake()
		{
			_mainCamera = Camera.main;
		}

		private void Start()
		{
			SetActiveClenaer(_levelCleaner);
		}

		private void Update()
		{
			if (!_mainCamera) return;

			if (Input.GetMouseButton(0))
			{
				CleanGameplayEvents.ExecuteOnInputDown();

				RaycastHit raycastHit;
				bool isRaycastHit = Physics.Raycast(_mainCamera.ScreenPointToRay(Input.mousePosition), out raycastHit);
				if (isRaycastHit)
				{
					CleanGameplayEvents.ExecuteOnRaycastHit(raycastHit);
				}
				else if (!isRaycastHit)
				{
					CleanGameplayEvents.ExecuteOnRaycastNotHit(Input.mousePosition);

				}
			}

			else if (!Input.GetMouseButton(0))
			{
				CleanGameplayEvents.ExecuteOnInputUp();
			}

		}


		public void SetActiveClenaer(Cleaner cleaner)
		{
			ActiveCleaner = cleaner;
			CleanGameplayEvents.ExecuteOnCleanerSet(cleaner);
		}

	}
}
