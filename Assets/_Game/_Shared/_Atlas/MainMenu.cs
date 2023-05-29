
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Script reponsable to set the functions of the main menu of the game

    [SerializeField] private GameObject scoreBoardGO;
    private void Start()
    {
        this.gameObject.SetActive(true);
        scoreBoardGO.SetActive(false);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    

    //universal acces to other window from the MainMenu
    public void AcessOtherWindow(GameObject _window)
    {
        this.gameObject.SetActive(false);
        _window.SetActive(true);
    }
    //Universal acees to MainMenu from any window
    public void BackToMainMenu(GameObject _currentWindow)
    {
        this.gameObject.SetActive(true);
        _currentWindow.SetActive(false);
    }
}
