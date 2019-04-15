using UnityEngine;
using System.Collections;
using System.Collections.Generic;


/// <summary>
/// High score manager.
/// Local highScore manager for LeaderboardLength number of entries
/// 
/// this is a singleton class.  to access these functions, use HighScoreManager._instance object.
/// eg: HighScoreManager._instance.SaveHighScore("meh",1232);
/// No need to attach this to any game object, thought it would create errors attaching.
/// </summary>

public class HighScoreManager : MonoBehaviour
{

    private static HighScoreManager m_instance;
    private const int LeaderboardLength = 10;

    public static HighScoreManager _instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = new GameObject("HighScoreManager").AddComponent<HighScoreManager>();
            }
            return m_instance;
        }
    }

    void Awake()
    {
        if (m_instance == null)
        {
            m_instance = this;
        }
        else if (m_instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        
    }

    public void SaveCurrentScore(string name, float score, float distance, float time)
    {
        PlayerPrefs.SetString("CurrentScore name", name);
        PlayerPrefs.SetFloat("CurrentScore score", score);
        PlayerPrefs.SetFloat("CurrentScore distance", distance);
        PlayerPrefs.SetFloat("CurrentScore time", time);
    }
    public void SaveHighScore(string name, float score, float distance, float time)
    {
        print(score + "Save");
        List<Scores> HighScores = new List<Scores>();

        int i = 1;
        while (i <= LeaderboardLength && PlayerPrefs.HasKey("HighScore" + i + "score"))
        {
            Scores temp = new Scores();
            temp.score = PlayerPrefs.GetFloat("HighScore" + i + "score");
            temp.distance = PlayerPrefs.GetFloat("HighScore" + i + "distance");
            temp.time = PlayerPrefs.GetFloat("HighScore" + i + "time");
            temp.name = PlayerPrefs.GetString("HighScore" + i + "name");
            HighScores.Add(temp);
            i++;
        }
        if (HighScores.Count == 0)
        {
            Scores _temp = new Scores();
            _temp.name = name;
            _temp.score = score;
            _temp.distance = distance;
            _temp.time = time;
            HighScores.Add(_temp);
        }
        else
        {
            for (i = 1; i <= HighScores.Count && i <= LeaderboardLength; i++)
            {
                print(score + "is it higher?");
                if (score > HighScores[i - 1].score)
                {
                    print(score + "it is !");
                    Scores _temp = new Scores();
                    _temp.name = name;
                    _temp.score = score;
                    _temp.distance = distance;
                    _temp.time = time;
                    HighScores.Insert(i - 1, _temp);
                    break;
                }
                if (i == HighScores.Count && i < LeaderboardLength)
                {
                    Scores _temp = new Scores();
                    _temp.name = name;
                    _temp.score = score;
                    _temp.distance = distance;
                    _temp.time = time;
                    HighScores.Add(_temp);
                    break;
                }
            }
        }

        i = 1;
        while (i <= LeaderboardLength && i <= HighScores.Count)
        {
            PlayerPrefs.SetString("HighScore" + i + "name", HighScores[i - 1].name);
            PlayerPrefs.SetFloat("HighScore" + i + "score", HighScores[i - 1].score);
            PlayerPrefs.SetFloat("HighScore" + i + "distance", HighScores[i - 1].distance);
            PlayerPrefs.SetFloat("HighScore" + i + "time", HighScores[i - 1].time);
            i++;
        }

    }
    public Scores GetCurrentScore()
    {
        Scores temp = new Scores();
        temp.score = PlayerPrefs.GetFloat("CurrentScore score");
        temp.name = PlayerPrefs.GetString("CurrentScore name");
        temp.distance = PlayerPrefs.GetFloat("CurrentScore distance");
        temp.time = PlayerPrefs.GetFloat("CurrentScore time");
        return temp;
    }
    public List<Scores> GetHighScore()
    {
        List<Scores> HighScores = new List<Scores>();

        int i = 1;
        while (i <= LeaderboardLength && PlayerPrefs.HasKey("HighScore" + i + "score"))
        {
            Scores temp = new Scores();
            temp.score = PlayerPrefs.GetFloat("HighScore" + i + "score");
            temp.name = PlayerPrefs.GetString("HighScore" + i + "name");
            temp.distance = PlayerPrefs.GetFloat("HighScore" + i + "distance");
            temp.time = PlayerPrefs.GetFloat("HighScore" + i + "time");
            HighScores.Add(temp);
            i++;
        }

        return HighScores;
    }

    public void ClearLeaderBoard()
    {
        //for(int i=0;i<HighScores.
        List<Scores> HighScores = GetHighScore();

        for (int i = 1; i <= HighScores.Count; i++)
        {
            PlayerPrefs.DeleteKey("HighScore" + i + "name");
            PlayerPrefs.DeleteKey("HighScore" + i + "score");
            PlayerPrefs.DeleteKey("HighScore" + i + "distance");
            PlayerPrefs.DeleteKey("HighScore" + i + "time");
        }
    }
    public void OnResetHS()
    {
        _instance.ClearLeaderBoard();
        _instance.SaveHighScore("Chris' Mom", 999999, 9999, 999);
        _instance.SaveHighScore("Tiphany", 110517, 1000, 200);
        _instance.SaveHighScore("Test 3", 100, 10, 10);
        _instance.SaveHighScore("Test 4", 90, 90, 9);
        _instance.SaveHighScore("Test 5", 80, 80, 8);
        _instance.SaveHighScore("Test 6", 70, 70, 7);
        _instance.SaveHighScore("Test 7", 60, 60, 6);
        _instance.SaveHighScore("Test 8", 50, 50, 5);
        _instance.SaveHighScore("Test 9", 40, 40, 4);
        _instance.SaveHighScore("Test 10", 30, 30, 3);
    }
    void OnApplicationQuit()
    {
        PlayerPrefs.Save();
    }
}

public class Scores
{
    public float score;
    public float distance;
    public float time;
    public string name;

}