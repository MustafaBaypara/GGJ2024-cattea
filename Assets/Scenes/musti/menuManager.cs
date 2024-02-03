using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuManager : MonoBehaviour
{
    private static menuManager instance;
    private float timer = 0;
    private void Awake()
    {
        if (instance == null)
        { 
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        Time.timeScale = 1;

        Singleton.Die = false;
        Singleton.Healthy = 2;
        Singleton.Move = true;
    }
    void Update()
    {
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
}
