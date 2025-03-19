using System;
using AYellowpaper.SerializedCollections;
using UnityEngine;

[Serializable]
public class SurfaceConfig
{

    [SerializedDictionary("Level grade", "Color")]
    public AYellowpaper.SerializedCollections.SerializedDictionary<LayerMask, Decal> rangGradeColor;
    
}