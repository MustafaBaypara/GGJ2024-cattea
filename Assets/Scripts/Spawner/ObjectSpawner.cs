using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private List<SpawnObject> list = new();

    [SerializeField] private List<GameObject> spawnObject = new();

    [SerializeField] private float spawnCooldown, maxCooldown;

    [SerializeField] private int randomSpwValue;

    private void Start()
    {
        spawnCooldown = 0;
        maxCooldown = 0;
    }

    private void Update()
    {
        if (Singleton.Move)
        {
            if (spawnCooldown < maxCooldown)
            {
                spawnCooldown += Time.deltaTime;
            }
            else
            {
                spawnCooldown = 0;
                maxCooldown = Random.Range(maxCooldown, 20 / Singleton.Speed);
                int tmp = randomSpwValue;
                do
                {
                    randomSpwValue = Random.Range(0, list.ToArray()[0].Spawners.Length);
                } while (tmp == randomSpwValue);
                SpawnObject();
            }

            int destroyer = -50;

            foreach (var obj in spawnObject)
            {
                if (obj != null)
                {
                    obj.transform.position -= new Vector3(0f, 0f, Singleton.Speed * Time.deltaTime);

                    if (obj.transform.position.z < destroyer)
                    {
                        Destroy(obj);
                    }
                }
            }
        }
    }

    private static int random;

    private void SpawnObject()
    {
        int tmp = random;
        do
        {
            random = Random.Range(0, list.ToArray()[0].Prefabs.Length);
        } while (tmp == random);

        GameObject randomObject = list.ToArray()[0].Prefabs[random];

        Quaternion direction = Quaternion.Euler(0, Random.Range(-20, 20), 0);

        GameObject obj = Instantiate(randomObject, list.ToArray()[0].Spawners[randomSpwValue].position, direction);

        spawnObject.Add(obj);
    }
}
