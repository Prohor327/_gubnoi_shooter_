using System.Data;
using UnityEngine;

[CreateAssetMenu(fileName = "CutSceneSO", menuName = "Game/CutSceneSO", order = 0)]
public class CutSceneSO : ScriptableObject 
{
    [field: SerializeField] public string Name { get; private set; }
}