using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class Subtitres : UIElement
{
    private Label _title;
    private Label _text;

    protected override void Initialize()
    {
        base.Initialize();

        _title = _container.Q<Label>("Title");
        _text = _container.Q<Label>("Text");
    }

    public override void Open()
    {
        base.Open();
    }

    public void SetTitle(string title)
    {
        _title.text = title;
        Open();
    }
    public void printText(string text)
    {
        Open();
        _text.text = null;
        StartCoroutine(Text(text));
    }

    IEnumerator Text(string text)
    {
        foreach (var sym in text)
        {
            _text.text += sym;
            yield return new WaitForSeconds(.1f);
        }
    }

}
