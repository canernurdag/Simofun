using Simofun.DevCaseStudy.Unity.Assets._Common.Scripts.Controllers;
using Simofun.DevCaseStudy.Unity.Assets.TapDragToClean.Scripts.Events;
using Simofun.DevCaseStudy.Unity.Assets.TapDragToClean.Scripts.Runtime.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Simofun.DevCaseStudy.Unity
{
    public class CameraParticleControllerSort : CameraParticleController
    {
		private void OnEnable()
		{
			SortGameplayEvents.OnLevelSucceed += PlayConfettiParticles;
		}

		private void OnDisable()
		{
			SortGameplayEvents.OnLevelSucceed -= PlayConfettiParticles;
		}
	}
}
