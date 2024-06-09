using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Simofun.DevCaseStudy.Unity.Assets.TapDragToSort.Scripts.Runtime.Actors._Sortable.Concrete
{
	public class SortableScaler : MonoBehaviour
	{
		private Tween _scaleTween;
		private Vector3 _initScale;

		private void Awake()
		{
			_initScale = transform.localScale;
		}

		public void ScaleSeq(float scaler, float duration)
		{
			_scaleTween?.Kill();
			transform.localScale = _initScale;
			_scaleTween = transform.DOScale(scaler, duration)
				.SetLoops(2, LoopType.Yoyo);

		}
	}
}
