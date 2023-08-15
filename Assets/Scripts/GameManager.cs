using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEditor.SearchService;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;

    public GameObject gameOverMenu;
    public GameObject titleScreen;

    private int score;
    private float spawnRate = 1.0f;

    public bool gameOver;
    // Start is called before the first frame update
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator SpawnEnemy()
    {
        while(!gameOver)
        {
            yield return new WaitForSeconds(spawnRate);
            int randomIndex = Random.Range(0, targets.Count);
            Vector3 spawnPosition = new Vector3(Random.Range(-4, 4), 0, 0);
            Instantiate(targets[randomIndex], spawnPosition, targets[randomIndex].transform.rotation);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOver = true;
        gameOverMenu.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty)
    {
        gameOver = false;
        score = 0;
        spawnRate = spawnRate / difficulty;

        StartCoroutine(SpawnEnemy());
        UpdateScore(0);

        titleScreen.gameObject.SetActive(false);
    }


}
