using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    List<Scores> highscore;
    Scores cScore;
    public GameObject highScoreHolder;
    public GameObject highScorePrefab;
    public GameObject highScorePanel;
    public GameObject getNamePanel;
    public InputField nameInputField;
    public Text getNameScoreText;
    public Button nameInputButton;
    public GameObject lowScorePanel;
    public Text lowScoreText;
    // Use this for initialization
    void Start()
    {
        getNamePanel.gameObject.SetActive(false);
        highScorePanel.gameObject.SetActive(false);
        lowScorePanel.gameObject.SetActive(false);
        nameInputButton.interactable = false;
        highscore = new List<Scores>();
        highscore = HighScoreManager._instance.GetHighScore();
        cScore = HighScoreManager._instance.GetCurrentScore();
        if (cScore.score > highscore[highscore.Count -1].score || highscore.Count < 10)
        {
            getNamePanel.gameObject.SetActive(true);
        }
        else
        {
            lowScorePanel.gameObject.SetActive(true);
        }
    }
    private void Update()
    {
        if(nameInputField.text != ""){
            nameInputButton.interactable = true;
        }
    }
    public void OnNameSubmitButtonClick()
    {
        cScore.name = nameInputField.text;
        HighScoreManager._instance.SaveHighScore(cScore.name,cScore.score,cScore.distance,cScore.time);
        getNamePanel.gameObject.SetActive(false);
        LoadList();
    }
    public void ONLowScoreButtonClick()
    {
        lowScorePanel.gameObject.SetActive(false);
        LoadList();
    }
    void CheckforSH()
    {
        for(int i = 0; i < highscore.Count;i++)
        {
            Scores _score = highscore[i];
            if (_score.score <= cScore.score)
            {
                highscore.Insert(i,cScore);
            }
        }
    }
    void LoadList()
    {
        highScorePanel.gameObject.SetActive(true);
        float y = 1.0f;
        highscore = HighScoreManager._instance.GetHighScore();
        foreach (Scores _score in highscore)
        {
            GameObject hsPanel = Instantiate(highScorePrefab,highScoreHolder.transform);
            hsPanel.GetComponent<RectTransform>().anchorMax = new Vector2(1, y);
            hsPanel.GetComponent<RectTransform>().anchorMin = new Vector2(0, y -= 0.1f);
            hsPanel.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
            hsPanel.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
            Text nameText = hsPanel.transform.Find("nameText").GetComponent<Text>();
            nameText.text = _score.name.ToString();
            Text distanceText = hsPanel.transform.Find("distanceText").GetComponent<Text>();
            distanceText.text = _score.distance.ToString();
            Text timeText = hsPanel.transform.Find("timeText").GetComponent<Text>();
            timeText.text = _score.time.ToString();
            Text scoreText = hsPanel.transform.Find("scoreText").GetComponent<Text>();
            scoreText.text = _score.score.ToString();
        }
    }

    public void OnClearnHSButton()
    {
        HighScoreManager._instance.ClearLeaderBoard();
    }

}

