
using System;
using System.Collections;
using UnityEngine;

public class ImmortalPlayerScript : MonoBehaviour
{
    private float immortalTime = 3.5f;
    [SerializeField] private Animator pa;
    [SerializeField] private GameObject player;
    [SerializeField] private LayerMask imortalLayer;
    [SerializeField] private LayerMask playerLayer;


    private void Start()
    {
        imortalLayer = LayerMask.NameToLayer("Imortal");
        playerLayer = LayerMask.NameToLayer("Default");
    }

    

    public void PlayerImortal()
    {
       
        pa.SetTrigger("PlayerImortal");
        SetLayerRecursively(player, imortalLayer);
        StartCoroutine(ImortalCoolDown());

    }


    private IEnumerator ImortalCoolDown()
    {
        yield return new WaitForSeconds(immortalTime);
        SetLayerRecursively(player, playerLayer);
    }
    public static void SetLayerRecursively(GameObject _obj, int _newLayer)
    {
        if(_obj== null)
           return;
        _obj.layer = _newLayer;

        foreach (Transform _child in _obj.transform)
        {
            if(_child == null) continue;
            SetLayerRecursively(_child.gameObject, _newLayer);
        }
    }
}
