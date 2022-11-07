using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public GameObject Food;
    public GameObject swarm;
    public GameObject antHill;
    public GameObject[] enemyList;
    public int maxFood = 10;
    private int numFood = 0;
    public int maxEnemies = 3;
    private int numEnemies = 0;
    private bool gameOver = false;
    const string highScoreKey = "HighScore";
    const string gameScoreKey = "GameScore";
    private int gameScore = 0;
    private int pastScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey(highScoreKey)) //key exists
        {
            pastScore = PlayerPrefs.GetInt(highScoreKey);
            Debug.Log("Found score " + pastScore);
        }
        else
        {
            PlayerPrefs.SetInt(highScoreKey, gameScore);
            Debug.Log("Setting high score");
        }
        if (!PlayerPrefs.HasKey(gameScoreKey))
        {
            PlayerPrefs.SetInt(gameScoreKey, pastScore);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(numFood < maxFood)
            StartCoroutine(SpawnFood());
        if (numEnemies < maxEnemies && enemyList.Length > 0)
            StartCoroutine(SpawnEnemy());
        if (Constants.C.health <= 0)
        {
            gameOver = true;
            StartCoroutine(GameOver());
        }
    }
    public void DecrementNumFood()
    {
        numFood--;
        gameScore += 10;
    }

    IEnumerator SpawnEnemy()
    {
        numEnemies++;
        yield return new WaitForSeconds(Random.Range(2, 10));
        GameObject enemy = Instantiate(enemyList[Random.Range(0, enemyList.Length)]);
        GameObject[] avoid = {antHill, swarm};
        enemy.transform.position = Constants.C.notTouching(avoid,1);
    }
    IEnumerator SpawnFood()
    {
        numFood++;
        yield return new WaitForSeconds(Random.Range(2, 10));
        Vector3 newPos = Constants.C.notTouching(swarm);//Anthony
        GameObject instance = Instantiate(Food);
        instance.transform.position = newPos;
        Food food = instance.GetComponent<Food>();
        food.manager = this;
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(0.2f);
        PlayerPrefs.SetInt(gameScoreKey, gameScore);
        if (gameScore > pastScore)
        {
            //new highscore
            PlayerPrefs.SetInt(highScoreKey, gameScore);
        }
        SceneManager.LoadScene("GameOver");
    }
}
