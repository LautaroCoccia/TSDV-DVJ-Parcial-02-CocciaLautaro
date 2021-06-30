using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CheckPlayerCollision : MonoBehaviour
{
    public delegate void WinLoseAction(ref bool playerLand);
    public static WinLoseAction winLoseAction;
    bool landed = false;

    public delegate void SetScore(ref int score);
    public static SetScore setNewScore;
    int newScore = 0;

    PlayerMovement playerMovement;
    ScoreSetter scoreSetter;
    void Start()
    {
        playerMovement = gameObject.GetComponent<PlayerMovement>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(Mathf.Abs( playerMovement.GetVerticalSpeed()) < 1 && collision.gameObject.layer==8)
        {
            landed = true;
            winLoseAction?.Invoke(ref landed);
            scoreSetter =collision.gameObject.GetComponent<ScoreSetter>();
            newScore = scoreSetter.GetScore();
            setNewScore?.Invoke(ref newScore);
        }
        else
        {
            landed = false;
            winLoseAction?.Invoke(ref landed);
        }
    }
}
