using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Simofun.DevCaseStudy.Unity.Assets.TapDragToSort.Scripts.Runtime.Controllers._SlotController
{
	
	[RequireComponent(typeof(IControlSelectedSortable))]
	public class SlotSortableDragger : MonoBehaviour
	{
		#region FIELDS
		private Camera _mainCamera;
		private IControlSelectedSortable _controlSelectedSortable;
		#endregion

		#region SERIEALIZED_FIELDS
		[SerializeField] private float _distanceZ = 30;
		#endregion

		private void Awake()
		{
			_mainCamera = Camera.main;
			_controlSelectedSortable = GetComponent<IControlSelectedSortable>();
		}
		private void Update()
		{
			if (Input.GetMouseButton(0))
			{
				if (_controlSelectedSortable.SelectedSortable != null)
				{
					var mousePosition = Input.mousePosition;
					mousePosition.z = _distanceZ;
					Vector3 targetPos = _mainCamera.ScreenToWorldPoint(mousePosition);
					_controlSelectedSortable.SelectedSortable.transform.position = targetPos;
				}
			}
		}
	}
}
