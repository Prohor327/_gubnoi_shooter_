using System;
using AYellowpaper.SerializedCollections;
using UnityEngine;

[Serializable]
public class SurfaceConfig
{
    [SerializedDictionary("Surface", "Bullet hole")]
    [field: SerializeField] public SerializedDictionary<LayerMask, BulletHole> BulletHoles { get; private set; }
    [SerializedDictionary("Surface", "Partial Effect")]
    [field: SerializeField] public SerializedDictionary<LayerMask, ParticalDecal> ParticalEffects { get; private set; }
}