using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySkill1 : MonoBehaviour
{
    public GameObject bulletObject;
    public Transform bulletSpawn;
    public Skill1 bullet_SC;

    float TimeReloadSkill = 0f;
    // Start is called before the first frame update
    void Start()
    {
        TimeReloadSkill = bullet_SC.reloadTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (TimeReloadSkill > 0)
        {
            TimeReloadSkill -= Time.deltaTime;
        }

        if (TimeReloadSkill <= 0) 
        {
            Fire();
            TimeReloadSkill = bullet_SC.reloadTime;
        }
        
    }

    private void Fire()
    {
        GameObject projectile = Instantiate(bulletObject); //create bullets
        Physics.IgnoreCollision(projectile.GetComponent<Collider>(), bulletSpawn.parent.GetComponent<Collider>()); //spawm bullets
        projectile.transform.position = bulletSpawn.position; //set position bullet
        Vector3 rotation = projectile.transform.rotation.eulerAngles;
        projectile.transform.rotation = Quaternion.Euler(rotation.x, transform.eulerAngles.y, rotation.z); //set rotation bullets
        
        projectile.AddComponent<Rigidbody>(); // create rigid 
        projectile.GetComponent<Rigidbody>().useGravity = false; //un Gravity
        projectile.GetComponent<Rigidbody>().AddForce(bulletSpawn.forward * bullet_SC.SpeedBullet, ForceMode.Impulse);
    }
}
