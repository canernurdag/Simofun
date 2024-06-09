using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Simofun.DevCaseStudy.Unity.Assets._Common.Scripts.Controllers
{
	public abstract class CameraParticleController : MonoBehaviour
	{
		[field: SerializeField] public List<ParticleSystem> CameraConfettiParticles;


		public void PlayConfettiParticles()
		{
			CameraConfettiParticles.ForEach(x => x.Play());
		}
	}
}
