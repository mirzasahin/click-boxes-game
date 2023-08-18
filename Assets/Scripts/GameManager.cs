using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    AudioManager audioManager;

    public GameObject pauseScreen;
    public bool paused;


    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;

    public TextMeshProUGUI livesText;
    public int lives = 3;

    public GameObject gameOverMenu;
    public GameObject titleScreen;

    private int score;
    private float spawnRate = 1.0f;

    public bool gameOver;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio Manager").GetComponent<AudioManager>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ChangePaused();
        }
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

    public void UpdateLives(int livesToChange)
    {
        lives += livesToChange;
        livesText.text = "Lýves: " + lives;
        if (lives <= 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        gameOver = true;
        gameOverMenu.gameObject.SetActive(true);
        audioManager.PlaySFX(audioManager.gameOverSFX, 0.5f);
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
        UpdateLives(3);
    }

    void ChangePaused()
    {
        if (!paused)
        {
            paused = true;
            pauseScreen.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            paused = false;
            pauseScreen.SetActive(false);
            Time.timeScale = 1;
        }
    }


}
