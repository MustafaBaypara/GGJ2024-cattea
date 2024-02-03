using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerExtras : MonoBehaviour
{
    [SerializeField] private Manager manager;
    
    private static PlayerExtras instance;
    public TextMeshProUGUI textMesh;
    public static PlayerExtras Instance 
    {  
        get 
        {
            if (instance == null)
            {
                instance = FindObjectOfType<PlayerExtras>();
            }
            return instance;
        } 
    }

    private float healCooldown = 0;
    private static bool healCheck = false;

    [SerializeField] private GameObject playerDeath;
    [SerializeField] private GameObject playerObject;
    [SerializeField] private GameObject newspaper;
    [SerializeField] private AudioClip DeathMusic;

    private void Update()
    {
        if (healCheck && !Singleton.Die)
        {
            healCooldown += Time.deltaTime;
        }
        if (healCooldown > 5)
        {
            healCheck = false;
            Singleton.Healthy = 2;
            healCooldown = 0;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Barrier"))
        {
            Singleton.Healthy -= 1;
            Debug.Log(Singleton.Healthy);

            if (healCheck && Singleton.Healthy <= 0)
            {
                Singleton.Die = true;
                StartCoroutine(Death());
            }

            healCheck = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Delivery"))
        {
        string tagToSearch = "food";
        Transform childWithTag = FindChildWithTag(transform, tagToSearch);

        // Eğer bulunduysa, childWithTag değişkenindeki obje ile işlemleri gerçekleştir
        if (childWithTag != null)
        {
            Singleton.Score += 1;
            Destroy(childWithTag.gameObject);
            textMesh.text = Singleton.Score.ToString();
        }
        
        }
    }
    public IEnumerator Death()
    {
        manager.OneSource.Stop();
        manager.GameSource.Stop();
        manager.GameSource.PlayOneShot(DeathMusic);
        playerDeath.SetActive(true);
        playerObject.SetActive(false);
        Singleton.Move = false;
        yield return new WaitForSeconds(2);
        newspaper.SetActive(true);
        yield return new WaitForSeconds(1);
        Time.timeScale = 0;
    }

    Transform FindChildWithTag(Transform parent, string tag)
    {
        foreach (Transform child in parent)
        {
            if (child.CompareTag(tag))
            {
                // Belirtilen etikete sahip child obje bulundu
                return child;
            }

            // Child'in altındaki child'leri kontrol etmek için rekürsif çağrı
            Transform childWithMatchingTag = FindChildWithTag(child, tag);
            if (childWithMatchingTag != null)
            {
                return childWithMatchingTag;
            }
        }

        // Bu noktaya kadar gelindiğinde belirli bir etiketle obje bulunamadı
        return null;
    }
}
