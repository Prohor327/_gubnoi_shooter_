using UnityEngine;

public class Lift : MonoBehaviour, IInteract
{
    [SerializeField] private LevelCutSceneActivator _timeLine;
    [SerializeField] private int _indexCutScene;
    [SerializeField] private int _cameraIndex;
 
    public void CursorOnObject()
    {
        print("Lift");
    }

    public void Interact()
    {
        _timeLine.SetCutScene(_indexCutScene, _cameraIndex);
    }
}
