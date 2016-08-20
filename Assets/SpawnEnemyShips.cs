using UnityEngine;
using System.Collections;

public class SpawnEnemyShips : MonoBehaviour
{

    public GameObject ship;


    public float interval = 10;

    public float timeLeftUntilSpawn = 0;

    void Update()
    {

        if (timeLeftUntilSpawn > 0)
            timeLeftUntilSpawn -= Time.deltaTime;

        if (timeLeftUntilSpawn <= 0)
        {
            float tempX = 0.5f;
            float tempY = 0.5f;

            Vector2 tempVector;
            
            while(tempX > 0 && tempX < 1){
                tempX = Random.Range(-1, 2);

            }

            while(tempY > 0 && tempY < 1){
                tempY = Random.Range(-1,2);
            }

            tempVector = new Vector2(tempX, tempY);


            tempVector = Camera.main.ViewportToWorldPoint(tempVector);
            Instantiate(ship, tempVector, Quaternion.identity);

            timeLeftUntilSpawn = interval;
        }

    }
}
