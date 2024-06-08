using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Simofun.DevCaseStudy.Unity
{
	[RequireComponent(typeof(Rigidbody))]
	public class Throwable : MonoBehaviour
	{
		public Rigidbody Rigidbody { get; private set; }

		private void Awake()
		{
			Rigidbody = GetComponent<Rigidbody>();	
		}

		
	}
}
