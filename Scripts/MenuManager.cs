using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Albarnie.Menus
{
    public class MenuManager : MonoBehaviour
    {
        public static MenuManager manager;

        public List<RectTransform> menus;
        public int currentMenuIndex = 0;
        public RectTransform currentMenu;

        EventSystem events;

        [SerializeField]
        bool pauseWhenOpen = true, lockCursor = true;

        bool exitMenu;

        private void Awake()
        {
            if (manager != null)
            {
                Destroy(this);
            }
            else if (manager != this)
            {
                manager = this;
            }

            events = EventSystem.current;
        }

        private void Start()
        {
            ChangeMenu(currentMenuIndex);
        }

        private void Update()
        {
            if (exitMenu)
            {
                exitMenu = false;
                ChangeMenu(-1);
            }

            //Exit the menu the next frame
            if (Input.GetKeyDown(KeyCode.Escape) && currentMenuIndex != -1)
            {
                exitMenu = true;
            }
        }

        public void ChangeMenu(int newMenu)
        {
            RectTransform menuObj = null;
            foreach (RectTransform menu in menus)
            {
                menu.gameObject.SetActive(false);
            }
            if (newMenu >= 0)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

                if (pauseWhenOpen)
                    Time.timeScale = 0;

                menus[newMenu].gameObject.SetActive(true);
                menuObj = menus[newMenu].GetComponent<RectTransform>();
                if (!Application.isEditor && menus[newMenu].GetComponentInChildren<Selectable>() != null)
                    events.SetSelectedGameObject(menus[newMenu].GetComponentInChildren<Selectable>().gameObject);
            }
            else
            {
                Time.timeScale = 1;
                if (lockCursor)
                {
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;
                }

                events.SetSelectedGameObject(null);
            }
            currentMenu = menuObj;
            currentMenuIndex = newMenu;
        }

        public void ChangeMenu(RectTransform newMenu)
        {
            if (newMenu == null)
                ChangeMenu(-1);

            if (menus.Contains(newMenu))
            {
                ChangeMenu(menus.IndexOf(newMenu));
            }
            else
            {
                //Adds the menu and opens it
                menus.Add(newMenu);
                ChangeMenu(menus.Count - 1);
            }
        }
    }
}