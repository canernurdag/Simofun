using Simofun.DevCaseStudy.Unity.Assets.TapDragToSort.Scripts.Runtime.Actors._Slot;
using Simofun.DevCaseStudy.Unity.Assets.TapDragToSort.Scripts.Runtime.Actors._Sortable.Concrete;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Simofun.DevCaseStudy.Unity.Assets.TapDragToSort.Scripts.Runtime.Actors._Sortable.Abstract
{
	[RequireComponent(typeof(SortableParticle))]
	[RequireComponent(typeof(SortableScaler))]
	public abstract class Sortable : MonoBehaviour
	{
		#region PROPERYs
		public SortableParticle SortableParticle { get; protected set; }
		public SortableScaler SortableScaler { get; protected set; }
		public Slot Slot { get; private set; }
		#endregion

		protected virtual void Awake()
		{
			SortableParticle = GetComponent<SortableParticle>();
			SortableScaler = GetComponent<SortableScaler>();
		}

		public void SetSlot(Slot slot)
		{
			Slot = slot;
		}
	}
}

