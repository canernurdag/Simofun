using Simofun.DevCaseStudy.Unity.Assets._Common.Scripts.Controllers;
using Simofun.DevCaseStudy.Unity.Assets.DragReleaseToThrow.Scripts.Runtime.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Simofun.DevCaseStudy.Unity.Assets.DragReleaseToThrow.Scripts.Runtime.Controllers
{
	public class CameraParticleControllerThrow : CameraParticleController
	{
		private void OnEnable()
		{
			ThrowGameplayEvents.OnLevelSucceed += PlayConfettiParticles;
		}

		private void OnDisable()
		{
			ThrowGameplayEvents.OnLevelSucceed -= PlayConfettiParticles;
		}
	}
}
