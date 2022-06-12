using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubinScript : MonoBehaviour
{
    void Start()
    {
        this.RandomSpawn();
    }

    private void RandomSpawn()
    {
        float xPos = Random.Range(-25f, 25f);
        float yPos = Random.Range(-10f, 15f);

        this.transform.position = new Vector3(xPos, yPos, 1f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            RandomSpawn();
        }
    }
}
