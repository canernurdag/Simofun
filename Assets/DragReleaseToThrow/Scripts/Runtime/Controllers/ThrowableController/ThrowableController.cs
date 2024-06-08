using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Simofun.DevCaseStudy.Unity.Assets.DragReleaseToThrow.Scripts.Runtime.Controllers.ThrowableController
{
	[RequireComponent(typeof(ThrowableSpawner))]
	public class ThrowableController : MonoBehaviour
	{
		public Throwable ActiveThrowable { get; private set; }
		private ThrowableSpawner _throwableSpawner;


		private void Awake()
		{
			_throwableSpawner = GetComponent<ThrowableSpawner>();
		}

		private void Start()
		{
			_throwableSpawner.Spawn();
		}

		public void SetActiveThrowable(Throwable throwable)
		{
			ActiveThrowable = throwable;
		}
	}
}
