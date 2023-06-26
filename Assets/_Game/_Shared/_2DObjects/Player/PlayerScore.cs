
using System;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] private GameManager gm;
    public void Die()
    {
        Destroy(gameObject);
        gameOverScreen.SetActive(true);
        Time.timeScale = 0;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "ScoreCollider")
        {
            gm.AddScore(1);
        }
    }
}
