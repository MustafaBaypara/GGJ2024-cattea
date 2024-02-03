using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleSpawner : MonoBehaviour
{
    [SerializeField] private List<SpawnObject> list = new();

    [SerializeField] private List<GameObject> spawnObject = new();

    [SerializeField] private float spawnCooldown, maxCooldown;

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
                maxCooldown = Random.Range(10, 15);
                SpawnObject();
            }

            int destroyer = -32;

            foreach (var obj in spawnObject)
            {
                if (obj != null)
                {
                    obj.transform.position -= new Vector3(0f, 0f, Singleton.Speed * 1.5f * Time.deltaTime);

                    if (obj.transform.position.z < destroyer)
                    {
                        Destroy(obj);
                    }
                }
            }
        }
    }

    private void SpawnObject()
    {
        GameObject randomObject = list.ToArray()[0].Prefabs[0];

        GameObject obj = Instantiate(randomObject, list.ToArray()[0].Spawners[0].position, Quaternion.identity);

        spawnObject.Add(obj);
    }
}
