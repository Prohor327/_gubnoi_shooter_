using UnityEngine;
using System;

[Serializable]
public class HealthConfig
{
    [field: SerializeField] public float Health { get; private set; }
}
