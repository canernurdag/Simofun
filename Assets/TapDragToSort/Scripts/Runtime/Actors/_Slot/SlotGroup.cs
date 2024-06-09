using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Simofun.DevCaseStudy.Unity.Assets.TapDragToSort.Scripts.Runtime.Actors._Slot
{
	public class SlotGroup : MonoBehaviour
	{
		public List<Slot> Slots { get; private set; } = new();

		private void Awake()
		{
			Slots = GetComponentsInChildren<Slot>().ToList(); ;
		}

		private void OnEnable()
		{
			SortGameplayEvents.OnSlotGroupSucceed += SlotGroupSuccessSeq;
		}

		private void OnDisable()
		{
			SortGameplayEvents.OnSlotGroupSucceed -= SlotGroupSuccessSeq;
		}

		public void SlotGroupSuccessSeq(SlotGroup slotGroup)
		{
			if (slotGroup != this) return;

			Slots.ForEach(x =>
			{
				x.Sortable.SortableParticle.ShineParticle.Play();
				x.Sortable.SortableScaler.ScaleSeq(1.2f, 0.3f);
			});
		}

		public bool IsSlotGroupSuccessful()
		{
			return IsSlotsAreFullWithTheSameSortable() || IsSlotsAreEmpty();
		}

		private bool IsSlotsAreFull()
		{
			return Slots.Count(x => x.Sortable != null) == Slots.Count;
		}

		private bool IsSlotsAreEmpty()
		{
			return Slots.Count(x => x.Sortable == null) == Slots.Count;
		}

		private bool IsSlotsAreFullWithTheSameSortable()
		{
			if (!IsSlotsAreFull()) return false;

			return Slots
				.Select(x => x.Sortable.GetType())
				.Distinct()
				.Count() == 1;
		}
	}
}
