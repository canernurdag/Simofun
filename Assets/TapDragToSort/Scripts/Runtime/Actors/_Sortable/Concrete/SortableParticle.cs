using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Simofun.DevCaseStudy.Unity.Assets.TapDragToSort.Scripts.Runtime.Actors._Sortable.Concrete
{
	public class SortableParticle : MonoBehaviour
	{
		[field: SerializeField] public ParticleSystem ShineParticle { get; private set; }
	}
}
