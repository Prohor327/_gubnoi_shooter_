using UnityEngine;

[CreateAssetMenu(fileName = "Subtitres", menuName = "Game/New subtitres", order = 0)]
public class SubTitlesSO : ScriptableObject
{
    [field: SerializeField] public string[] Title { get; private set; }
    [field: SerializeField] public string[] Text { get; private set; }
}
