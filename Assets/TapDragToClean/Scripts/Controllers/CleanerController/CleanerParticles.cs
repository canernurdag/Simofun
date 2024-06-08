using Simofun.DevCaseStudy.Unity.Assets.TapDragToClean.Scripts.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Simofun.DevCaseStudy.Unity
{
    public class CleanerParticles : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _shineParticle;
        [SerializeField] private ParticleSystem _dustParticle;

		private void OnEnable()
		{
			CleanGameplayEvents.OnRaycastHit += SetParticlesActive;
			CleanGameplayEvents.OnRaycastNotHit += SetParticlesInactive;
			CleanGameplayEvents.OnInputUp += SetParticlesInactive;
		}

		private void OnDisable()
		{
			CleanGameplayEvents.OnRaycastHit -= SetParticlesActive;
			CleanGameplayEvents.OnRaycastNotHit -= SetParticlesInactive;
			CleanGameplayEvents.OnInputUp -= SetParticlesInactive;
		}

		private void Start()
		{
			SetParticlesActiveness(false);
		}

		private void SetParticlesActive(RaycastHit raycastHit)
		{
			SetParticlesActiveness(true);
		}

		private void SetParticlesInactive()
		{
			SetParticlesActiveness(false);
		}

		private void SetParticlesInactive(Vector3 mousePosition)
		{
			SetParticlesActiveness(false);
		}

		private void SetParticlesActiveness(bool isActive)
		{
			if(isActive)
			{
				_shineParticle.gameObject.SetActive(true);
				_dustParticle.Play();
			}
			else if(!isActive)
			{
				_shineParticle.gameObject.SetActive(false);
				_dustParticle.Stop();
			}
	
		}
	}
}
