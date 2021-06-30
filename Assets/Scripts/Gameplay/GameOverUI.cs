using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] GameObject gameOverUI;
    [SerializeField] GameObject landedSuccesfully;
    // Start is called before the first frame update
    void Start()
    {
        CheckPlayerCollision.winLoseAction += ActivateGameOver;
    }
    void ActivateGameOver( ref bool playerLanded)
    {
            Time.timeScale = 0;
        if(playerLanded == false)
        {
            gameOverUI.SetActive(true);
        }
        else
        {
            landedSuccesfully.SetActive(true);
        }
    }
    private void OnDisable()
    {
        CheckPlayerCollision.winLoseAction -= ActivateGameOver;
        
    }
}
