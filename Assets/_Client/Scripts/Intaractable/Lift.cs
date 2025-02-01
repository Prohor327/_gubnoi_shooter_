using UnityEngine;

public class Lift : MonoBehaviour, IInteract
{
<<<<<<< Updated upstream
    [SerializeField] private LevelCutSceneActivator _timeLine;
    [SerializeField] private int _indexCutScene;
    [SerializeField] private int _cameraIndex;
 
    public void CursorOnObject()
    {
        print("Lift");
=======
    public void CursorOnObject()
    {
        print("Security");
>>>>>>> Stashed changes
    }

    public void Interact()
    {
<<<<<<< Updated upstream
        _timeLine.SetCutScene(_indexCutScene, _cameraIndex);
=======
        print("Say");
>>>>>>> Stashed changes
    }
}
