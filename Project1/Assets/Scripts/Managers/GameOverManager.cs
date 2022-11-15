using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOverManager : MonoBehaviour
{
    public TMPro.TMP_Text score;
    public TMPro.TMP_Text highScore;
    const string highScoreKey = "HighScore";
    const string gameScoreKey = "GameScore";
    private int gameScoreValue = 0;
    private int highScoreValue = 0;
    public AudioSource menuAdvance;
    // Start is called before the first frame update
    void Start()
    {
        gameScoreValue = PlayerPrefs.GetInt(gameScoreKey);
        highScoreValue = PlayerPrefs.GetInt(highScoreKey);
        if (gameScoreValue == highScoreValue)
        {
            score.text = "New High Score!\n" + gameScoreValue.ToString();
            highScore.text = "";
        }
        else
        {
            score.text = "Score: " + gameScoreValue.ToString();
            highScore.text = "High Score: " + highScoreValue.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("SampleScene");
            if (!menuAdvance.isPlaying)
                menuAdvance.PlayOneShot(menuAdvance.clip, 0.25f);
        }
    }
}
