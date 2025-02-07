using System.Data;
using UnityEngine;

[CreateAssetMenu(fileName = "CutSceneSO", menuName = "Game/CutSceneSO", order = 0)]
public class CutSceneSO : ScriptableObject 
{
    [SerializeField] private string _name;    
    [SerializeField] private int _id;

    public string Name => _name;
    public int Id => _id;
}