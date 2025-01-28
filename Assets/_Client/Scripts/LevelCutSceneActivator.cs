using Tools;
using UnityEngine;
using UnityEngine.Playables;
using Zenject;

public class LevelCutSceneActivator : MonoBehaviour
{
    [SerializeField] private PlayableDirector _cutSceneDirector;
    [SerializeField] private PlayableAsset[] _cutScenes;

    private Player _player;

    [Inject]
    private void Construct(Player player)
    {
        _player = player;
    }

    private void Start()
    {
        SetCutScene(0);
    }

    public void SetCutScene(int index)
    {
        _cutSceneDirector.playableAsset = _cutScenes[index];
        _cutSceneDirector.Play();
        _player.HasShow(false);
        print("Start cut scene");
    }

    public void EndCutScene()
    {
        _player.HasShow(true);
    }
}
