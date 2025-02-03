using System.Collections;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    public GameObject touchEffect; // Efecte visual quan es toca el cub
    private bool hasBeenTouched = false; // Controla si el cub ha estat tocat
    public static int score = 0; // Variable per la puntuació global

    private Vector3 moveDirection = Vector3.back;
    public float moveSpeed;

    private void Update()
    {
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        if (transform.position.magnitude > 50)
        {
            Destroy(gameObject);
        }
    }

    private void Awake()
    {
        Destroy(gameObject, 5); 
    }

    public void MarkAsTouched()
    {
        score += 10;

        if (touchEffect != null)
        {
            Instantiate(touchEffect, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }

    // NOVA FUNCIÓ: Detecta quan la mà toca el cub
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand")) 
        {
            MarkAsTouched();
        }
    }
}
