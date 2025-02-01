    using UnityEngine;

public class Security : MonoBehaviour, IInteract
{
    [SerializeField] private LevelCutSceneActivator _timeLine;
    [SerializeField] private int _indexCutScene;
    [SerializeField] private int _cameraIndex;
 
    public void CursorOnObject()
    {
        print("Security");
    }

    public void Interact()
    {
        _timeLine.SetCutScene(_indexCutScene, _cameraIndex);
    }
}
