using System;
using UnityEngine;

[Serializable]
public class HandsConfig
{
    [field: SerializeField] public float Distance { get; private set; }
    [field: SerializeField] public float ThrowingForce { get; private set; }
}
