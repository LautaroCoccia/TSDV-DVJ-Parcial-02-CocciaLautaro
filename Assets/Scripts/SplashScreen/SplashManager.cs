using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SplashManager : MonoBehaviour
{
    [SerializeField] CanvasGroup gameSplashGroup;
    [SerializeField] CanvasGroup cachuflitoSplashGroup;
    [SerializeField] float maxTime = 2;
    float time = 0;
    public static Action LoadMainMenuScene;
    // Start is called before the first frame update
    void Start()
    {
        gameSplashGroup.alpha = 0;
        cachuflitoSplashGroup.alpha = 0;
        StartCoroutine(Splasher());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Splasher()
    {
        while (time < maxTime)
        {
            SetAlphaTo1(cachuflitoSplashGroup);
            yield return null;
        }
        time = 0;
        yield return new WaitForSeconds(0.5f);

        while (time < maxTime)
        {
            SetAlphaTo0(cachuflitoSplashGroup);
            yield return null;
        }
        yield return new WaitForSeconds(0.1f);
        time = 0;

        while (time < maxTime)
        {
            SetAlphaTo1(gameSplashGroup);
            yield return null;
        }
        time = 0;
        yield return new WaitForSeconds(0.5f);

        while (time < maxTime)
        {
            SetAlphaTo0(gameSplashGroup);
            yield return null;
        }
        time = 0;
        LoadMainMenuScene?.Invoke();

    }

    void SetAlphaTo1(CanvasGroup Cv)
    {
        time += Time.deltaTime;
        Cv.alpha = Mathf.Lerp(0, 1, time);
    }
    void SetAlphaTo0(CanvasGroup Cv)
    {
        time += Time.deltaTime;
        Cv.alpha = Mathf.Lerp(1, 0, time);
    }

}
