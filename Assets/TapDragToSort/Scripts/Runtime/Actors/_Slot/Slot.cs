using Simofun.DevCaseStudy.Unity.Assets.TapDragToSort.Scripts.Runtime.Actors._Slot.Indicator;
using Simofun.DevCaseStudy.Unity.Assets.TapDragToSort.Scripts.Runtime.Actors._Sortable.Abstract;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Simofun.DevCaseStudy.Unity.Assets.TapDragToSort.Scripts.Runtime.Actors._Slot
{
	[RequireComponent(typeof(IIndicator))]
	public class Slot : MonoBehaviour
	{
		public SlotGroup SlotGroup { get; private set; }
		public IIndicator Indicator { get; private set; }
		public Sortable Sortable { get; private set; } = null;
		private Transform _sortableParent;

		private void Awake()
		{
			Indicator = GetComponent<IIndicator>();
			SlotGroup = GetComponentInParent<SlotGroup>();

			_sortableParent = transform.GetChild(0);
			SetPredefinedSortables();
		}

		private void SetPredefinedSortables()
		{
			var currentSortable = GetComponentInChildren<Sortable>(true);
			if (currentSortable)
			{
				SetSortable(currentSortable);
			}
		}

		public void SetSortable(Sortable sortable)
		{
			Sortable = sortable;
			if (sortable != null)
			{
				sortable.SetSlot(this);
				sortable.transform.SetParent(_sortableParent);

				Indicator?.SetActivenessOfIndicator(false);
			}
			else if(sortable == null)
			{
				Indicator?.SetActivenessOfIndicator(true);
				Indicator?.SetIndicatorColor(Color.white);
			}

		}

		#region EDITOR UTILS
		public void SetSortableEditor(Sortable sortable)
		{
			if (Sortable != null) return;
			Sortable = sortable;
			sortable.SetSlot(this);
			if (sortable != null) sortable.transform.SetParent(_sortableParent);
			sortable.transform.localPosition = Vector3.zero;
		}

		public void DestroyEditor()
		{
			if (Sortable == null) return;
			DestroyImmediate(Sortable.gameObject);
			Sortable = null;
		}

		public void SetSortableParentEditor(Transform parent)
		{
			_sortableParent = parent;
		}
		#endregion


	}
}
