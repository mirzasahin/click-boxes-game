using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private GameManager gameManager;

    [Header("---------- Audio Source ----------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;


    [Header("---------- Audio Clip ----------")]
    public AudioClip background;
    public AudioClip expolosionSFX;
    public AudioClip gameOverSFX;

    private void Start()
    {

        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        musicSource.clip = background;
        musicSource.Play();
    }

    private void Update()
    {
        if (gameManager.gameOver)
        {
            musicSource.Stop();
        }
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

}
