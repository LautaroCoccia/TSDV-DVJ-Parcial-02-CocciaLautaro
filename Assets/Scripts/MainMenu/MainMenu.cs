using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject mainScreen;
    [SerializeField] GameObject creditsScreen;
    [SerializeField] GameObject quitScreen;

    [SerializeField] Button playButton;
    [SerializeField] Button quitConfirmButton;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(mainScreen.activeSelf == true)
            {
                quitScreen.SetActive(true);
                mainScreen.SetActive(false);
                quitConfirmButton.Select();

            }
            else if(quitScreen.activeSelf == true)
            {
                quitScreen.SetActive(false);
                ActiveMainScreen();
            }
            else if(creditsScreen.activeSelf == true)
            {
                creditsScreen.SetActive(false);
                ActiveMainScreen();
            }
        }
    }
    void ActiveMainScreen()
    {
        mainScreen.SetActive(true);
        playButton.Select();
    }
}
