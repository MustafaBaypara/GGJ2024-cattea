using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    [SerializeField] private Transform[] ground;

    private void Update()
    {
        GroundMovement(ground);
    }

    private void GroundMovement(Transform[] ground)
    {
        if (Singleton.Move)
        {
            Vector3 movement = new(0, 0, Singleton.Speed * Time.deltaTime);

            for (int i = 0; i < ground.Length; i++)
            {
                ground[i].position -= movement;

                if (ground[i].position.z <= -255)
                    ground[i].position = new Vector3(ground[i].position.x, ground[i].position.y, 255);
            }
        }
    }
}
