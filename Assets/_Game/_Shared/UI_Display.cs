
using System;
using TMPro;
using UnityEngine;

public class UI_Display : MonoBehaviour
{
    [SerializeField] private GameManager gm;
    [SerializeField] private TextMeshProUGUI scoreTxt;
    [SerializeField] private TextMeshProUGUI distanceTxt;

    private void SetScore(int _score)
    {
        scoreTxt.text = "Score: " + _score + " Points ";
    }

    private void SetDistance(float _distance)
    {
        distanceTxt.text = "Distance: " + _distance.ToString("F1") + " KM ";
    }

    private void Update()
    {
        SetDistance(gm.distance);
        SetScore(gm.score);
    }
}
