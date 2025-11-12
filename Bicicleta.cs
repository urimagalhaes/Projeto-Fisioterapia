using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bicicleta : MonoBehaviour
{
    public float forceAmount = 10f;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        bool aPressed = Input.GetKey(KeyCode.A);
        bool dPressed = Input.GetKey(KeyCode.D);

        // Verifica se ambas estão pressionadas AO MESMO TEMPO
        if (aPressed && dPressed)
        {
            // Aplica força para frente
            rb.AddForce(transform.forward * forceAmount, ForceMode.Acceleration);
        }
    }
}
