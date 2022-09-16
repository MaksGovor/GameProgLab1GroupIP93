using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMove : MonoBehaviour
{

    private readonly float speed = 10f;
    private readonly float jumpForce = 15f;
    private readonly float lowerYPoint = -6f;
    private Vector3 startPos;
    private bool isGrounded;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && isGrounded) Jump();
        if (Input.GetButton("Horizontal")) Move();
        if (transform.position.y < lowerYPoint) {
            transform.position = startPos;
        }
    }

    private void Move()
    {
        Vector3 dir = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
    }

    private void Jump()
    {
        isGrounded = false;
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }
}
