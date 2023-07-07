
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;


public class GameOverScene : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Transform respawnPoint;


    private ImmortalPlayerScript imps;


    private void Start()
    {
        imps = player.GetComponent<ImmortalPlayerScript>();
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    
    public void WatchAAd()
    {
        Ads.instance.LoadAd();
        
        player.transform.position = respawnPoint.position;
        gameObject.SetActive(false);
        player.gameObject.SetActive(true);
        imps.PlayerImortal();
        Time.timeScale = 1;

    }
}
