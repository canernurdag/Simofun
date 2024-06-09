using Simofun.DevCaseStudy.Unity.Assets.TapDragToSort.Scripts.Runtime.Actors._Slot;
using Simofun.DevCaseStudy.Unity.Assets.TapDragToSort.Scripts.Runtime.Actors._Sortable.Abstract;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Simofun.DevCaseStudy.Unity.Assets.TapDragToSort.Scripts.Runtime.Controllers._SlotController
{
	public class SlotController : MonoBehaviour, IControlSelectedSortable
	{
		[SerializeField] private Transform _slotGroupsParent;

		public List<SlotGroup> SlotGroups { get; private set; } = new();
		public Sortable SelectedSortable { get; set; } = null;
	

		private void Awake()
		{
			SlotGroups = _slotGroupsParent.GetComponentsInChildren<SlotGroup>().ToList();
		}

		private void OnEnable()
		{
			SortGameplayEvents.OnSelectedSortableSet += SetSelectedSortable;
			SortGameplayEvents.OnWinCheck += ExecuteWinCheck;
		}

		private void OnDisable()
		{
			SortGameplayEvents.OnSelectedSortableSet -= SetSelectedSortable;
			SortGameplayEvents.OnWinCheck -= ExecuteWinCheck;
		}
		private void SetSelectedSortable(Sortable sortable)
		{
			SelectedSortable = sortable;
		}

		public void ExecuteWinCheck()
		{
			bool isWin = IsWin();
			if (isWin)
			{
				SortGameplayEvents.ExecuteOnSortGameStateChange(_Common.Scripts.Managers.GameManager.GameStateType.GameFinished);
				SortGameplayEvents.ExecuteOnLevelSucceed();
			}
		}
		private bool IsWin()
		{
			return SlotGroups.All(x => x.IsSlotGroupSuccessful());
		}
	}
}
