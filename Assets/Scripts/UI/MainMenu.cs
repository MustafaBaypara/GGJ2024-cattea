using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Net.NetworkInformation;

public class MainMenu : MonoBehaviour
{
    private AudioSource mainSource;

    public GameObject mainMenu;
    public GameObject credits;
    

    [SerializeField] private AudioClip loopClip;

    private void Awake()
    {
        mainSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (!mainSource.isPlaying)
        {
            mainSource.clip = loopClip;
            mainSource.loop = true;
            mainSource.Play();
        }
    }

    public void GamePlay()
    {
        SceneManager.LoadScene(1);
    }
    public void Credits()
    {
        credits.SetActive(true);
        mainMenu.SetActive(false);
    }
    public void back()
    {
        credits.SetActive(false);
        mainMenu.SetActive(true);
    }
}
