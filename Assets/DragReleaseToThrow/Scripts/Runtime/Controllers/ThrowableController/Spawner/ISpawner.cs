using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Simofun.DevCaseStudy.Unity
{
    public interface ISpawner<T>
    {
        T Spawn();
    }
}
