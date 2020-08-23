using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Albarnie.Menus
{
    public class MainMenuManager : MonoBehaviour
    {
        [SerializeField]
        string mainLevelName = "BaseScene";

        Fader fader;

        private void Awake()
        {
            fader = FindObjectOfType<Fader>();
        }

        public void Quit()
        {
            Application.Quit();
        }

        public void GoToLevel()
        {
            StartCoroutine(LoadLevel());
        }

        IEnumerator LoadLevel()
        {
            fader.StartFadeOut(0.5f, 0f);
            yield return new WaitForSeconds(0.5f);
            SceneManager.LoadSceneAsync(mainLevelName);
        }
    }
}