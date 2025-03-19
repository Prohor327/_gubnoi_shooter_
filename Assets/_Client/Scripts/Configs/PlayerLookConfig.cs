using UnityEngine;
using System;

[Serializable]
public class PlayerLookConfig
{
    [field: SerializeField] public float YRotateLimit { get; private set; }
    [field: SerializeField] public float Sensivity { get; private set; }
    [field: SerializeField] public float FocusOfView { get; private set; }
}
