using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Simofun.DevCaseStudy.Unity.Assets.TapDragToSort.Scripts.Runtime.Controllers
{
	public class CameraController : MonoBehaviour
	{
		[field: SerializeField] public List<ParticleSystem> CameraConfettiParticles;

		private void OnEnable()
		{
			SortGameplayEvents.OnLevelSucceed += PlayConfettiParticles;
		}

		private void OnDisable()
		{
			SortGameplayEvents.OnLevelSucceed -= PlayConfettiParticles;
		}


		public void PlayConfettiParticles()
		{
			CameraConfettiParticles.ForEach(x => x.Play());
		}
	}
}
