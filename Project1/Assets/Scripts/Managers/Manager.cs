using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public GameObject Food;
    public GameObject Food2;
    public GameObject Food3;
    public GameObject swarm;
    public GameObject antHill;
    public GameObject[] enemyList;
    public int enemyCounter = 0;
    public int maxFood = 10;
    private int numFood = 0;
    public int maxEnemies = 3;
    public int enemyHardLimit = 20;
    public int levelRate = 10;
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
        swarm = Instantiate(swarm);
        antHill.GetComponent<GenerateAnt>().swarm = swarm;
        swarm.transform.position = Vector3.zero;
        swarm.GetComponent<SwarmMove>().addMember(Vector3.zero);
        StartCoroutine(incrementLimit());
    }

    // Update is called once per frame
    void Update()
    {
        if (numFood < maxFood)
            StartCoroutine(SpawnFood());
        if (numEnemies < maxEnemies && enemyList.Length > 0)
            StartCoroutine(SpawnEnemy());
        if (Constants.C.health <= 0)
        {
            gameOver = true;
            StartCoroutine(GameOver());
        }
    }
    public void DecrementNumFood(int points = 10)
    {
        numFood--;
        gameScore += points;
    }
    public void DecrementNumEnemies(int points = 10)
    {
        numEnemies--;
        gameScore += points;
    }

    IEnumerator SpawnEnemy()
    {
        numEnemies++; enemyCounter++;
        yield return new WaitForSeconds(Random.Range(2, 10));
        GameObject enemy;
        if (enemyCounter < 5)
        {
            enemy = Instantiate(enemyList[Random.Range(0, enemyList.Length - 1)]);
        }
        else
        {
            enemy = Instantiate(enemyList[Random.Range(0, enemyList.Length)]);
        }
        enemy.GetComponent<Enemy>().manager = this;
        GameObject[] avoid = {antHill, swarm};
        enemy.transform.position = Constants.C.notTouching(avoid,1);
    }
    IEnumerator SpawnFood()
    {
        numFood++;
        yield return new WaitForSeconds(Random.Range(2, 10));
        Vector3 newPos = Constants.C.notTouching(swarm);//Anthony
        int num = Random.Range(1, 6);

        if (num < 3)
        {
            GameObject instance = Instantiate(Food);
            instance.transform.position = newPos;
            Food food = instance.GetComponent<Food>();
            food.manager = this;
        }
        else if (num < 5)
        {
            GameObject instance = Instantiate(Food2);
            instance.transform.position = newPos;
            Food food = instance.GetComponent<Food>();
            food.manager = this;
        }
        else
        {
            GameObject instance = Instantiate(Food3);
            instance.transform.position = newPos;
            Food food = instance.GetComponent<Food>();
            food.manager = this;
        }
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
    //Anthony
    IEnumerator incrementLimit()
    {
        if (maxEnemies < enemyHardLimit)
        {
            yield return new WaitForSeconds(levelRate);
            maxEnemies++;
            if (maxEnemies % 10 == 0)
                levelRate+=5;
            if (maxEnemies > 10)
                maxEnemies += maxEnemies/5;
            StartCoroutine(incrementLimit());
        }
        else 
            yield return new WaitForEndOfFrame();
    }
}
