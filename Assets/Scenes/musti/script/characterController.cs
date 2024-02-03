using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CharacterControllerWithRigidbody : MonoBehaviour
{
    public float moveSpeed = 10f;
    /*
    public float diagonalSpeedMultiplier = 0.7f;
    public float jumpForce = 8f;
    private bool isGrounded;
    */

    private Rigidbody rb;

    /*
    public float rotationSpeed = 500f;
    public float rotationSpeedCam = 0f;

    public GameObject karakter;
    public GameObject woodenTray;
    public Camera mainCamera;
    */

    public Vector2 moveLimitX = new Vector2(-180f, 180f);
    public Vector2 moveLimitZ = new Vector2(-80f, 80f);

    void Start()
    {
        // Rigidbody bileşenini al veya ekle
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
            rb.freezeRotation = true; // Karakterin fiziksel dönüşlerini dondur
        }
    }

    void Update()
    {
        HandleMovement();
    }

    void HandleMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontal, 0f, vertical).normalized;

        /*
        if (horizontal != 0 && vertical != 0)
        {
            moveDirection *= diagonalSpeedMultiplier;
        }
        
        float targetRotationY = 0f;
        float targetCameraRotationY = Mathf.Clamp(mainCamera.transform.eulerAngles.y + (horizontal * Time.deltaTime), 9f, 13f);
        float targetTrayRotationZ = 0f;

        if (horizontal > 0)
        {
            targetRotationY = 15f;
            targetTrayRotationZ = -5f;
        }
        else if (horizontal < 0)
        {
            targetRotationY = -5f;
            targetTrayRotationZ = 5f;
        }

        float smoothedRotationY = Mathf.SmoothDampAngle(karakter.transform.eulerAngles.y, targetRotationY, ref rotationSpeed, 0.01f);
        karakter.transform.rotation = Quaternion.Euler(0f, smoothedRotationY, 0f);

        float smoothedCameraRotationY = Mathf.SmoothDampAngle(mainCamera.transform.eulerAngles.y, targetCameraRotationY, ref rotationSpeed, 0f);
        mainCamera.transform.rotation = Quaternion.Euler(mainCamera.transform.eulerAngles.x, smoothedCameraRotationY, mainCamera.transform.eulerAngles.z);

        float smoothedTrayRotationZ = Mathf.SmoothDampAngle(woodenTray.transform.eulerAngles.z, targetTrayRotationZ, ref rotationSpeedCam, 0.01f);
        woodenTray.transform.rotation = Quaternion.Euler(0f, 0f, smoothedTrayRotationZ);

        // Karakterin yerde olup olmadığını kontrol et
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 0.1f);

        // Zıplama kontrolü
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        */

        // Hareketi uygula
        if (!Singleton.Die)
        {
            rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.deltaTime);
        }
        // Hareket sınırlarını uygula
        rb.position = new Vector3(Mathf.Clamp(rb.position.x, moveLimitX.x, moveLimitX.y), rb.position.y, Mathf.Clamp(rb.position.z, moveLimitZ.x, moveLimitZ.y));
    }
}