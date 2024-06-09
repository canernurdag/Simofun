using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Simofun.DevCaseStudy.Unity.Assets.DragReleaseToThrow.Scripts.Runtime.Controllers.ThrowableController
{
	public class ThrowableSpawner: MonoBehaviour, ISpawner<Throwable>
	{

		[SerializeField] private Throwable _throwablePrefab;
		[SerializeField] private Transform _spawnPosTransform;

		public Throwable Spawn()
		{
			var newThrowable = Instantiate(_throwablePrefab);
			newThrowable.transform.parent = null;
			newThrowable.transform.position = _spawnPosTransform.position;
			newThrowable.transform.rotation = Quaternion.identity;

			return newThrowable;
		}
	}
}
