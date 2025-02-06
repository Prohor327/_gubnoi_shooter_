using UnityEngine;

[CreateAssetMenu(fileName = "CutSceneSO", menuName = "Game/CutSceneSO", order = 0)]
public class CutSceneSO : ScriptableObject 
{
    [SerializeField] private string _name;    

    public string Name => _name;
}