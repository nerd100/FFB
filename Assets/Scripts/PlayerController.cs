using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    bool takeInput = true;
    bool isGrounded = true;
    readonly bool doubleJumped = false;
    bool checkTouchDirection = true;

    Vector2 startTouchPosition;
    Vector2 endTouchPosition;
    Vector2 directionTouch;

    Vector3 startPosition;

    public Text m_Text;

    private bool doubleJumpIsPossible = false;
    public float PXHEIGHT = 0.64f;


    //Sounds

    public AudioClip shootSound1;
    public AudioClip shootSound2;
    public AudioClip jump1Sound;
    public AudioClip jump2Sound;
    public AudioClip slideSound;

    private AudioSource source;
    private float volLowRange = .5f;
    private float volHighRange = 1.0f;

    void Start () {
        startPosition = transform.position;
        startTouchPosition = Vector2.zero;
        endTouchPosition = Vector2.zero;
        directionTouch = Vector2.zero;

        source = GetComponent<AudioSource>();
    }

    void Update()
    {


#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_WEBPLAYER

        if (takeInput)
        {
            if (Input.GetKeyUp(KeyCode.UpArrow))  //TODO: change position and start animation
            {
                if (Random.Range(0, 2) == 0)
                {
                    source.PlayOneShot(shootSound1);
                }
                else
                {
                    source.PlayOneShot(shootSound2);
                }
                print("up");
                gameObject.transform.position = new Vector3(-6.0f, -1.2f, 0.0f);
                takeInput = false;
                isGrounded = false;
                StartCoroutine(InputLag());
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                print("down");
                gameObject.transform.position = new Vector3(-6.0f, -2.3f, 0.0f);
                gameObject.transform.rotation = Quaternion.Euler(0, 0, 90);
                takeInput = false;
                StartCoroutine(InputLag());
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                print("left");
                takeInput = false;
                StartCoroutine(InputLag());
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                print("right");
                takeInput = false;
                StartCoroutine(InputLag());
            }
        }
        if (!isGrounded) {
            if (Input.GetKeyDown(KeyCode.UpArrow))  //TODO: change position and start animation
            {
                isGrounded = true;
                print("upup");
                gameObject.transform.position = new Vector3(-6.0f, -0.2f, 0.0f);
                takeInput = false;
                StartCoroutine(InputLag());
            }
        }
#elif UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE //mobile controller code

        if (Input.touchCount > 0) {
            print(Input.touchCount);
            Touch myTouch = Input.GetTouch(0);
            m_Text.text = "Touch Position : " + myTouch.position + "direction :" +directionTouch;
            switch (myTouch.phase) { 
                case TouchPhase.Began:
                    startTouchPosition = myTouch.position;
                    //print(startTouchPosition);
                    break;

                case TouchPhase.Moved:
                    // Determine direction by comparing the current touch position with the initial one
                    directionTouch = myTouch.position - startTouchPosition;
                    break;
          
                case TouchPhase.Ended:
                    endTouchPosition = myTouch.position;
                    analyzeTouch(directionTouch);
                    break;            
            }
        }     

#endif //End of mobile platform dependendent compilation section started above with #elif
    }


    public void analyzeTouch(Vector2 directionTouch)
    {

        if (!isGrounded && doubleJumpIsPossible)
        {
            if ((Mathf.Abs(directionTouch.x) < 200 && Mathf.Abs(directionTouch.y) < 200))  //TODO: change position and start animation
            {
                source.PlayOneShot(jump2Sound);
                doubleJumpIsPossible = false;
                print("upup");
                gameObject.transform.position = new Vector3(startPosition.x, startPosition.y + PXHEIGHT * 2, 0.0f);
                StartCoroutine(TouchInputLag());
            }
        }
        else
        {
            if ((Mathf.Abs(directionTouch.x) < 200 && Mathf.Abs(directionTouch.y) < 200) && checkTouchDirection && isGrounded)
            {
                
                
                doubleJumpIsPossible = true;
                checkTouchDirection = false;
                isGrounded = false;
                source.PlayOneShot(jump1Sound);
                print("jump");
                gameObject.transform.position = new Vector3(startPosition.x, startPosition.y + PXHEIGHT, 0.0f);
                StartCoroutine(TouchInputLag());
            }

            else if ((Mathf.Abs(directionTouch.x) > 200 || Mathf.Abs(directionTouch.y) > 200) && checkTouchDirection && isGrounded)
            {
                checkTouchDirection = false;
                if (directionTouch.x > 200)
                {
                    if(Random.Range(0 ,2) == 0)
                    {
                        source.PlayOneShot(shootSound1);
                    }
                    else
                    {
                        source.PlayOneShot(shootSound2);
                    }
                    
                    print("shoot");
                    GetComponentInChildren<ShootProjectile>().Shoot();
                    StartCoroutine(TouchInputLag());
                }
                else if (directionTouch.y < -200)
                {
                    source.PlayOneShot(slideSound);
                    print("slide");
                    gameObject.transform.position = new Vector3(startPosition.x, startPosition.y - PXHEIGHT / 2, 0.0f);
                    gameObject.transform.rotation = Quaternion.Euler(0, 0, 90);
                    StartCoroutine(TouchInputLag());
                }
            }
        }

    }

    IEnumerator InputLag()
    {
        yield return new WaitForSeconds(1);
        ResetCharacterPosition();
        takeInput = true;
    }

    IEnumerator TouchInputLag()
    {
        yield return new WaitForSeconds(1);
        ResetTouchInput();
        checkTouchDirection = true;
        isGrounded = true;
    }

    public void ResetCharacterPosition() {
        gameObject.transform.position = new Vector3(startPosition.x, startPosition.y , 0.0f);
        gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    public void ResetTouchInput()
    {
        directionTouch = Vector2.zero;
        gameObject.transform.position = new Vector3(startPosition.x, startPosition.y, 0.0f);
        gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(this.gameObject);
    }
}
