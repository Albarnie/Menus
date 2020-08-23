using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Albarnie.Menus
{
    public interface IMenu
    {
        KeyCode Key
        {
            get;
        }

        void OnMenuOpen();

        void OnMenuClose();

        RectTransform GetTransform();
    }
}