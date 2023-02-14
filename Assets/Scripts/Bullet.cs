using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float SpeedBullet;
    public float reloadTime;
    public int dame;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") 
        {
            return;
        }
        if (other.gameObject.tag == "Enemy") 
        {
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        gameObject.tag = "Bullet";
    }
}
