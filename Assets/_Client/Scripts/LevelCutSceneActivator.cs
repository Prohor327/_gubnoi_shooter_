using UnityEngine;
using UnityEngine.Playables;

public class LevelCutSceneActivator : MonoBehaviour
{
    [SerializeField] private PlayableAsset[] _cutScenes;
    [SerializeField] private PlayableDirector _cutSceneDirector;

    public void SetCutScene(int index)
    {
        _cutSceneDirector.playableAsset = _cutScenes[index];
        _cutSceneDirector.Play();
    }

}
