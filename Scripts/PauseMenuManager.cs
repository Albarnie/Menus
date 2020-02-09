using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    [SerializeField]
    RectTransform rect;

    private void Update()
    {
        if(MenuManager.manager.currentMenuIndex == -1 && Input.GetKeyDown(KeyCode.Escape))
        {
            MenuManager.manager.ChangeMenu(rect);
        }
    }

    public void GoToMainMenu ()
    {
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync(0);
    }
}
