using Simofun.DevCaseStudy.Unity.Assets._Common.Scripts.Controllers;
using Simofun.DevCaseStudy.Unity.Assets.DragReleaseToThrow.Scripts.Runtime.Controllers;
using Simofun.DevCaseStudy.Unity.Assets.DragReleaseToThrow.Scripts.Runtime.Events;
using Simofun.DevCaseStudy.Unity.Assets.TapDragToClean.Scripts.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Simofun.DevCaseStudy.Unity.Assets.TapDragToClean.Scripts.Runtime.Controllers
{
	public class CameraParticleControllerClean : CameraParticleController
	{
		private void OnEnable()
		{
			CleanGameplayEvents.OnLevelSucceed += PlayConfettiParticles;
		}

		private void OnDisable()
		{
			CleanGameplayEvents.OnLevelSucceed -= PlayConfettiParticles;
		}
	}
}
