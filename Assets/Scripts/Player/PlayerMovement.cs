using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float rotationForce;
    [SerializeField] float powerForce;
    float horizontalTurn;
    float upVariable;

    [SerializeField] float horizontalVelocity;
    [SerializeField] float verticalVelocity;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        horizontalTurn = -Input.GetAxis("Horizontal");
        transform.Rotate(new Vector3(0, 0, rotationForce * horizontalTurn * Time.deltaTime));
        upVariable = Input.GetAxis("Vertical");

        horizontalVelocity = rb.velocity.x;
        verticalVelocity = rb.velocity.y;
    }
    private void FixedUpdate()
    {
        if(upVariable >0)
            rb.AddForce(transform.up * powerForce);
    }
}
