using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerGrab : MonoBehaviour
{
    public GameObject ball;
    public GameObject myHand;
    public GameObject winTxt;

    Vector3 ballPos;
    Collider ballCol;
    Rigidbody ballRb;

    int numObject=0;

    // Start is called before the first frame update
    void Start()
    {
        ballPos = ball.transform.position;
        ballCol = ball.GetComponent<SphereCollider>();
        ballRb = ball.GetComponent<Rigidbody>();
        winTxt.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.CompareTag("lanzar"))
        {
            Destroy(collision.gameObject);
            numObject++;
            
        }
        if (numObject == 6)
        {
            StartCoroutine(Win());
            //SceneManager.LoadScene("Menu");
        }
    }

    IEnumerator Win()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        winTxt.SetActive(true);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);

        SceneManager.LoadScene("Menu");

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }

    public void grabBall()
    {
        //ballCol.isTrigger = true;
        ball.transform.SetParent(myHand.transform);
        ball.transform.localPosition = new Vector3(0.01000024f, -0.7399997f, -3.239999f);
        ballRb.useGravity = false;
        ballRb.constraints = RigidbodyConstraints.FreezeAll;
        ballRb.velocity = Vector3.zero;

    }

    public void throwBall()
    {
        //this.GetComponent<PlayerGrab>().enabled = false;
        ball.transform.SetParent(null);
        ballRb.useGravity = true;
        ballRb.AddForce(myHand.transform.forward * 1500);
        ballRb.constraints = RigidbodyConstraints.None;
        //ball.transform.localPosition = ballPos;
    }
}