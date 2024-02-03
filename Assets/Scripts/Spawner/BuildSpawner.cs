using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildSpawner : MonoBehaviour
{
    [SerializeField] private List<SpawnObject> list = new();

    [SerializeField] private List<GameObject> spawnObject = new();

    [SerializeField] private float cooldown, maxCooldown;

    private void Start()
    {
        cooldown = 0;
        maxCooldown = 0;
    }

    private void Update()
    {
        if (Singleton.Move)
        {
            if (cooldown < maxCooldown)
            {
                cooldown += Time.deltaTime;
            }
            else
            {
                cooldown = 0;
                maxCooldown = 40 / Singleton.Speed;
                SpawnBuild();
            }

            int destroyer = -32;

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

    static int random;

    private void SpawnBuild()
    {
        int tmp = random;
        do
        {
            random = Random.Range(0, list.ToArray()[0].Prefabs.Length);
        } while (tmp == random);

        GameObject randomObject = list.ToArray()[0].Prefabs[random];

        Quaternion direction;

        direction = Quaternion.Euler(0, -90, 0);

        GameObject obj = Instantiate(randomObject, list.ToArray()[0].Spawners[0].position, direction);

        spawnObject.Add(obj);
    }
}
