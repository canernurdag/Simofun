using Simofun.DevCaseStudy.Unity.Assets.TapDragToClean.Scripts.Events;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Simofun.DevCaseStudy.Unity
{
    public class CleanerUi : MonoBehaviour
    {
        [SerializeField] private TMP_Text _indicator;

		private void OnEnable()
		{
			CleanGameplayEvents.OnTextureManipulationRationChanged += SetIndicator;	
		}

		private void OnDisable()
		{
			CleanGameplayEvents.OnTextureManipulationRationChanged -= SetIndicator;
		}

		private void Start()
		{
            SetIndicator(0);
		}
		public void SetIndicator(float cleanRatio)
        {
			_indicator.text = String.Format("{0:0%}", cleanRatio); 
        }
    }
}
