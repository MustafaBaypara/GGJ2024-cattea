using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charAnimationSC : MonoBehaviour
{
    public GameObject karakter; // Child objeyi bağlamak için bir değişken
     public GameObject kuyruk; // Child objeyi bağlamak için bir değişken
    public GameObject sprite; // Child objeyi bağlamak için bir değişken

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            death();
        }
    }
    void death()
    {
        karakter.SetActive(false);
        kuyruk.SetActive(false);
        sprite.SetActive(true);
    }
}
