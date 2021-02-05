﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2Controller : MonoBehaviour
{
    public float speed;
    public Text countText;
    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    private int count;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        count = 0;
        SetCountText();
    }

    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * speed;
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }

        if (other.gameObject.CompareTag("PickUp2"))
        {
            other.gameObject.SetActive(false);
            count = count + 100;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "High Score: " + count.ToString();
    }

}
