using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 100f;
    [SerializeField] float fastSpeed = 10f;
    [SerializeField] float slowSpeed = 5f;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float extraSpeedUp = 2f;

    // Start is called before the first frame update
    void Start()
    {
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        moveSpeed = slowSpeed;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "boost")
        {
            moveSpeed = fastSpeed;
        }
    }
    // Update is called once per frame
    void Update()
    {
        float moveAmount = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed * (Input.GetButton("Fire1") ? extraSpeedUp
         : 1f);
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;

        transform.Translate(0, moveAmount, 0);
        transform.Rotate(0, 0, -steerAmount); // opposite direction
    }
}
