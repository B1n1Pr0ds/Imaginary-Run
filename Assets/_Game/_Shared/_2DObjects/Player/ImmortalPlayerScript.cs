
using System;
using System.Collections;
using UnityEngine;

public class ImmortalPlayerScript : MonoBehaviour
{
    private float immortalTime = 5f;
    [SerializeField] private Animator pa;
    [SerializeField] private GameObject player;






    public void PlayerImortal()
    {
        pa.SetTrigger("PlayerImortal");
    }
}
