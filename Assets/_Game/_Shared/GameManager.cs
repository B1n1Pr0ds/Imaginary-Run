
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
//Pause game by additive scene
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
        Time.timeScale = 1;
    }


}
