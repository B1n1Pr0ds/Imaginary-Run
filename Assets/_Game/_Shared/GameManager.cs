
using TMPro;
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
[Header("Score Options")]
public float distance = 1f;
private int internalDistance = 1;
public float score = 0f;
[SerializeField] [Range(10,100)] private float  distanceToStartScoring;
[Range(0,100)] public int  scorebyDistanceValue;

[Header("Score UI sets")]
[SerializeField] private GameObject addedScoreTextGO;
private TextMeshProUGUI addedScoreText;
[SerializeField] private Transform scoreTransform;

private float AddDistance()
{
    distance += Time.deltaTime;
    return distance;
    
}

private void addScorebyDistance()
{
    if (internalDistance < distanceToStartScoring) 
        return;
    
    
    score += scorebyDistanceValue * Time.deltaTime;

}

public void AddScore(int _value)
{
    
    score += _value;
    addedScoreText = AddedTextScore().GetComponent<TextMeshProUGUI>();
    addedScoreText.text = " +" + _value;
  


}

private GameObject AddedTextScore()
{
    GameObject addedScoreTxt_ = Instantiate(addedScoreTextGO, scoreTransform);
    return addedScoreTxt_;
}


//unityEngine
//=========================================================================================================//
private void Update()
{
    AddDistance();
    internalDistance = (int)distance;
    addScorebyDistance();
    




}
}
