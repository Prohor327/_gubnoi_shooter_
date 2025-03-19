using UnityEngine;
using DG.Tweening;

public class LiftDoors : Door
{
    [SerializeField] private Transform _door1;
    [SerializeField] private Transform _door2;

    private Vector3 _door1DefaultPos;
    private Vector3 _door2DefaultPos;

    protected override void Start()
    {
        base.Start();
        _door1DefaultPos = _door1.localPosition;
        _door2DefaultPos = _door2.localPosition;
    }

    public override void Open()
    {   
        _door1.DOLocalMoveX(_door1DefaultPos.x - 2, openningDuration);
        _door2.DOLocalMoveX(_door2DefaultPos.x + 2, openningDuration).onComplete = OnEndOpen;
        audioSource.PlayOneShot(_openningSound);
    }

    public override void Close()
    {
        _door1.DOLocalMoveX(_door1DefaultPos.x, openningDuration);
        _door2.DOLocalMoveX(_door2DefaultPos.x, openningDuration).onComplete = OnEndClose;
        audioSource.PlayOneShot(_openningSound);
    }

    public void PlaySound(AudioClip audioClip)
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }
}
