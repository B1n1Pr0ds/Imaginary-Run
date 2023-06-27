
using System;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] [Range(1, 10)] public int scoreToAdd;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] private GameManager gm;
    public void Die()
    {
        gameObject.SetActive(false);
        gameOverScreen.SetActive(true);
        Time.timeScale = 0;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "ScoreCollider")
        {
            gm.AddScore(scoreToAdd);
        }
    }
}
