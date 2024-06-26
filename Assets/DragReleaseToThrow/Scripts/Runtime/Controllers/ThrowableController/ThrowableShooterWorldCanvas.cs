using Simofun.DevCaseStudy.Unity.Assets.DragReleaseToThrow.Scripts.Runtime.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Simofun.DevCaseStudy.Unity.Assets.DragReleaseToThrow.Scripts.Runtime.Controllers.ThrowableController
{
	[RequireComponent(typeof(IShooter))]
	public class ThrowableShooterWorldCanvas : MonoBehaviour
	{
		[SerializeField] private Image _insideImage;
		[SerializeField] private Image _outsideImage;

		private IShooter _throwableShooter;

		private void Awake()
		{
			_throwableShooter = GetComponent<ThrowableShooter>();
		}
		private void Start()
		{
			SetInsideImageFillAmount(0);

		}
		private void OnEnable()
		{
			ThrowGameplayEvents.OnInputDown += SetImagesActive;
			ThrowGameplayEvents.DragVector += SetForceIndicator;
			ThrowGameplayEvents.OnInputUp += SetImagesInactive;
		}

		private void OnDisable()
		{
			ThrowGameplayEvents.OnInputDown -= SetImagesActive;
			ThrowGameplayEvents.DragVector -= SetForceIndicator;
			ThrowGameplayEvents.OnInputUp -= SetImagesInactive;
		}

		private void SetForceIndicator(Vector2 dragVector)
		{
			float dragMagnitude = dragVector.magnitude;
			float ratio = dragMagnitude / _throwableShooter.MaxDragMagnitude;

			SetInsideImageFillAmount(ratio);
		}

		private void SetImagesActive()
		{
			SetActivenessOfImages(true);
		}
		private void SetImagesInactive(Vector2 dragVector)
		{
			SetActivenessOfImages(false);
		}


		private void SetInsideImageFillAmount(float fillAmount)
		{
			_insideImage.fillAmount = fillAmount;
		}

		private void SetActivenessOfImages(bool isActive)
		{
			_insideImage.gameObject.SetActive(isActive);
			_outsideImage.gameObject.SetActive(isActive);
		}
	}
}
