using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elarabasiScript : MonoBehaviour
{
    GameObject[] foodObjects;
    GameObject player;
   void Start()
   {
    foodObjects = GameObject.FindGameObjectsWithTag("food");
    player = GameObject.Find("CharObject");
   }
   private void OnTriggerEnter(Collider other)
   {
       if (other.gameObject.CompareTag("Player"))
       {
        Vector3 position = new Vector3(0f, 2f, -1f);
        Quaternion rotation = Quaternion.Euler(0f, 0f, 0f);
        int randomIndex = UnityEngine.Random.Range(0, foodObjects.Length);
        GameObject randomFood = foodObjects[randomIndex];
        GameObject spawnedObject = Instantiate(randomFood, position, rotation);
        spawnedObject.transform.parent = player.transform;
        spawnedObject.name = "newfood";;
        spawnedObject.transform.position = player.transform.position + new Vector3(0f, 2f, -1f);
        randomIndex = UnityEngine.Random.Range(0, foodObjects.Length);
        randomFood = foodObjects[randomIndex];
        spawnedObject = Instantiate(randomFood, position, rotation);
        spawnedObject.transform.parent = player.transform;
        spawnedObject.name = "newfood";;
        spawnedObject.transform.position = player.transform.position + new Vector3(0f, 2f, -1f);
        randomIndex = UnityEngine.Random.Range(0, foodObjects.Length);
        randomFood = foodObjects[randomIndex];
        spawnedObject = Instantiate(randomFood, position, rotation);
        spawnedObject.transform.parent = player.transform;
        spawnedObject.name = "newfood";
        spawnedObject.transform.position = player.transform.position + new Vector3(0f, 2f, -1f);
       }
   }
}
