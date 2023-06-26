
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{


//Pause game by additive scene
//=========================================================================================================//
    public void PauseGame()
    {
        SceneManager.LoadScene(2, LoadSceneMode.Additive);
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        SceneManager.UnloadScene(2);
        Time.timeScale = 1;
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
        Time.timeScale = 1; //timeScale need to be back to normal
    }
    
//Score and distance count
//=========================================================================================================//
public float distance = 1f;
private int internalDistance = 1;
public int score = 0;


private float AddDistance()
{
    distance += Time.deltaTime;
    return distance;
}

public void AddScore(int _value)
{
    score += _value;
}


//unityEngine
//=========================================================================================================//
private void Update()
{
    AddDistance();
    internalDistance = (int)distance;
    if (internalDistance % 10 == 0)
    {
        AddScore(1);
    }

    if (internalDistance > 100)
    {
        AddScore(1);
    }

}
}
