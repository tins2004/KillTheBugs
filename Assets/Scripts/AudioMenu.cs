using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioMenu : MonoBehaviour
{

    float timeAudio = 0;
    AudioSource audioSource;
    int soundNumber;
    public AudioClip[] soundError;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.PlayOneShot(soundError[0], 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (timeAudio < 3)
        {
            timeAudio += Time.deltaTime;   
        }
        else
        {
            soundNumber = Random.Range(0, 13);
            audioSource.PlayOneShot(soundError[soundNumber], 1f);
            timeAudio = 0;
        }

        if (Input.GetKeyDown(KeyCode.Tab) || Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(1);
        }
    }
}
