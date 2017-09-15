using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public GameObject goodApplicant, badApplicant;
    public Vector3 spawnValues;
    public int hazardCount, goodApplicantCount, badApplicantCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public GUIText scoreText;
    public GUIText restartText;
    public GUIText gameOverText;

    private bool gameOver;
    private bool restart;

    private int score;

    private void Start()
    {
        restart = false;
        gameOver = false;
        restartText.text = "";
        gameOverText.text = "";

        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
    }

    private void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                //Application.LoadLevel(Application.loadedLevel);
            }
        }
    }

    private Vector3 RandomSpawnPosition() {
        return new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                //Vector3 spawnPositin = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, RandomSpawnPosition(), spawnRotation);
                //Instantiate(goodApplicant, RandomSpawnPosition(), spawnRotation);
                yield return new WaitForSeconds(spawnWait);

                if (gameOver)
                {
                    restartText.text = "Press 'R' to Restart";
                    restart = true;
                    break;
                }
            }
            yield return new WaitForSeconds(waveWait);
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over";
        gameOver = true;
    }
}
