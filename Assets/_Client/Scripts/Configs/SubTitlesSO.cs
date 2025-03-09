using UnityEngine;

[CreateAssetMenu(fileName = "Subtitres", menuName = "Game/New subtitres", order = 0)]
public class SubTitresSO : ScriptableObject
{
    [SerializeField] string[] _title;
    [SerializeField] string[] _text;

    public string[] GetTitle() => _title;

    public string[] GetText() => _text;
}
