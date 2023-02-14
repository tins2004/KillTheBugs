using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetSpam : MonoBehaviour
{
    public TextMeshProUGUI textTab;
    public GameObject tabMenu;

    bool canTab = false;
    
    public PlayerControl PlayerControl_SC;
    public PlayerGun[] PlayerGun_SC;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && canTab && PlayerGun_SC[1].iszoom == false && PlayerGun_SC[2].iszoom == false)   
        {
            tabMenu.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            PlayerControl_SC.canMove = false;
            PlayerGun_SC[0].canshoot = false;
            PlayerGun_SC[1].canshoot = false;
            PlayerGun_SC[2].canshoot = false;
            PlayerGun_SC[3].canshoot = false;
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") 
        {
            textTab.text = "true";
            canTab = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player") 
        {
            textTab.text = "false";
            canTab = false;
        }
    }

    public void CloseTab()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        tabMenu.SetActive(false);
        PlayerControl_SC.canMove = true;
        PlayerGun_SC[0].canshoot = true;
        PlayerGun_SC[1].canshoot = true;
        PlayerGun_SC[2].canshoot = true;
        PlayerGun_SC[3].canshoot = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
