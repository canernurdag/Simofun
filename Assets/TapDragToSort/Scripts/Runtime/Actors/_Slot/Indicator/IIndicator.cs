using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Simofun.DevCaseStudy.Unity.Assets.TapDragToSort.Scripts.Runtime.Actors._Slot.Indicator
{
	public interface IIndicator
	{
		void SetActivenessOfIndicator(bool isActive);
		void SetIndicatorColor(Color color);
	}
}
