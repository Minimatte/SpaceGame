using UnityEngine;
using System.Collections;

public class RandomPlanet : MonoBehaviour
{

    void Start()
    {
        float size = Random.Range(1f, 5f);

        transform.localScale = new Vector3(size, size, size);
       // transform.localRotation = Quaternion.AngleAxis(Random.Range(0f, 359f), Vector3.forward);
        GetComponent<health>().currentHealth = size * 200f;
        GetComponent<SpriteRenderer>().sprite = Resources.LoadAll<Sprite>("Planets/")[Random.Range(0, Resources.LoadAll<Sprite>("Planets/").Length - 1)];

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player" || col.gameObject.tag == "Enemy")
            if (col.gameObject)
                col.gameObject.SendMessage("ApplyDamage", float.MaxValue);
    }
}
