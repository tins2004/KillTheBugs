using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    public float runningSpeed = 7.5f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    [HideInInspector] public int HeartPlayer = 2;

    CharacterController characterController;
    Animator m_Animator;

    Vector3 moveDirection = Vector3.zero;

    [HideInInspector] public bool canMove = true;

    [HideInInspector] public int RealCoins = 0;
    public TextMeshProUGUI textCoins;

    public TextMeshProUGUI armorText;

    public GameObject Lose;
    float loseNumber;

    AudioSource audioSource;
    public AudioClip soundRun;
    public AudioClip soundJump;
    bool isRun = false;
    bool isJump = false;
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        characterController = GetComponent<CharacterController>();
        m_Animator = gameObject.GetComponent<Animator>();
        RealCoins = 250;
    }

    void Update()
    {
        _PlayerControl();
        textCoins.text = RealCoins.ToString();

        if (HeartPlayer <= 0)
        {
            Lose.SetActive(true);
            if (loseNumber < 5)
            {
                loseNumber += Time.deltaTime;   
            }
            else
            {
                SceneManager.LoadScene(0);
            }
        }
        else if (HeartPlayer <= 1) armorText.text = "NULL";
        else armorText.text = "armor";
    }

    void _PlayerControl()
    {
        // We are grounded, so recalculate move direction based on axes
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        // Press Left Shift to run
        float curSpeedX = canMove ? runningSpeed * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? runningSpeed * Input.GetAxis("Horizontal") : 0;
        
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpSpeed;
            audioSource.PlayOneShot(soundJump, 1f);
            isJump = true;
        }
        else
        {
            moveDirection.y = movementDirectionY;
            isJump = false;
        }

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);

        // AnimControl and sound
        if (curSpeedX != 0 || curSpeedY != 0)
        {
            m_Animator.SetBool("Run", true);    
            if (!isRun) audioSource.PlayOneShot(soundRun, 1f);
            isRun = true;
        }
        else
        {
            m_Animator.SetBool("Run", false); 
            if (!isJump) audioSource.Stop();
            isRun = false;
        }
    }

    public void PlayerAddDame()
    {
        HeartPlayer -= 1;
        audioSource.PlayOneShot(soundJump, 1f);
    }

    public void AddCoins()
    {
        RealCoins += 100;
    }

    public void ShopmenuCoin(int coinsShop)
    {
        RealCoins -= coinsShop;
        Debug.Log(coinsShop);
    }
    
    public void addArmor()
    {
        HeartPlayer = 2;
        Debug.Log(HeartPlayer);
    }
}
