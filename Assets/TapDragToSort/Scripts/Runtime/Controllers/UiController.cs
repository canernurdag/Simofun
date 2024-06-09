using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Simofun.DevCaseStudy.Unity.Assets.TapDragToSort.Scripts.Runtime.Controllers
{
	public class UiController : MonoBehaviour
	{
		[SerializeField] private Transform _successPanel;
		[SerializeField] private Tween _scaleTween;

		private void OnEnable()
		{
			SortGameplayEvents.OnLevelSucceed += SuccessPanelOpen;
		}

		private void OnDisable()
		{
			SortGameplayEvents.OnLevelSucceed -= SuccessPanelOpen;
		}

		private void Start()
		{
			_successPanel.gameObject.SetActive(false);
		}

		private void SuccessPanelOpen()
		{
			_successPanel.gameObject.SetActive(true);
			_scaleTween?.Kill();
			_successPanel.transform.localScale = Vector3.zero;
			_scaleTween = _successPanel.transform.DOScale(1, 0.4f)
				.SetDelay(1f);

		}
	}
}
