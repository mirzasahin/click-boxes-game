using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    private float minSpeed = 15;
    private float maxSpeed = 18;
    private float maxTorque = 10;
    private float xRange = 3.5f;
    private float ySpawnPos = -5;

    AudioManager audioManager;
    public ParticleSystem explosionParticle;

    public int pointValue;
    private Rigidbody targetRb;
    private GameManager gameManager;
    // Start is called before the first frame update

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio Manager").GetComponent<AudioManager>();
    }

    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

        transform.position = RandomSpawnPos();

        //gameManager = FindObjectOfType<GameManager>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (!gameManager.gameOver && !gameManager.paused)
        {
            if (gameObject.CompareTag("Good 1"))
            {
                audioManager.PlaySFX(audioManager.expolosionSFX1, 0.5f);
            }

            if (gameObject.CompareTag("Good 2"))
            {
                audioManager.PlaySFX(audioManager.expolosionSFX2, 0.5f);
            }

            if (gameObject.CompareTag("Good 3"))
            {
                audioManager.PlaySFX(audioManager.expolosionSFX3, 0.5f);
            }

            Destroy(gameObject);
            gameManager.UpdateScore(pointValue);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Sensor"))
        {
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Sensor") && !gameObject.CompareTag("Bad") && !gameManager.gameOver)
        {
            gameManager.UpdateLives(-1);
        }


    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }
}
