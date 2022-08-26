using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector3 spawnValue;
    public int hazardCount;
    public float spawnWait = 1;
    public float startWait = 3;
    public float delayWave = 20;
    public Text scoreGUI;
    public int scoreAmout;

    public Text restartText;
    public Text gameOverText;

    private bool _gameOver;
    private bool _restart;

    private void Start()
    {
        restartText.text = "";
        gameOverText.text = "";
        _gameOver = false;
        _restart = false;
        scoreAmout = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
    }
    private void Update()
    {
        if (_restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("MaiN", LoadSceneMode.Single);
            }
        }
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValue.x, spawnValue.x), spawnValue.y, spawnValue.z);
                Quaternion spawnRotation = Quaternion.identity;

                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Instantiate(hazard, spawnPosition, spawnRotation);

                yield return new WaitForSeconds(Random.Range(0.3f, spawnWait));
            }
            yield return new WaitForSeconds(delayWave);

            if (_gameOver)
            {
                restartText.text = "Press 'R' for RESTART";
                _restart = true;
                break;
            }
        }
    }
    void UpdateScore()
    {
        scoreGUI.text = "Ñ÷¸ò :" + scoreAmout;
    }
    public void addScore(int scoreAmount)
    {
        scoreAmout += scoreAmount;
        UpdateScore();
    }
    public void GameOver()
    {
        gameOverText.text = "Game Over";
        _gameOver = true;
    }
}
