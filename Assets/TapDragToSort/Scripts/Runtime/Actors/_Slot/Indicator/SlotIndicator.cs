using Simofun.DevCaseStudy.Unity.Assets.TapDragToSort.Scripts.Runtime.Actors._Slot.Indicator;
using Simofun.DevCaseStudy.Unity.Assets.TapDragToSort.Scripts.Runtime.Actors._Sortable.Abstract;
using Simofun.DevCaseStudy.Unity.Assets.TapDragToSort.Scripts.Runtime.Controllers._SlotController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Simofun.DevCaseStudy.Unity.Assets.TapDragToSort.Scripts.Runtime.Actors._Slot
{
	[RequireComponent(typeof(Slot))]
	public class SlotIndicator : MonoBehaviour, IIndicator
	{
		[SerializeField] private SpriteRenderer _indicator;
		private bool _preventColorChange = true;

		private void OnEnable()
		{
			SortGameplayEvents.OnSelectedSortableSet += SetPreventColorChange;
		}

		private void OnDisable()
		{
			SortGameplayEvents.OnSelectedSortableSet -= SetPreventColorChange;
		}


		private void OnMouseEnter()
		{
			if (_preventColorChange) return;
			SetIndicatorColor(Color.green);
		}

		private void OnMouseExit()
		{
			if (_preventColorChange) return;
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

		private  void SetPreventColorChange(Sortable sortable)
		{
			_preventColorChange = sortable == null;
		}
	}
}
