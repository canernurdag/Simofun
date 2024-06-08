using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Simofun.DevCaseStudy.Unity
{
    public class Cleanable : MonoBehaviour
    {
        [SerializeField] private float _speed = 15;
        void Update()
        {
            transform.Rotate(0, _speed*Time.deltaTime, 0);
        }
    }
}
