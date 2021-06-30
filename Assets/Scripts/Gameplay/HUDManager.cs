﻿using UnityEngine;
using TMPro;
public class HUDManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI score; 
    [SerializeField] TextMeshProUGUI time; 
    [SerializeField] TextMeshProUGUI fuel; 
    [SerializeField] TextMeshProUGUI altitude;
    [SerializeField] TextMeshProUGUI verticalSpeed;
    [SerializeField] TextMeshProUGUI horizontalSpeed;
    [SerializeField] GameObject player;

    PlayerMovement playerMovement;
    CheckAltitude checkAltitude;
    float timer=0;
    // Start is called before the first frame update
    void Start()
    {
        score.text = 0.ToString();
        CheckPlayerCollision.setNewScore += UpdateScore;
        playerMovement = player.GetComponent<PlayerMovement>();
        checkAltitude = player.GetComponent<CheckAltitude>();
    }
    // Update is called once per frame
    void Update()
    {
        fuel.text = playerMovement.GetFuel().ToString();
        verticalSpeed.text = ((int)(playerMovement.GetHorizontalSpeed() *10)).ToString();
        horizontalSpeed.text = ((int)(playerMovement.GetVerticalSpeed() * 100)).ToString();
        altitude.text = ((int)(checkAltitude.GetAltitude() * 10)).ToString();
        if(Time.timeScale ==1)
        {
            timer += Time.deltaTime;
            time.text = ((int)timer).ToString();
        }
    }
    void UpdateScore(ref int newScore)
    {
        score.text += newScore;
    }
    public void RestartHUD()
    {
        timer = 0;
    }
    private void OnDisable()
    {
        
        CheckPlayerCollision.setNewScore += UpdateScore;
    }
}
