using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VRGaze : MonoBehaviour 
{
    public Image imgGaze;
    public float totalTime;
    bool gvrStatus;
    float gvrTimer;
    public Camera camera;
    public int distanceOfRay = 3500;
    public RaycastHit hit;


    bool hand = false;

    // Start is called before the first frame update
    void Start()
    {
        totalTime = 0.5f;
        gvrStatus = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gvrStatus)
        {
            gvrTimer += Time.deltaTime;
            imgGaze.fillAmount = gvrTimer / totalTime;
        }

        Ray ray = camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

        if (Physics.Raycast(ray, out hit, distanceOfRay))
        {

            if (imgGaze.fillAmount == 1 && hit.transform.CompareTag("Teleport"))
            {
                hit.transform.gameObject.GetComponent<Teleport>().TeleportPlayer();
            }
            if (imgGaze.fillAmount == 1 && hit.transform.CompareTag("pelota"))
            {
                if (!hand)
                {
                    
                    hit.transform.gameObject.GetComponent<PlayerGrab>().grabBall();
                    hand = true;
                    gvrStatus = false;
                    gvrTimer = 0;
                    imgGaze.fillAmount = 0;
                    Debug.Log("hand = "+hand);
                }

            }
            if (imgGaze.fillAmount == 1 && hit.transform.CompareTag("lanzar"))
            {
                if (hand)
                {
                    hit.transform.gameObject.GetComponent<PlayerGrab>().throwBall();
                    hand = false;
                    gvrStatus = false;
                    gvrTimer = 0;
                    imgGaze.fillAmount = 0;
                }
            }


        }
    }

    public void GVROn()
    {
        gvrStatus = true;
    }

    public void GVROff()
    {
        gvrStatus = false;
        gvrTimer = 0;
        imgGaze.fillAmount = 0;
    }
}

