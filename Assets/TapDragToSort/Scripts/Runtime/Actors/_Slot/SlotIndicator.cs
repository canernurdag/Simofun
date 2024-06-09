using Simofun.DevCaseStudy.Unity.Assets.TapDragToSort.Scripts.Runtime.Controllers._SlotController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Simofun.DevCaseStudy.Unity.Assets.TapDragToSort.Scripts.Runtime.Actors._Slot
{
	[RequireComponent(typeof(Slot))]
	public class SlotIndicator : MonoBehaviour
	{
		private SlotController _slotController;
		[SerializeField] private SpriteRenderer _indicator;

	
		private void OnMouseEnter()
		{
			if (_slotController.SelectedSortable == null) return;

			SetIndicatorColor(Color.green);
		}

		private void OnMouseExit()
		{
			if (_slotController.SelectedSortable == null) return;

			SetIndicatorColor(Color.white);
		}

		public void SetActivenessOfIndicator(bool isActive)
		{
			_indicator.gameObject.SetActive(isActive);
		}

		public void SetIndicatorColor(Color color)
		{
			_indicator.color = color;
		}

		public void SetSlotController(SlotController slotController)
		{
			_slotController = slotController;
		}
	}
}
