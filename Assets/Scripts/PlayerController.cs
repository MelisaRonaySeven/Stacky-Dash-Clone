using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;
    public GameObject mPlayer;
    public float speed;
    public GameObject stackParent;
    public GameObject prevDash;
    public GameObject endingText;

    private bool isMoving = false;
    private Rigidbody mRigidbody;

    private void Awake()
    {
        endingText.SetActive(false);
        mRigidbody = mPlayer.GetComponent<Rigidbody>();
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Update()
    {
        if (ControllerInput.Instance.swipeRight && !isMoving)
        {
            isMoving = true;
            mRigidbody.velocity = Vector3.right * speed * Time.deltaTime;
        }
        else if (ControllerInput.Instance.swipeLeft && !isMoving)
        {
            isMoving = true;
            mRigidbody.velocity = Vector3.left * speed * Time.deltaTime;
        }
        else if (ControllerInput.Instance.swipeUp && !isMoving)
        {
            isMoving = true;
            mRigidbody.velocity = Vector3.forward * speed * Time.deltaTime;
        }
        else if (ControllerInput.Instance.swipeDown && !isMoving)
        {
            isMoving = true;
            mRigidbody.velocity = -Vector3.forward * speed * Time.deltaTime;
        }

        if (mRigidbody.velocity == Vector3.zero)
        {
            mPlayer.GetComponent<Animator>().Play("idle");
            isMoving = false;
        }
    }

    public void TakeDashes(GameObject dash)
    {
        dash.transform.SetParent(stackParent.transform);

        Vector3 pos = prevDash.transform.localPosition;
        pos.y -= 0.07f;
        dash.transform.localPosition = pos;

        Vector3 playerPos = mPlayer.transform.localPosition;
        playerPos.y += 0.07f;
        mPlayer.transform.localPosition = playerPos;
        mPlayer.GetComponent<Animator>().Play("jump-up");

        prevDash = dash;
        prevDash.GetComponent<BoxCollider>().isTrigger = false;
    }

    public void RemoveDashes(GameObject dash)
    {
        int i = prevDash.transform.GetSiblingIndex();
        prevDash.transform.SetParent(dash.transform.parent);

        Vector3 pos = prevDash.transform.localPosition;
        prevDash.transform.localPosition = dash.transform.localPosition;

        Vector3 playerPos = mPlayer.transform.localPosition;
        playerPos.y -= 0.07f;
        mPlayer.transform.localPosition = playerPos;
        mPlayer.GetComponent<Animator>().Play("jump-down");

        dash.GetComponent<BoxCollider>().isTrigger = false;

        if(stackParent.transform.childCount != 0)
        {
            if (stackParent.transform.childCount == 1)
            {
                SceneManager.LoadScene("SampleScene");
            }

            prevDash = stackParent.transform.GetChild(i - 1).gameObject;
        }
    }

    public void EndingPoint()
    {
        isMoving = true;
        mRigidbody.velocity = Vector3.zero;
        endingText.GetComponent<TextMesh>().text = "Game Finished! Your score is " + stackParent.transform.childCount;
        endingText.SetActive(true);
    }
}
