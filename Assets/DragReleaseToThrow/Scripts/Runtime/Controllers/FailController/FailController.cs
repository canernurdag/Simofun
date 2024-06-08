using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Simofun.DevCaseStudy.Unity
{
    public class FailController : MonoBehaviour
    {
		private void OnTriggerEnter(Collider other)
		{
			Throwable throwable = other.GetComponent<Throwable>();
			if (throwable == null) return;

			Debug.Log("The game is failed");
		}
	}
}
