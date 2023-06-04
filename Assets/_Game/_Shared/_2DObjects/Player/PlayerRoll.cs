using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRoll : MonoBehaviour
{
    [SerializeField] 
    private BoxCollider2D playerBC;

    private Animator playerAnimator;

    private void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }

    public void Roll()
    {
        playerBC.enabled = false;
    }

    public void unRoll()
    {
        playerBC.enabled = true;
    }
}
