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

    public Text m_Text;


    void Start () {
        gameObject.transform.position = new Vector3(-6.0f, -2.0f, 0.0f);
        startTouchPosition = Vector2.zero;
        endTouchPosition = Vector2.zero;
        directionTouch = Vector2.zero;
    }

    void Update()
    {


#if !UNITY_EDITOR || UNITY_STANDALONE || UNITY_WEBPLAYER

        if (takeInput)
        {
            if (Input.GetKeyUp(KeyCode.UpArrow))  //TODO: change position and start animation
            {
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
                    //print(endTouchPosition);
                    break;            
            }
        }
        if ((Mathf.Abs(directionTouch.x) > 200 || Mathf.Abs(directionTouch.y) > 200) && checkTouchDirection)
        {
            checkTouchDirection = false;
            if (directionTouch.x > 200)
            {
                print("punch");
                //TODO: punch
                StartCoroutine(TouchInputLag());
            }
            else if(directionTouch.x < -200)
            {
                print("doNothing");
                StartCoroutine(TouchInputLag());
            }
            else if(directionTouch.y > 200)
            {
                directionTouch.y = 0;
                isGrounded = false;
                print("jump");
                gameObject.transform.position = new Vector3(-6.0f, -1.2f, 0.0f);
                StartCoroutine(TouchInputLag());
            }
            else if(directionTouch.y < -200)
            {
                print("slide");
                gameObject.transform.position = new Vector3(-6.0f, -2.3f, 0.0f);
                gameObject.transform.rotation = Quaternion.Euler(0, 0, 90);
                StartCoroutine(TouchInputLag());
            }
        }

        if (!isGrounded)
        {
            if (directionTouch.y > 300)  //TODO: change position and start animation
            {
                isGrounded = true;
                print("upup");
                gameObject.transform.position = new Vector3(-6.0f, -0.2f, 0.0f);
                StartCoroutine(TouchInputLag());
            }
        }



#endif //End of mobile platform dependendent compilation section started above with #elif
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
    }

    public void ResetCharacterPosition() {
        gameObject.transform.position = new Vector3(-6.0f, -2.0f, 0.0f);
        gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    public void ResetTouchInput()
    {
        directionTouch = Vector2.zero;
        gameObject.transform.position = new Vector3(-6.0f, -2.0f, 0.0f);
        gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
    }

}
