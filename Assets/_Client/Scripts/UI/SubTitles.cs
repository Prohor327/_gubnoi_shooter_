using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class SubTitles : UIElement
{   
    [SerializeField] private GameplayUI _gameplayUI;
    private Label _title;
    private Label _text;
    private Coroutine coroutine = null;

    protected override void Initialize()
    {
        base.Initialize();

        _title = _UIElement.Q<Label>("Title");
        _text = _UIElement.Q<Label>("Text");
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

    public void Close()
    {
        _gameplayUI.Open();
    }

    IEnumerator Text(string text)
    {
        foreach (var sym in text)
        {
            _text.text += sym;
            yield return new WaitForSeconds(.1f);
        }
        yield return new WaitForSeconds(1f);
        Close();
        coroutine = null;
    }

}
