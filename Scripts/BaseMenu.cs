using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Albarnie.Menus
{
    public class BaseMenu : MonoBehaviour, IMenu
    {
        protected RectTransform rectTransform;

        [SerializeField]
        KeyCode key;
        public KeyCode Key
        {
            get { return key; }
        }

        public RectTransform GetTransform()
        {
            if (rectTransform == null)
            {
                rectTransform = GetComponent<RectTransform>();
            }
            return rectTransform;
        }

        public virtual void OnMenuClose()
        {

        }

        public virtual void OnMenuOpen()
        {

        }
    }
}