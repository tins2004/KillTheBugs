using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    [HideInInspector] public float MouseSpeed = 50f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void SetVolumeMaster(float volumeMaster)
    {
        if (volumeMaster <= -30)
        {
            volumeMaster = -80;
        }
        audioMixer.SetFloat("Master", volumeMaster);
    }

    public void SetMouseSpeed(float mouseSpeed)
    {
        MouseSpeed = mouseSpeed;
    }

}
