using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private GameManager gameManager;


    [Header("---------- Audio Source ----------")]
    [SerializeField] public AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;


    [Header("---------- Audio Clip ----------")]
    public AudioClip background;
    public AudioClip expolosionSFX1;
    public AudioClip expolosionSFX2;
    public AudioClip expolosionSFX3;
    public AudioClip badWarningSFX;
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

    public void PlaySFX(AudioClip clip, float volume)
    {
        SFXSource.volume = volume;
        SFXSource.PlayOneShot(clip);
        Debug.Log(SFXSource.volume);
    }

}
