using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float rotationSpeed =100;
    [SerializeField] float powerForce;
    [SerializeField] float fuel = 10000;
    float direction;
    float upForce;

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
        direction = -Input.GetAxis("Horizontal");
        transform.Rotate(new Vector3(0, 0, rotationSpeed * direction * Time.deltaTime));
        upForce = Input.GetAxis("Vertical");

        horizontalVelocity = rb.velocity.x;
        verticalVelocity = rb.velocity.y;
        if(isPaused() && fuel>0)
        {
            fuel--;
        }
    }
    private void FixedUpdate()
    {
        if(upForce >0 && isPaused() && fuel > 0)
        {
            rb.AddForce(transform.up * powerForce);
            fuel -= 10;
        }
    }

    public float GetFuel()
    {
        return fuel;
    }
    public float GetHorizontalSpeed()
    {
        return horizontalVelocity;
    }
    public float GetVerticalSpeed()
    {
        return verticalVelocity;
    }

    bool isPaused()
    {
        return Time.timeScale == 1;
    }
    public float GetRotation()
    {
        return transform.rotation.z;
    }
}
