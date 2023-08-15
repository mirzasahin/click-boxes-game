using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    private int score;
    private float spawnRate = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
        score = 0;
        UpdateScore(0);
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator SpawnEnemy()
    {
        while(true)
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


}
