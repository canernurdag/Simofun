using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Simofun.DevCaseStudy.Unity.Assets.TapDragToSort.Scripts.Runtime.Controllers._SlotController
{
	
	[RequireComponent(typeof(SlotController))]
	public class SlotSortableDragger : MonoBehaviour
	{
		#region FIELDS
		private Camera _mainCamera;
		private SlotController _slotController;
		#endregion

		#region SERIEALIZED_FIELDS
		[SerializeField] private float _distanceZ = 30;
		#endregion

		private void Awake()
		{
			_mainCamera = Camera.main;
			_slotController = GetComponent<SlotController>();
		}
		private void Update()
		{
			if (Input.GetMouseButton(0))
			{
				if (_slotController.SelectedSortable != null)
				{
					var mousePosition = Input.mousePosition;
					mousePosition.z = _distanceZ;
					Vector3 targetPos = _mainCamera.ScreenToWorldPoint(mousePosition);
					_slotController.SelectedSortable.transform.position = targetPos;
				}
			}
		}
	}
}
