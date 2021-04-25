﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpStr = 4f;

    public Rigidbody rigidBody;
    private CapsuleCollider collider;
    private Vector3 moveDirection;
    AudioSource audioSource;
    private Vector3 velocity;
    private float x;
    private float z;
    public float lives = 3f;
    [SerializeField]
    GameObject loseScreen;
    [SerializeField]
    GameObject winScreen;
    
    /*[SerializeField]
    GameObject SafeOpen;
    [SerializeField]
    GameObject SafeClosed;*/

    //private bool nearSafe;
    
    [SerializeField]
    public GameObject code1;
    [SerializeField]
    public GameObject code2;
    [SerializeField]
    public GameObject code3;
    [SerializeField]
    public GameObject code4;

    public bool nearcode1;
    public bool nearcode2;
    public bool nearcode3;
    public bool nearcode4;
    
   
    [SerializeField]
    GameObject LeverOneUp;
    [SerializeField]
    GameObject LeverOneDown;
    [SerializeField]
    GameObject LazerDoorOne;

    [SerializeField]
    GameObject LeverTwoUp;
    [SerializeField]
    GameObject LeverTwoDown;
    [SerializeField]
    GameObject LazerDoorTwo;

    [SerializeField]
    GameObject LeverThreeUp;
    [SerializeField]
    GameObject LeverThreeDown;
    [SerializeField]
    GameObject LazerDoorThree;

    private bool CloseToLeverOne;
    private bool CloseToLeverTwo;
    private bool CloseToLeverThree;
    private bool win;
    private bool inVault;

    private bool AtKeypad;

    public Image keypadScreen;

    public AudioClip leverSound;

    [SerializeField]
    GameObject button1;
    [SerializeField]
    GameObject button2;
    [SerializeField]
    GameObject button3;
    [SerializeField]
    GameObject button4;
    [SerializeField]
    GameObject button5;
    [SerializeField]
    GameObject button6;
    [SerializeField]
    GameObject button7;
    [SerializeField]
    GameObject button8;
    [SerializeField]
    GameObject button9;
    [SerializeField]
    GameObject buttonStar;
    [SerializeField]
    GameObject button0;
    [SerializeField]
    GameObject buttonPound;
    [SerializeField]
    GameObject displayPanel;
    [SerializeField]
    GameObject char1;
    [SerializeField]
    GameObject char2;
    [SerializeField]
    GameObject char3;
    [SerializeField]
    GameObject char4;

    [SerializeField]
    GameObject VaultDoorOpen;
    [SerializeField]
    GameObject VaultDoorClosed;

    public Text KeypadExit;

    public DigitalDisplay DD;

    
    public GameObject enemy;
    private FieldOfView fieldOfView;
    public bool playerCaught = false;
    public GameObject player;

    [SerializeField]
    GameObject caughtText;

    bool inMuseum = true;
    //bool inBrewery = true;
    //public GameObject caughtBreweryText;

    float originalHeight;
    public float reducedHeight;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rigidBody = GetComponent<Rigidbody>(); 
        collider = GetComponent<CapsuleCollider>();
        fieldOfView = enemy.GetComponent<FieldOfView>();

        originalHeight = collider.height;

        caughtText.gameObject.SetActive(false);
        winScreen.gameObject.SetActive (false);    
        loseScreen.gameObject.SetActive (false);
        LeverOneUp.gameObject.SetActive (true);
        LeverOneDown.gameObject.SetActive (false);
        LazerDoorOne.gameObject.SetActive (true);

        LeverTwoUp.gameObject.SetActive (true);
        LeverTwoDown.gameObject.SetActive (false);
        LazerDoorTwo.gameObject.SetActive (true);

        LeverThreeUp.gameObject.SetActive (true);
        LeverThreeDown.gameObject.SetActive (false);
        LazerDoorThree.gameObject.SetActive (true);

        VaultDoorClosed.gameObject.SetActive (true);
        VaultDoorOpen.gameObject.SetActive (false);

        CloseToLeverOne = false;
        CloseToLeverTwo = false;
        CloseToLeverThree = false;

        win = false;
    
        AtKeypad = false;

        keypadScreen.enabled = false;

        button1.gameObject.SetActive (false);
        button2.gameObject.SetActive (false);
        button3.gameObject.SetActive (false);
        button4.gameObject.SetActive (false);
        button5.gameObject.SetActive (false);
        button6.gameObject.SetActive (false);
        button7.gameObject.SetActive (false);
        button8.gameObject.SetActive (false);
        button9.gameObject.SetActive (false);
        buttonStar.gameObject.SetActive (false);
        button0.gameObject.SetActive (false);
        buttonPound.gameObject.SetActive (false);

        displayPanel.gameObject.SetActive (false);
        char1.gameObject.SetActive (false);
        char2.gameObject.SetActive (false);
        char3.gameObject.SetActive (false);
        char4.gameObject.SetActive (false);

        code1.gameObject.SetActive (false);
        code2.gameObject.SetActive (false);
        code3.gameObject.SetActive (false);
        code4.gameObject.SetActive (false);

        KeypadExit.gameObject.SetActive (false);
    }
    

    void Update()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        GameOver();
        Win();

        if (fieldOfView.targetSpotted)
        {
            Time.timeScale = 0;
        }

         if (playerCaught && Input.GetKeyDown(KeyCode.C) && inMuseum)
        {
            transform.position = new Vector3 (-3.52f, -0.88f, -4.1f);
            playerCaught = false;
            player.layer = LayerMask.NameToLayer("Target");
            rigidBody.constraints &= ~RigidbodyConstraints.FreezePositionX;
            rigidBody.constraints &= ~RigidbodyConstraints.FreezePositionY;
            rigidBody.constraints &= ~RigidbodyConstraints.FreezePositionZ;
        }
        /*else if (playerCaught && Input.GetKeyDown(KeyCode.C) && inBrewery)
        {
            transform.position = new Vector3 (4.38f, -0.71f, -23.46f);
            playerCaught = false;
            player.layer = LayerMask.NameToLayer("Target");
            rigidBody.constraints &= ~RigidbodyConstraints.FreezePositionX;
            rigidBody.constraints &= ~RigidbodyConstraints.FreezePositionZ;
        }
        */

       

        if (playerCaught && lives > 0 && inMuseum)
        {
            caughtText.gameObject.SetActive (true);
        }
        else
        {
            caughtText.gameObject.SetActive (false);
        }

        /*if (playerCaught && lives > 0 && inBrewery)
        {
            caughtBreweryText.gameObject.SetActive (true);
        }
        else
        {
            caughtBreweryText.gameObject.SetActive (false);
        }
        */
            

        if(DD.openDoor)
        {
            Debug.Log("Open the door!");

            DD.openDoor = false;

            VaultDoorClosed.gameObject.SetActive (false);
            VaultDoorOpen.gameObject.SetActive (true);
        }
        
        if (Input.GetKey(KeyCode.E))
        {
            /*if (nearSafe == true)
            {
                SafeClosed.gameObject.SetActive (false);
                SafeOpen.gameObject.SetActive (true);
            }*/
            
            if (nearcode1 == true)
            {
                code1.gameObject.SetActive (true);
            }

            if (nearcode2 == true)
            {
                code2.gameObject.SetActive (true);
            }

            if (nearcode3 == true)
            {
                code3.gameObject.SetActive (true);
            }

            if (nearcode4 == true)
            {
                code4.gameObject.SetActive (true);
            }

            if (CloseToLeverOne == true)
            {
                LeverOneUp.gameObject.SetActive (false);
                LeverOneDown.gameObject.SetActive (true);
                LazerDoorOne.gameObject.SetActive (false);
                audioSource.clip = leverSound;
                audioSource.Play();
                CloseToLeverOne = false;
            }

            if (CloseToLeverTwo == true)
            {
                LeverTwoUp.gameObject.SetActive (false);
                LeverTwoDown.gameObject.SetActive (true);
                LazerDoorTwo.gameObject.SetActive (false);
                audioSource.clip = leverSound;
                audioSource.Play();
                CloseToLeverTwo = false;
                
            }

            if (CloseToLeverThree == true)
            {
                LeverThreeUp.gameObject.SetActive (false);
                LeverThreeDown.gameObject.SetActive (true);
                LazerDoorThree.gameObject.SetActive (false);
                audioSource.clip = leverSound;
                audioSource.Play();
                CloseToLeverThree = false;
            }

            if (AtKeypad == true)
            {
                keypadScreen.enabled = true;

                button1.gameObject.SetActive (true);
                button2.gameObject.SetActive (true);
                button3.gameObject.SetActive (true);
                button4.gameObject.SetActive (true);
                button5.gameObject.SetActive (true);
                button6.gameObject.SetActive (true);
                button7.gameObject.SetActive (true);
                button8.gameObject.SetActive (true);
                button9.gameObject.SetActive (true);
                buttonStar.gameObject.SetActive (true);
                button0.gameObject.SetActive (true);
                buttonPound.gameObject.SetActive (true);

                displayPanel.gameObject.SetActive (true);
                char1.gameObject.SetActive (true);
                char2.gameObject.SetActive (true);
                char3.gameObject.SetActive (true);
                char4.gameObject.SetActive (true);

                KeypadExit.gameObject.SetActive (true);
            }
            /*
            if (inVault)
            {
                winScreen.gameObject.SetActive(true);
                rigidBody.constraints = RigidbodyConstraints.FreezeAll;
                Restart();
            }
            */
        }

        if (Input.GetKey(KeyCode.R))
        {
            keypadScreen.enabled = false;

            button1.gameObject.SetActive (false);
            button2.gameObject.SetActive (false);
            button3.gameObject.SetActive (false);
            button4.gameObject.SetActive (false);
            button5.gameObject.SetActive (false);
            button6.gameObject.SetActive (false);
            button7.gameObject.SetActive (false);
            button8.gameObject.SetActive (false);
            button9.gameObject.SetActive (false);
            buttonStar.gameObject.SetActive (false);
            button0.gameObject.SetActive (false);
            buttonPound.gameObject.SetActive (false);

            displayPanel.gameObject.SetActive (false);
            char1.gameObject.SetActive (false);
            char2.gameObject.SetActive (false);
            char3.gameObject.SetActive (false);
            char4.gameObject.SetActive (false);

            KeypadExit.gameObject.SetActive (false);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        moveDirection = x * transform.right + z * transform.forward;

        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            Crouch();
        }
        else if(Input.GetKeyUp(KeyCode.LeftControl))
        {
            Stand();
        }
    }
    /*
    private bool isGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, collider.bounds.extents.y + .3f);
    }
    */

    void Move()
    {
        Vector3 yVel = new Vector3 (0f, rigidBody.velocity.y, 0f);
        rigidBody.velocity = moveDirection * moveSpeed * Time.deltaTime;
        rigidBody.velocity += yVel;
    }
    //method to crouch 
    void Crouch()
    {
        collider.height = reducedHeight;
    }
    //method to stand up
    void Stand()
    {
        collider.height = originalHeight;
    }
        

    void OnTriggerEnter(Collider other)
    {
        /*if (other.gameObject.CompareTag("Safe"))
        {
            nearSafe = true;
        }
        */
        
        if (other.gameObject.CompareTag("LeverOne"))
        {
            CloseToLeverOne = true;
        }

        if (other.gameObject.CompareTag("LeverTwo"))
        {
            CloseToLeverTwo = true;
        }

        if (other.gameObject.CompareTag("LeverThree"))
        {
            CloseToLeverThree = true;
        }

        
        if (other.gameObject.CompareTag("code1"))
        {
            nearcode1 = true;
        }

        if (other.gameObject.CompareTag("code2"))
        {
            nearcode2 = true;
        }

        if (other.gameObject.CompareTag("code3"))
        {
            nearcode3 = true;
        }

        if (other.gameObject.CompareTag("code4"))
        {
            nearcode4 = true;
        }

        if (other.gameObject.CompareTag("WinCollider"))
        {
            inVault = true;
            winScreen.gameObject.SetActive(true);
            rigidBody.constraints = RigidbodyConstraints.FreezeAll;
            
        }

        if (other.gameObject.CompareTag("Keypad"))
        {
            AtKeypad = true;
        }

        /*if (other.gameObject.CompareTag("InMuseum"))
        {
            inMuseum = true;
            inBrewery = false;
        }
        */
        
    }

    void OnTriggerStay(Collider Other)
    {
        if (Other.gameObject.CompareTag("WinCollider"))
        {
            inVault = true;
        }
    }
    
    void GameOver()
    {
        if(lives <= 0)
        {
            Restart();
            loseScreen.gameObject.SetActive(true);
            rigidBody.constraints = RigidbodyConstraints.FreezeAll;
        }

    }

    void Win()
    {
        if(inVault)
        {
            winScreen.gameObject.SetActive(true);
            rigidBody.constraints = RigidbodyConstraints.FreezeAll;
            Restart(); 
        }
    }

    void Restart()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Main_Level");
        }
    }
    
    
    
}
