using System;
using AYellowpaper.SerializedCollections;
using UnityEngine;

[Serializable]
public class SurfaceConfig
{
    [SerializedDictionary("Surface", "Bullet hole")]
    [field: SerializeField] public SerializedDictionary<LayerMask, LimitedLifeDecal> BulletHoles { get; private set; }
    [SerializedDictionary("Surface", "Partial Effect")]
    [field: SerializeField] public SerializedDictionary<LayerMask, ParticalDecal> ParticalEffects { get; private set; }
    [SerializedDictionary("Surface", "Bullet hole")]
    [field: SerializeField] public SerializedDictionary<LayerMask, LimitedLifeDecal> Scratches { get; private set; }
}