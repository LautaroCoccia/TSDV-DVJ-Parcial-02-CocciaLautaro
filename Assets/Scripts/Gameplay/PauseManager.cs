using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    [SerializeField] GameObject pauseMenuUI;
    [SerializeField] GameObject mainPauseMenuUI;
    [SerializeField] GameObject background;
    [SerializeField] GameObject controlsMenuUI;
    [SerializeField] GameObject quitToMenuUI;
    [SerializeField] Button continueButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(pauseMenuUI.activeSelf == false)
            {
                Pause();
            }
            else
            {
                if (controlsMenuUI.activeSelf == true)
                {
                    controlsMenuUI.SetActive(false);
                    mainPauseMenuUI.SetActive(true);
                }
                else if(quitToMenuUI.activeSelf == true)
                {
                    quitToMenuUI.SetActive(false);
                    mainPauseMenuUI.SetActive(true);
                }
                else
                {
                    pauseMenuUI.SetActive(false);
                }
            }
        }
    }
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        background.SetActive(true);
        mainPauseMenuUI.SetActive(true);
        continueButton.Select();
        Time.timeScale = 0;
    }
    public void Continue()
    {
        pauseMenuUI.SetActive(false);
        background.SetActive(false);
        mainPauseMenuUI.SetActive(false);
        Time.timeScale = 0;
    }
}
