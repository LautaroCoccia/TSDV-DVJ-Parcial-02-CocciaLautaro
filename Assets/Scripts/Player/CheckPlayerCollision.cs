using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CheckPlayerCollision : MonoBehaviour
{
    public delegate void WinLoseAction(ref bool playerLand);
    public static WinLoseAction winLoseAction;
    bool landed = false;
    PlayerMovement playerMovement;
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
        }
        else
        {
            landed = false;
            winLoseAction?.Invoke(ref landed);

        }
    }
}
