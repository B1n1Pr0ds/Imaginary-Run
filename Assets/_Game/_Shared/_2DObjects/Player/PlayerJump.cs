using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private BoxCollider2D bottomBoxCollider2D;

    private Animator pAnimator;

    private void Start()
    {
        pAnimator = GetComponent<Animator>();
    }

    public void Jumping()
    {
        bottomBoxCollider2D.enabled = false;
    }

    public void NotJumping()
    {
        bottomBoxCollider2D.enabled = true;
    }
}
