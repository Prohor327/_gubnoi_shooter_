using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class Subtitres : UIElement
{
    private Label _title;
    private Label _text;
    private Coroutine coroutine = null;

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
    }
    public void printText(string text)
    {
        if (coroutine == null)
        {
            _text.text = null;
            coroutine = StartCoroutine(Text(text));
        }
    }

    IEnumerator Text(string text)
    {
        foreach (var sym in text)
        {
            _text.text += sym;
            yield return new WaitForSeconds(.1f);
        }
        coroutine = null;
    }

}
