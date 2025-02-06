using System;
using UnityEngine;
using UnityEngine.Playables;

[Serializable]
public class CutScene
{
    [SerializeField] private PlayableAsset _asset;
    [SerializeField] private Camera _camera;

    public PlayableAsset Asset => _asset;
    public Camera Camera => _camera;
}