using Simofun.DevCaseStudy.Unity.Assets.TapDragToClean.Scripts.Events;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Simofun.DevCaseStudy.Unity
{
	public class CleanerPositioner : MonoBehaviour
    {
		private Camera _mainCamera;
		private Cleaner _cleaner;

		private Vector3 _initPosCleaner;
		private Quaternion _initRotCleaner;

		[SerializeField] private float _notHitDistance;
		[SerializeField] private float _smoothTime = 0.3f;
		private Vector3 _positionVelocity, _rotationVelocity;
		private void Awake()
		{
			_mainCamera = Camera.main;
		}

		private void OnEnable()
		{
			CleanGameplayEvents.OnCleanerSet += SetCleaner;
			CleanGameplayEvents.OnRaycastHit += SetCleanerPositionAndRotationOnHit;
			CleanGameplayEvents.OnRaycastNotHit += SetCleanerPositionAndRotationOnNotHit;
			CleanGameplayEvents.OnInputDown += SetCleanerPositionAndRotationOnInputDown;
		}

	
		private void OnDisable()
		{
			CleanGameplayEvents.OnCleanerSet -= SetCleaner;
			CleanGameplayEvents.OnRaycastHit -= SetCleanerPositionAndRotationOnHit;
			CleanGameplayEvents.OnRaycastNotHit -= SetCleanerPositionAndRotationOnNotHit;
			CleanGameplayEvents.OnInputDown -= SetCleanerPositionAndRotationOnInputDown;
		}

		private void SetCleaner(Cleaner cleaner)
		{
			_cleaner = cleaner;
			_initPosCleaner = _cleaner.transform.position;
			_initRotCleaner = _cleaner.transform.rotation;
		}

		private void SetCleanerPositionAndRotationOnHit(RaycastHit raycastHit)
		{
			_cleaner.transform.position = Vector3.SmoothDamp(_cleaner.transform.position, raycastHit.point, ref _positionVelocity, _smoothTime*Time.deltaTime);
			_cleaner.transform.forward = Vector3.SmoothDamp(_cleaner.transform.forward, raycastHit.normal, ref _rotationVelocity, _smoothTime*Time.deltaTime);
		}

		private void SetCleanerPositionAndRotationOnNotHit(Vector3 mousePosition)
		{
			mousePosition.z = _notHitDistance;
			Vector3 targetPos = _mainCamera.ScreenToWorldPoint(mousePosition);

			_cleaner.transform.position = Vector3.SmoothDamp(_cleaner.transform.position, targetPos, ref _positionVelocity, _smoothTime * Time.deltaTime);
		}

		private void SetCleanerPositionAndRotationOnInputDown()
		{
			_cleaner.transform.position = Vector3.SmoothDamp(_cleaner.transform.position, _initPosCleaner, ref _positionVelocity, _smoothTime * Time.deltaTime);
			_cleaner.transform.rotation = Quaternion.Lerp(_cleaner.transform.rotation, _initRotCleaner, Time.deltaTime * 20f);
		}


	
		
	}
}
