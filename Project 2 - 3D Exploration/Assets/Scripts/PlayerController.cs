using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpStr = 4f;

    private Rigidbody rigidBody;
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


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rigidBody = GetComponent<Rigidbody>(); 
        collider = GetComponent<CapsuleCollider>();

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

      KeypadExit.gameObject.SetActive (false);
    }
    

    void Update()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        GameOver();

        if(DD.openDoor)
        {
            Debug.Log("Open the door!");

            DD.openDoor = false;

            VaultDoorClosed.gameObject.SetActive (false);
            VaultDoorOpen.gameObject.SetActive (true);
        }
        
        if (Input.GetKey(KeyCode.E))
        {
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

        if (win)
        {
            Restart();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        moveDirection = x * transform.right + z * transform.forward;
        if (isGrounded() && Input.GetKeyDown("space"))
        {
            rigidBody.AddForce(Vector3.up * jumpStr, ForceMode.VelocityChange);
        }
    }

    private bool isGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, collider.bounds.extents.y + .3f);
    }

    void Move()
    {
        Vector3 yVel = new Vector3 (0f, rigidBody.velocity.y, 0f);
        rigidBody.velocity = moveDirection * moveSpeed * Time.deltaTime;
        rigidBody.velocity += yVel;
    }
        

    void OnTriggerEnter(Collider other)
    {
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

        if (other.gameObject.CompareTag("WinCollider"))
        {
            win = true;
            winScreen.gameObject.SetActive(true);
            rigidBody.constraints = RigidbodyConstraints.FreezeAll;
            
        }

        if (other.gameObject.CompareTag("Keypad"))
        {
            AtKeypad = true;
        }
        
    }
    
    void GameOver()
    {
        if(lives == 0)
        {
            Restart();
            loseScreen.gameObject.SetActive(true);
            rigidBody.constraints = RigidbodyConstraints.FreezeAll;
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
