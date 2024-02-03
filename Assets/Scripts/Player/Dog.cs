using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class Dog : MonoBehaviour
{
    [SerializeField] private Vector3 movement;

  //  [SerializeField] private float characterHealt = 100;
    [SerializeField] private float characterSpeed;

    private void Update()
    {
        movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;

        Controller();
    }

    private void FixedUpdate()
    {
        BasicMovement(movement.x, movement.z);
    }

    private void Controller()
    {
        //Jump
    }

    private void BasicMovement(float x, float z)
    {
        Rigidbody rb = GetComponent<Rigidbody>();

        rb.velocity = new Vector3(x, rb.velocity.y, z) * characterSpeed * Time.deltaTime;
    }
}
