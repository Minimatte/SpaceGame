using UnityEngine;
using System.Collections;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class BulletScript2D : MonoBehaviour
{

    

    public GameObject explosionEffect;
    public float explosionEffectLifeTime = 2;

    public float bulletSpeed = 50;
    public float lifeTime = 1;

    public string sendMessageName = "ApplyDamage";
    public float damage = 10f;

    void Awake()
    {

    }

    void Start()
    {
        
        GetComponent<Rigidbody2D>().velocity = transform.up * bulletSpeed;

        Destroy(gameObject, lifeTime);
    }


    void OnTriggerEnter2D(Collider2D coll)
    {

        if (coll.gameObject.tag == "Bullet")
        {
            if (explosionEffect)
                Destroy(Instantiate(explosionEffect, transform.position, Quaternion.identity), explosionEffectLifeTime);
            Destroy(coll.gameObject);
            Destroy(gameObject);
        }

        if (coll.gameObject.tag == "Player")
        {
            if (explosionEffect)
                Destroy(Instantiate(explosionEffect, transform.position, Quaternion.identity), explosionEffectLifeTime);
            coll.gameObject.SendMessage(sendMessageName, damage);
            Destroy(gameObject);
        }


        if (coll.gameObject.tag == "Enemy")
        {
            if (explosionEffect)
                Destroy(Instantiate(explosionEffect, transform.position, Quaternion.identity), explosionEffectLifeTime);
            coll.gameObject.SendMessage(sendMessageName, damage);
            Destroy(gameObject);
        }

    }

}
