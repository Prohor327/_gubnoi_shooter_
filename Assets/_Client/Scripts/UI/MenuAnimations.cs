using DG.Tweening;
using UnityEngine;

namespace _Client.UI
{
    public class MenuAnimations : MonoBehaviour
    {
        public void MenuMoveIn(GameObject panel)
        {
            panel.transform.DOMoveX(50, 1.5f).SetUpdate(true);
        }

        public void MenuMoveOut(GameObject panel)
        {
            panel.transform.DOMoveX(-750, 1.5f).SetUpdate(true);
        }
    }
}