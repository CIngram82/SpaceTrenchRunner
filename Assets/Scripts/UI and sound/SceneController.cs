using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {
    int activeSceneBuildInt;
    private MusicManager musicMan;
    [SerializeField] float timeToWait = 2.5f;
    // Use this for initialization
    void Start () {
        HighScoreManager._instance.OnResetHS();
        DontDestroyOnLoad(gameObject);
        
        activeSceneBuildInt = SceneManager.GetActiveScene().buildIndex;

        if (activeSceneBuildInt == 0)
        {

            StartCoroutine(WaitForTime());
        }
    }
	
    IEnumerator WaitForTime()
    {
        yield return new WaitForSeconds(timeToWait);
        LoadNextScene();
    }
    public void ReloadScene()
    {
        int activeSceneBuildInt = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(activeSceneBuildInt);
    }
    public void LoadNextScene()
    {
        int activeSceneBuildInt = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(activeSceneBuildInt + 1);
    }
    public void LoadSceneByName(string name)
    {
        if(name == "TrenchRun")
        {
            musicMan = FindObjectOfType<MusicManager>();
            musicMan.PlayGameBGM();
        }
        if (name == "MainMenu")
        {
            musicMan = FindObjectOfType<MusicManager>();
            musicMan.PlayGameBGM();
        }
        SceneManager.LoadScene(name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
