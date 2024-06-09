using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Simofun.DevCaseStudy.Unity.Assets.DragReleaseToThrow.Scripts.Runtime.Controllers.ThrowableController
{
	[RequireComponent(typeof(ISpawner<Throwable>))]
	public class ThrowableController : MonoBehaviour
	{
		public Throwable ActiveThrowable { get; private set; }
		private ISpawner<Throwable> _throwableSpawner;


		private void Awake()
		{
			_throwableSpawner = GetComponent<ISpawner<Throwable>>();
		}

		private void Start()
		{
			var throwable = _throwableSpawner.Spawn();
			SetActiveThrowable(throwable);
		}

		public void SetActiveThrowable(Throwable throwable)
		{
			ActiveThrowable = throwable;
		}
	}
}
