using UnityEngine;
using System.Collections;


[RequireComponent(typeof(Rigidbody2D))]
public class ShipMovement2D : MonoBehaviour
{

    public string verticalAxis = "Vertical";
    public string horizontalAxis = "Horizontal";

    public float speedMultiplier = 10;
    public float speed { get { return Input.GetAxisRaw(verticalAxis) * speedMultiplier * isBoosting(); } }

    public float rotationMultiplier = 5;

    void FixedUpdate()
    {
        if (speed > 0)
            GetComponent<Rigidbody2D>().AddForce(transform.up * speed);

        transform.Rotate(Vector3.forward, Input.GetAxisRaw(horizontalAxis) * -rotationMultiplier);


    }

    int isBoosting()
    {
        if (Input.GetAxisRaw("ShipBoost") != 0)
        {
            return 2;
        }
        else return 1;
    }
}
