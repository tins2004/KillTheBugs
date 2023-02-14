using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopMenu : MonoBehaviour
{
    public PlayerControl realCoins_SC;
    public GameObject[] gun;
    [HideInInspector] public int bulletInBalo = 0;
    public TextMeshProUGUI bulletText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bulletText.text = bulletInBalo.ToString();
    }

    public void gun1()
    {
        if (realCoins_SC.RealCoins >= 250)
        {
            gun[0].SetActive(true);
            gun[1].SetActive(false);
            gun[2].SetActive(false);
            gun[3].SetActive(false);
            realCoins_SC.ShopmenuCoin(250);
        }
    }

    public void gun2()
    {
        if (realCoins_SC.RealCoins >= 600)
        {
            gun[0].SetActive(false);
            gun[1].SetActive(true);
            gun[2].SetActive(false);
            gun[3].SetActive(false);
            realCoins_SC.ShopmenuCoin(600);
        }
    }

    public void gun3()
    {
        if (realCoins_SC.RealCoins >= 600)
        {
            gun[0].SetActive(false);
            gun[1].SetActive(false);
            gun[2].SetActive(true);
            gun[3].SetActive(false);
            realCoins_SC.ShopmenuCoin(600);
        }
    }

    public void gun4()
    {
        if (realCoins_SC.RealCoins >= 1000)
        {
            gun[0].SetActive(false);
            gun[1].SetActive(false);
            gun[2].SetActive(false);
            gun[3].SetActive(true);
            realCoins_SC.ShopmenuCoin(1000);
        }
    }

    public void Armor()
    {
        if (realCoins_SC.RealCoins >= 250)
        {
            realCoins_SC.addArmor();
            realCoins_SC.ShopmenuCoin(250);
        }
    }

    public void Bullet()
    {
        if (realCoins_SC.RealCoins >= 100)
        {
            bulletInBalo += 30;
            realCoins_SC.ShopmenuCoin(100);
        }
    }
}
