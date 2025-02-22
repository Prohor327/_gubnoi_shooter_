using UnityEngine;
using Zenject;

public class Security : Interactable
{
    [SerializeField] private AudioClip _clip;

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

    public override void OnInteract()
    {
        if(!_audioSource.isPlaying)
        {
            _audioSource.PlayOneShot(_clip);
            _subTitles.SetTitle("Охранник");
            _subTitles.PrintText("А, ты пришел, ну проходи, лифт вот там. Вон там. Вон. Вон. Ну, ты че слепой? Ну ты лифт не видишь, слепошарый. Вон там.");
        }
    }
}
