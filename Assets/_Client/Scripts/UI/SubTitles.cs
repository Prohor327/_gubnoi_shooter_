using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class SubTitles : UIElement
{
    private Label _title;
    private Label _text;
    private Coroutine coroutine = null;

    protected override void Initialize()
    {
        base.Initialize();

        _title = _container.Q<Label>("Title");
        _text = _container.Q<Label>("Text");
        Clear();
        //Open();
    }

    public override void Open()
    {
        base.Open();
    }

    public void SetTitle(string title)
    {
        _title.text = title;
    }
    public void PrintText(string text)
    {
        if (coroutine == null)
        {
            _text.SetEnabled(true);
            _title.SetEnabled(true);
            _text.text = null;
            coroutine = StartCoroutine(Text(text));
        }
    }

    public void Clear()
    {
        _text.SetEnabled(false);
        _title.SetEnabled(false);
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
