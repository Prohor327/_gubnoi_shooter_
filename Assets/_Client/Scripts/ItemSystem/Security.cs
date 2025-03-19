using UnityEngine;
using Zenject;

public class Security : Interactable
{
    [SerializeField] private AudioClip _clip;
    [SerializeField] private SubTitlesSO _securitySubTitle;

    private SubTitles _subTitles;
    private AudioSource _audioSource;

    [Inject]
    private void Construct(SubTitles subTitles)
    {
        _subTitles = subTitles;
    }

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public override void OnStartHover()
    {
        playerEvents.OnStartHoverObject("[E] Говорить");
    }

    public override void OnInteract()
    {
        if(!_audioSource.isPlaying)
        {
            _audioSource.PlayOneShot(_clip);
            _subTitles.Printing(_securitySubTitle);
        }
    }
}
