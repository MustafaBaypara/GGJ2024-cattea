using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walkingAnimation : MonoBehaviour
{
    public Vector3 startScale;
    public Vector3 endScale = new Vector3(2.0f, 2.0f, 2.0f); // Bitiş ölçüleri
    public float duration = 2.0f; // Büyüme/küçülme süresi (saniye)
    public float delayBetweenChanges = 1.0f; // İşlemler arasındaki bekleme süresi (saniye)

    private float timer = 0.0f;
    private bool isGrowing = true;

    void Start()
    {
        transform.localScale = startScale;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (isGrowing)
        {
            transform.localScale = Vector3.Lerp(startScale, endScale, timer / duration);

            if (timer >= duration)
            {
                timer = 0.0f;
                isGrowing = false;
            }
        }
        else
        {
            transform.localScale = Vector3.Lerp(endScale, startScale, timer / duration);

            if (timer >= duration)
            {
                timer = 0.0f;
                isGrowing = true;
            }
        }

        // Belirli bir süre bekle
        if (timer >= duration)
        {
            // İşlemler arasında bekleme süresi
            if (timer >= duration + delayBetweenChanges)
            {
                timer = 0.0f;
            }
        }
    }
}
