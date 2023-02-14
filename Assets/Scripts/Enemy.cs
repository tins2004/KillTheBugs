using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class Enemy : MonoBehaviour
{
    public int HeartEnemy;    

    protected NavMeshAgent enemy;
    
    public TextMeshPro[] textMeshPro;

    public Transform player;

    public Bullet bullet_SC;
    public PlayerControl playerHeart_SC;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
        text();
    }

    // Update is called once per frame
    void Update()
    {
        enemy.SetDestination(player.position);
 
        if (HeartEnemy <= 0) 
        {
            playerHeart_SC.AddCoins();
            Destroy(gameObject);
        }
        
    }

    void text()
    {
        int textname = Random.Range(0, 3);
        for (int i = 0; i < textMeshPro.Length; i++)
        {
            if (textname == 0) textMeshPro[i].text = "Syntax Error";
            else if (textname == 1) textMeshPro[i].text = "Runtime Error";
            else if (textname == 2) textMeshPro[i].text = "Logical Error";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") 
        {
            playerHeart_SC.PlayerAddDame();
            playerHeart_SC.AddCoins();
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Bullet") 
        {
            HeartEnemy -= bullet_SC.dame;
        }
    }

    public void AddCoins()
    {
        Destroy(gameObject);
    }
}
