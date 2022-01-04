using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 100f;
    [SerializeField] float moveSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) Debug.Log("pressed fire1!");
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime * (Input.GetButton("Fire1") ? 3f : 1f);
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;

        transform.Translate(0, moveAmount, 0);
        transform.Rotate(0, 0, -steerAmount); // opposite direction
    }
}
