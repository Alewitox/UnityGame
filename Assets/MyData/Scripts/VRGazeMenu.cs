using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VRGazeMenu : MonoBehaviour
{

    public Image imgGaze2;
    private float totalTime2;
    bool gvrStatus2;
    float gvrTimer2;
    public Camera cameraMenu2;
    private int distanceOfRay = 4002;
    private RaycastHit hit2;

    void Start()
    {
        totalTime2 = 1;

    }

    // Update is called once per frame
    void Update()
    {
        if (gvrStatus2)
        {
            gvrTimer2 += Time.deltaTime;
            imgGaze2.fillAmount = gvrTimer2 / totalTime2;

        }

        Ray ray = cameraMenu2.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

        if (Physics.Raycast(ray, out hit2, distanceOfRay))
        {

            if (imgGaze2.fillAmount == 1 && hit2.transform.CompareTag("pelota"))
            {
                SceneManager.LoadScene("02");
            }
            if (imgGaze2.fillAmount == 1 && hit2.transform.CompareTag("exit"))
            {
                Application.Quit();
            }

        }
    }

    public void GVROn()
    {
        gvrStatus2 = true;
    }

    public void GVROff()
    {
        gvrStatus2 = false;
        gvrTimer2 = 0;
        imgGaze2.fillAmount = 0;
    }
}