using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Simofun.DevCaseStudy.Unity
{
    public interface IShooter 
    {
        void Shoot(Vector2 dragVector);
		float MaxDragMagnitude { get; set; }
		float ForceMultiplier { get; set; }
	}
}
