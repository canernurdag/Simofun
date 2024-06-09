using Simofun.DevCaseStudy.Unity.Assets.TapDragToSort.Scripts.Runtime.Actors._Slot;
using Simofun.DevCaseStudy.Unity.Assets.TapDragToSort.Scripts.Runtime.Actors._Sortable.Abstract;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Simofun.DevCaseStudy.Unity.Assets.TapDragToSort.Scripts.Runtime.Controllers._SlotController
{
	[RequireComponent(typeof(IControlSelectedSortable))]
	public class SlotSelector : MonoBehaviour
	{
		#region FIELDS
		private Camera _mainCamera;
		private IControlSelectedSortable _controlSelectedSortable;
		#endregion

		#region SERIEALIZED_FIELDS
		[SerializeField] private LayerMask _slotLayerMask;
		[SerializeField] private GameManagerSort _gameManagerSort;
		#endregion


		private void Awake()
		{
			_mainCamera = Camera.main;
			_controlSelectedSortable = GetComponent<IControlSelectedSortable>();
		}

		private void Update()
		{
			if (Input.GetMouseButtonDown(0))
			{
				if(_gameManagerSort.CurrentGameStateType == _Common.Scripts.Managers.GameManager.GameStateType.GameRunning)
				{
					if (_controlSelectedSortable.SelectedSortable == null)
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
									SortGameplayEvents.ExecuteOnSelectedSortableSet(sortable);
								}
							}

						}
					}
				}		
			
			}


			if (Input.GetMouseButtonUp(0))
			{
				if (_controlSelectedSortable.SelectedSortable == null) return;

				Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
				RaycastHit raycastHit;

				if (Physics.Raycast(ray, out raycastHit, 500, _slotLayerMask))
				{
					Slot slot = raycastHit.collider.GetComponent<Slot>();

					if (slot.Sortable == null)
					{
						_controlSelectedSortable.SelectedSortable.Slot.SetSortable(null);

						slot.SetSortable(_controlSelectedSortable.SelectedSortable);
						_controlSelectedSortable.SelectedSortable.SetSlot(slot);

						//PLACE THE SORTABLE TO SLOT
						_controlSelectedSortable.SelectedSortable.transform.position = slot.transform.position;

						//CHECK THE SLOTGROUP SUCCESS CONDITION
						bool isSlotGroupSuccesful = slot.SlotGroup.IsSlotGroupSuccessful();
						if (isSlotGroupSuccesful)
						{
							SortGameplayEvents.ExecuteOnSlotGroupSucceed(slot.SlotGroup);
						}

						//CHECK THE WIN CONDITION
						SortGameplayEvents.ExecuteOnWinCheck();
			
						

					}
					else if (slot.Sortable != null)
					{
						//PLACE THE SORTABLE TO INIT SLIT
						_controlSelectedSortable.SelectedSortable.transform.position = _controlSelectedSortable.SelectedSortable.Slot.transform.position;
					}

				}
				else
				{
					//PLACE THE SORTABLE TO INIT SLIT
					if (_controlSelectedSortable.SelectedSortable != null)
					{
						_controlSelectedSortable.SelectedSortable.transform.position = _controlSelectedSortable.SelectedSortable.Slot.transform.position;
					}

				}

				SortGameplayEvents.ExecuteOnSelectedSortableSet(null);
			}
		}
	}
}
