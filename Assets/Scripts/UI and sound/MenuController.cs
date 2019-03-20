using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    List<Scores> highscore;
    Scores cScore;
    public GameObject highScorePrefab;
    Text missingName;
    InputField missingTextInput;
    public InputField mainInputField;

    // Use this for initialization
    void Start()
    {
        highscore = new List<Scores>();
        highscore = HighScoreManager._instance.GetHighScore();
        Scores cScore = HighScoreManager._instance.GetCurrentScore();
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
        float y = 1.0f;
        foreach (Scores _score in highscore)
        {
            GameObject hsPanel = Instantiate(highScorePrefab, gameObject.transform);
            hsPanel.GetComponent<RectTransform>().anchorMax = new Vector2(1, y);
            hsPanel.GetComponent<RectTransform>().anchorMin = new Vector2(0, y -= 0.1f);
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

