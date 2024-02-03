using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    private static Manager instance;

     private float timer = 0;

    public AudioSource GameSource;
    public AudioSource OneSource;

    [SerializeField] private AudioClip[] SoundEffect;
    [SerializeField] private AudioClip BGMusic;

    private void Awake()
    {

        Time.timeScale = 1;

        Singleton.Die = false;
        Singleton.Healthy = 2;
        Singleton.Move = true;
    }

    private void Start()
    {
        StartCoroutine(AudioPlay());
    }

    private void Update()
    {
        Controller();
    }

    private void Controller()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Singleton.Die)
        {
            SceneManager.LoadScene(1);
        }

        timer += Time.deltaTime;

        if (timer >= 20 && timer < 40)
        {
            Singleton.Speed = 30;
        }
        else if (timer >= 40)
        {
            Singleton.Speed = 40;
        }
    }

    private IEnumerator AudioPlay()
    {
        yield return new WaitForSeconds(45.27f);
        GameSource.clip = BGMusic;
        GameSource.loop = true;
        GameSource.Play();
    }
}
