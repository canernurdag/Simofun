using Simofun.DevCaseStudy.Unity.Assets._Common.Scripts.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Simofun.DevCaseStudy.Unity
{
    public class UiControllerSort : UiController
    {
		private void OnEnable()
		{
			SortGameplayEvents.OnLevelSucceed += SuccessPanelOpen;
		}

		private void OnDisable()
		{
			SortGameplayEvents.OnLevelSucceed -= SuccessPanelOpen;
		}
	}
}
