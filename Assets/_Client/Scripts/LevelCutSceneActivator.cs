using Tools;
using UnityEngine;
using UnityEngine.Playables;
using Zenject;

public class LevelCutSceneActivator : MonoBehaviour
{
    [SerializeField] private PlayableDirector _cutSceneDirector;
    [SerializeField] private PlayableAsset[] _cutScenes;

    [SerializeField] private GameObject[] _cameras; // Obj with camera, 0 - 

    private Player _player;

    [Inject]
    private void Construct(Player player)
    {
        _player = player;
    }

    private void Start()
    {
        _cameras[0] = _player.gameObject;
        SetCutScene(0, 1);
    }

    public void SetCutScene(int index, int cameraIndex)
    {
        _cutSceneDirector.playableAsset = _cutScenes[index];
        ReloadCamera(cameraIndex);
        _cutSceneDirector.Play();
        print("Start cut scene");
    }

    private void ReloadCamera(int index)
    {
        for (int i = 0;  i < _cameras.Length; i++) 
            _cameras[i].SetActive(false);
        _cameras[index].SetActive(true);
    }
    
    public void EndCutScene(int index)
    {
        ReloadCamera(index);
    }
}
