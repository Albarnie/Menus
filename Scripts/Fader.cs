using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fader : MonoBehaviour
{

    [SerializeField]
    Image image;

    private void Awake()
    {
        StartFadeIn(2f, 2f);
    }

    public IEnumerator FadeIn (float time, float delay)
    {
        image.color = new Color(0, 0, 0, 1);

        yield return new WaitForSeconds(delay);

        float timePassed = 0;
        while (timePassed < time)
        {
            timePassed += Time.deltaTime;
            image.color = new Color(0, 0, 0, 1 - (timePassed / time));
            yield return null;
        }
    }

    public void StartFadeIn (float time, float delay)
    {
        StartCoroutine(FadeIn(time, delay));
    }

    public IEnumerator FadeOut(float time, float delay)
    {
        image.color = new Color(0, 0, 0, 0);

        yield return new WaitForSeconds(delay);

        float timePassed = 0;
        while (timePassed < time)
        {
            timePassed += Time.deltaTime;
            image.color = new Color(0, 0, 0, (timePassed / time));
            yield return null;
        }
    }

    public void StartFadeOut(float time, float delay)
    {
        StartCoroutine(FadeOut(time, delay));
    }
}
