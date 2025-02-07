using System;
using UnityEngine;
using UnityEngine.Playables;

[Serializable]
public class CutScene
{
    [SerializeField] private PlayableAsset _asset;
    
    public Camera Camera;

    public PlayableAsset Asset => _asset;
}