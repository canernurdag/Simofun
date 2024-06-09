using Simofun.DevCaseStudy.Unity.Assets._Common.Scripts.Managers;
using Simofun.DevCaseStudy.Unity.Assets.TapDragToSort.Scripts.Runtime.Actors._Slot;
using Simofun.DevCaseStudy.Unity.Assets.TapDragToSort.Scripts.Runtime.Actors._Sortable.Abstract;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Simofun.DevCaseStudy.Unity
{
	public static class SortGameplayEvents 
	{
		public static event Action<Sortable> OnSelectedSortableSet;

		public static event Action<RaycastHit> OnRaycastHit;

		public static event Action<Vector2> OnInputDrag;
		public static event Action OnInputUp;

		public static event Action<GameManager.GameStateType> OnSortGameStateChange;
		public static event Action OnLevelSucceed;

		public static event Action<SlotGroup> OnSlotGroupSucceed;
		public static event Action OnWinCheck;

		public static void ExecuteOnSelectedSortableSet(Sortable sortable)
		{
			OnSelectedSortableSet?.Invoke(sortable);
		}
		public static void ExecuteOnRaycastHit(RaycastHit raycastHit)
		{
			OnRaycastHit?.Invoke(raycastHit);
		}

		public static void ExecuteOnInputDrag(Vector2 mousePosition)
		{
			OnInputDrag?.Invoke(mousePosition);
		}

		public static void ExecuteOnInputUp()
		{
			OnInputUp?.Invoke();
		}

		public static void ExecuteOnSortGameStateChange(GameManager.GameStateType gameStateType)
		{
			OnSortGameStateChange?.Invoke(gameStateType);
		}
		public static void ExecuteOnLevelSucceed()
		{
			OnLevelSucceed?.Invoke();
		}

		public static void ExecuteOnSlotGroupSucceed(SlotGroup slotGroup )
		{
			OnSlotGroupSucceed?.Invoke(slotGroup);
		}

		public static void ExecuteOnWinCheck()
		{
			OnWinCheck?.Invoke();
		}
	}
}
