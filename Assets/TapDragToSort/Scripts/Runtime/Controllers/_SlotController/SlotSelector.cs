using Simofun.DevCaseStudy.Unity.Assets.TapDragToSort.Scripts.Runtime.Actors._Slot;
using Simofun.DevCaseStudy.Unity.Assets.TapDragToSort.Scripts.Runtime.Actors._Sortable.Abstract;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Simofun.DevCaseStudy.Unity.Assets.TapDragToSort.Scripts.Runtime.Controllers._SlotController
{
	[RequireComponent(typeof(SlotController))]
	public class SlotSelector : MonoBehaviour
	{
		#region FIELDS
		private Camera _mainCamera;
		private SlotController _slotController;
		#endregion

		#region SERIEALIZED_FIELDS
		[SerializeField] private LayerMask _slotLayerMask;
		[SerializeField] private GameManagerSort _gameManagerSort;
		#endregion


		private void Awake()
		{
			_mainCamera = Camera.main;
			_slotController = GetComponent<SlotController>();
		}

		private void Update()
		{
			if (Input.GetMouseButtonDown(0))
			{
				if(_gameManagerSort.CurrentGameStateType == _Common.Scripts.Managers.GameManager.GameStateType.GameRunning)
				{
					if (_slotController.SelectedSortable == null)
					{
						Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
						RaycastHit raycastHit;

						if (Physics.Raycast(ray, out raycastHit, 500, _slotLayerMask))
						{
							Slot slot = raycastHit.collider.GetComponent<Slot>();
							if (slot)
							{
								var sortable = slot.Sortable;
								if (sortable)
								{
									_slotController.SetSelectedSortable(sortable);
								}
							}

						}
					}
				}		
			
			}


			if (Input.GetMouseButtonUp(0))
			{
				if (_slotController.SelectedSortable == null) return;

				Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
				RaycastHit raycastHit;

				if (Physics.Raycast(ray, out raycastHit, 500, _slotLayerMask))
				{
					Slot slot = raycastHit.collider.GetComponent<Slot>();

					if (slot.Sortable == null)
					{
						_slotController.SelectedSortable.Slot.SetSortable(null);

						slot.SetSortable(_slotController.SelectedSortable);
						_slotController.SelectedSortable.SetSlot(slot);

						//PLACE THE SORTABLE TO SLOT
						_slotController.SelectedSortable.transform.position = slot.transform.position;

						//CHECK THE SLOTGROUP SUCCESS CONDITION
						bool isSlotGroupSuccesful = slot.SlotGroup.IsSlotGroupSuccessful();
						if (isSlotGroupSuccesful)
						{
							SortGameplayEvents.ExecuteOnSlotGroupSucceed(slot.SlotGroup);
						}


						//CHECK THE WIN CONDITION
						bool isWin = _slotController.IsWin();
						if (isWin)
						{
							SortGameplayEvents.ExecuteOnSortGameStateChange(_Common.Scripts.Managers.GameManager.GameStateType.GameFinished);
							SortGameplayEvents.ExecuteOnLevelSucceed();
						}

					}
					else if (slot.Sortable != null)
					{
						//PLACE THE SORTABLE TO INIT SLIT
						_slotController.SelectedSortable.transform.position = _slotController.SelectedSortable.Slot.transform.position;
					}

				}
				else
				{
					//PLACE THE SORTABLE TO INIT SLIT
					if (_slotController.SelectedSortable != null)
					{
						_slotController.SelectedSortable.transform.position = _slotController.SelectedSortable.Slot.transform.position;
					}

				}

				_slotController.SetSelectedSortable(null);
			}
		}
	}
}
