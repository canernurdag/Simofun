using Simofun.DevCaseStudy.Unity.Assets.TapDragToSort.Scripts.Runtime.Actors._Slot;
using Simofun.DevCaseStudy.Unity.Assets.TapDragToSort.Scripts.Runtime.Actors._Sortable.Abstract;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Simofun.DevCaseStudy.Unity.Assets.TapDragToSort.Scripts.Runtime.Controllers._SlotController
{
	public class SlotController : MonoBehaviour
	{
		[SerializeField] private Transform _slotGroupsParent;

		public List<SlotGroup> SlotGroups { get; private set; } = new();
		public Sortable SelectedSortable { get; private set; } = null;
	

		private void Awake()
		{
			SlotGroups = _slotGroupsParent.GetComponentsInChildren<SlotGroup>().ToList();
		}
		private void Start()
		{
			SlotGroups.ForEach(x =>
			{
				x.Slots.ForEach(y => { y.SlotIndicator.SetSlotController(this); });
			});
		}


		public void SetSelectedSortable(Sortable sortable)
		{
			SelectedSortable = sortable;
		}

		public bool IsWin()
		{
			return SlotGroups.All(x => x.IsSlotGroupSuccessful());
		}
	}
}
