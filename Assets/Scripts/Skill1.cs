using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill1 : MonoBehaviour
{
    public float SpeedBullet;
    public float reloadTime;
    public PlayerControl playerHeart_SC;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") 
        {
            playerHeart_SC.PlayerAddDame();
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Enemy") 
        {
            return;
        }
        Destroy(gameObject);
    }
}
