using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpdateCanvas : MonoBehaviour
{

    GameObject player;

    public Image ammoImage;
    public Image rocketImage;
    public Image shipImage;

    private int playerStartHp;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerStartHp = (int)player.GetComponent<health>().currentHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            shipImage.fillAmount = player.GetComponent<health>().currentHealth / playerStartHp;
            ammoImage.fillAmount = player.GetComponents<PlayerShoot>()[0].currentBullets / player.GetComponents<PlayerShoot>()[0].maxBullets;
            rocketImage.fillAmount = player.GetComponents<PlayerShoot>()[1].currentBullets / player.GetComponents<PlayerShoot>()[1].maxBullets;

        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static IEnumerator blinkUIImage(Image image, float time, float interval)
    {
        while (true)
        {
            image.color = Color.Lerp(Color.white, Color.red, time);
            yield return new WaitForSeconds(interval);
            image.color = Color.Lerp(Color.red, Color.white, time);

        }
    }

}
