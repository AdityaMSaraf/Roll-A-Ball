using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject gameOverObject;
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    private int count;

    void Start()
    {
        count = 0;
        gameOverObject.SetActive(false);
        SetCountText();
        rb = GetComponent<Rigidbody>();
    }

    void OnMove(InputValue moveVal)
    {
        Vector2 moveVector = moveVal.Get<Vector2>();
        movementX = moveVector.x;
        movementY = moveVector.y;
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 12)
        {
            gameOverObject.SetActive(true);
        }
    }

    void FixedUpdate()
    {
        Vector3 movementVector = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movementVector * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }
}