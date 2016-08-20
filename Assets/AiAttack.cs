using UnityEngine;
using System.Collections;

public class AiAttack : MonoBehaviour
{

    public GameObject bullet;

    public GameObject[] bulletSpawnPoint;

    bool canShoot { get { return cooldown <= 0; } }

    float cooldown = 0;
    public float maxcooldown = 0.05f;


    void Update()
    {
        if (cooldown > 0)
            cooldown -= Time.deltaTime;

        if (cooldown < 0)
            cooldown = 0;
    }

    void Attack()
    {
        if (canShoot)
        {
            for (int i = 0; i < bulletSpawnPoint.Length; i++)
            {
                GameObject temp = (GameObject)Instantiate(bullet, bulletSpawnPoint[i].transform.position, bulletSpawnPoint[i].transform.rotation);
                Physics2D.IgnoreCollision(temp.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            }
            cooldown = maxcooldown;
        }

    }
}
