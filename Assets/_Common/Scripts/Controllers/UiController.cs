using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Simofun.DevCaseStudy.Unity.Assets._Common.Scripts.Controllers
{
	public abstract class UiController : MonoBehaviour
	{
		[SerializeField] protected Transform _successPanel;
		[SerializeField] protected Transform _failPanel;
		[SerializeField] protected Tween _scaleTween;

		

		protected virtual void Start()
		{
			_successPanel.gameObject.SetActive(false);
			_failPanel.gameObject.SetActive(false);
		}

		protected void SuccessPanelOpen()
		{
			_successPanel.gameObject.SetActive(true);
			_scaleTween?.Kill();
			_successPanel.transform.localScale = Vector3.zero;
			_scaleTween = _successPanel.transform.DOScale(1, 0.4f)
				.SetDelay(1f);

		}

		protected void FailPanelOpen()
		{
			_failPanel.gameObject.SetActive(true);
			_scaleTween?.Kill();
			_failPanel.transform.localScale = Vector3.zero;
			_scaleTween = _failPanel.transform.DOScale(1, 0.4f)
				.SetDelay(1f);
		}
	}
}
