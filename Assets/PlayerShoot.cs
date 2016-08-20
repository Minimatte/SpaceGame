using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour
{

    public string shootTriggerButton = "Jump";


    public bool useAxis = false;
    bool shooting { get { if (useAxis) return Input.GetAxisRaw(shootTriggerButton) != 0; else return Input.GetButton(shootTriggerButton); } }

    bool canShoot { get { return cooldown <= 0 && currentBullets > 0 && !reloading; } }

    float cooldown = 0;
    public float maxcooldown = 0.05f;

    public GameObject bulletObject;

    public GameObject[] bulletSpawnPoint;

    public float currentBullets = 0;
    public float maxBullets = 10;

    public float reloadTime = 2f;

    public bool reloading = false;

    public Image uiImage;


    private float bulletPerSecondReload;
    void Start()
    {
        bulletPerSecondReload = maxBullets / reloadTime;
    }

    void Update()
    {
        if (Input.GetButtonDown("Reload"))
        {
            if (currentBullets != maxBullets)
            {
                reloading = true;
            }
        }

    }

    void FixedUpdate()
    {

        if (currentBullets == 0)
            reloading = true;

        if (cooldown > 0)
            cooldown -= Time.deltaTime;

        if (cooldown < 0)
            cooldown = 0;

        if (reloading && currentBullets < maxBullets)
        {
            currentBullets += bulletPerSecondReload * Time.deltaTime;
            if (currentBullets > maxBullets)
                currentBullets = maxBullets;
        }

        if (reloading && currentBullets == maxBullets)
            reloading = false;

        if (shooting && canShoot)
        {
            for (int i = 0; i < bulletSpawnPoint.Length; i++)
            {
                if (canShoot)
                {
                    GameObject temp = (GameObject)Instantiate(bulletObject, bulletSpawnPoint[i].transform.position, bulletSpawnPoint[i].transform.rotation);
                    Physics2D.IgnoreCollision(temp.GetComponent<Collider2D>(), GetComponent<Collider2D>());
                    currentBullets -= 1;
                }
            }
            cooldown = maxcooldown;
        }
    }


}
