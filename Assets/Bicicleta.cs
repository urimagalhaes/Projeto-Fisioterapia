using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bicicleta : MonoBehaviour
{
    public float forceAmount = 10f;
    public float rotationForce = 5f; // Força para rotação
    private Rigidbody rb;

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
            // Aplica força para frente quando A+D estão pressionados
            rb.AddForce(transform.forward * forceAmount, ForceMode.Acceleration);
        }
        else if (dPressed)
        {
            // Apenas D pressionado: rotaciona para a direita
            rb.AddTorque(transform.up * rotationForce, ForceMode.Acceleration);
        }
        else if (aPressed)
        {
            // Apenas A pressionado: rotaciona para a esquerda
            rb.AddTorque(-transform.up * rotationForce, ForceMode.Acceleration);
        }
    }
}