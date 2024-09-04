using UnityEngine;

namespace Task2.UI.Panels
{
    public abstract class BasePanel : MonoBehaviour
    {
        public void Show() => gameObject.SetActive(true);

        public void Hide() => gameObject.SetActive(false);
    }
}