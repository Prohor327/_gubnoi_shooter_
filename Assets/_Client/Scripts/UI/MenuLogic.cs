using UnityEngine;
using DG.Tweening;
using Zenject;

namespace _Client.UI
{
    public class MenuLogic : MonoBehaviour
    {
        [SerializeField] private GameObject mainPanel;
        /*[SerializeField] private GameObject aslPanel;
        [SerializeField] private GameObject notifyPanel;
        [SerializeField] private Image aslProgressBar;
        [SerializeField] private TextMeshProUGUI aslText;
        [SerializeField] private TextMeshProUGUI notifyTitleText;
        [SerializeField] private TextMeshProUGUI notifyDescriptionText;*/
        [SerializeField] private MenuAnimations menuAnimations;
        //private bool _isSceneLoaded;
        
        private GameMachine _gameMachine;

        [Inject]
        private void Construct(GameMachine gameMachine)
        {
            _gameMachine = gameMachine;
        }
        
        public void Awake()
        {
            menuAnimations.MenuMoveIn(mainPanel);
        }

        public void LoadLevel(string sceneName) => _gameMachine.LoadLevel(sceneName); 

        public void ApplicationQuit(GameObject panel)
        {
            panel.transform.DOMoveX(-750, 1.5f).OnComplete(() =>
            {
                //GameManager.GameTerminate();
                Application.Quit();
            });
        }
        
        private void Start()
        {
            Cursor.lockState = CursorLockMode.Confined;
            /*AsyncSceneManager.AsyncSceneLoaded += SetSceneLoaded;
            Sequence blinkSequence = DOTween.Sequence();
            blinkSequence.Append(aslText.DOFade(0f, 1f));
            blinkSequence.Append(aslText.DOFade(1f, 1f));
            blinkSequence.SetLoops(-1, LoopType.Restart);
            if (SettingsManager.PlayerHasNotify)
            {
                notifyPanel.SetActive(true);
                notifyTitleText.text = SettingsManager.NotifyTitle;
                notifyDescriptionText.text = SettingsManager.NotifyDescription;
                SettingsManager.PlayerHasNotify = false;
            }*/
        }
        
        /*private void OnDestroy()
        {
            AsyncSceneManager.AsyncSceneLoaded -= SetSceneLoaded;
        }
        
        private void Update()
        {
            if (_isSceneLoaded && (Keyboard.current.anyKey.isPressed || Mouse.current.leftButton.isPressed || Gamepad.current.aButton.isPressed))
            {
                AsyncSceneManager.AllowSceneActivation();
                _isSceneLoaded = false;
            }
        }

        private void SetSceneLoaded()
        {
            _isSceneLoaded = true;
            aslText.gameObject.SetActive(true);
        }*/
    }
}