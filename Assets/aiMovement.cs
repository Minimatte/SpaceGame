using UnityEngine;
using System.Collections;

public class aiMovement : MonoBehaviour
{

    public float searchRange = 30;
    public float shootRange = 10;

    public float acceleration = 5f;
    public float maxSpeed = 30;

    public GameObject targetLockOn;

    void Start()
    {
        targetLockOn = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {

        if (targetLockOn)
        {
            Vector3 dir = targetLockOn.transform.position - transform.position;
            float angle = (Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg) - 90;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            if (Vector2.Distance(transform.position, targetLockOn.transform.position) <= shootRange)
            {

                transform.SendMessage("Attack");
            }
        }
       /* else
        {
            foreach (RaycastHit2D hit in Physics2D.CircleCastAll(transform.position, searchRange, Vector2.up))
            {
                if (hit.collider.gameObject.tag == "Player")
                {
                    targetLockOn = hit.collider.gameObject;
                }
            }
        }*/
    }

    void FixedUpdate()
    {
        if (!targetLockOn || (targetLockOn && Vector2.Distance(transform.position, targetLockOn.transform.position) > shootRange) && (GetComponent<Rigidbody2D>().velocity.magnitude < maxSpeed))
            GetComponent<Rigidbody2D>().AddForce(transform.up * acceleration);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
            if (col.gameObject)
            {
                col.gameObject.SendMessage("ApplyDamage", 500f);
                gameObject.SendMessage("ApplyDamage", 500f);
            }
    }

}
