using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragAndThrow : MonoBehaviour
{

    Vector2 startPos, endPos, direction;
    float touchTimeStart, touchTimeFinish, timeInterval;
    [SerializeField]
    Image FadeScreen;
    [SerializeField]
    GameObject BlackCanvas;
    float time = 0;
    float time2 = 0;
    bool t = false;
    bool t2 = false;
    int Number = 0;
    [SerializeField]
    GameObject[] UIs;

    private void Start()
    {
        if (UIs == null || UIs.Length<3)
        {
            Debug.LogError("Set UIs!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
        }
        for (int i = 0; i < UIs.Length; i++)
        {
            UIs[i].SetActive(false);
        }
        UIs[Number].SetActive(true);
    }
    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            touchTimeStart = Time.time;
            startPos = Input.GetTouch(0).position;
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            touchTimeFinish = Time.time;
            timeInterval = touchTimeStart - touchTimeStart;
            endPos = Input.GetTouch(0).position;
            direction = startPos - endPos;
            //BlackCanvas.SetActive(true);


            if (direction.x > 400)
            {
                //NextUI();
                t = true;
                t2 = true;
                time = 0;
                time2 = 0;
                BlackCanvas.gameObject.SetActive(true);
            }

            if (direction.x < -400)
            {
                //PreviousUI();
                t = true;
                t2 = true;
                time = 0;
                time2 = 0;
                BlackCanvas.gameObject.SetActive(true);
            }
            
        }
        /*
        if (Input.anyKeyDown)
        {
            t = true;
            t2 = true;
            time = 0;
            time2 = 0;
            FadeScreen.gameObject.SetActive(true);
        }
        */

        if (time < 1.0F && t)
        {
            FadeScreen.color = new Color(0, 0, 0, Mathf.PingPong(time2, 255));
            time += Time.deltaTime;
            time2 += Time.deltaTime;
        }
        if (time > 1.0F && t2)
        {
            if (direction.x > 400)
            {
                PreviousUI();
            }

            if (direction.x < -400)
            {
                NextUI();
               
            }
            t2 = false;
            //Debug.Log("!!!!!!!!!!!!!!!!!!!!" + direction.x);
        }


        if (time > 1.0F && t)
        {

            FadeScreen.color = new Color(0, 0, 0, Mathf.PingPong(time2, 255));
            time += Time.deltaTime;
            time2 -= Time.deltaTime;
        }
        if (time > 2.0F && t)
        {
            t = false;
            BlackCanvas.gameObject.SetActive(false);
            Debug.Log("DID2");
        }
    }

    public void NextUI()
    {
        Number++;
        if (Number>2)
        {
            Number = 0;
        }
        for (int i = 0; i < UIs.Length; i++)
        {
            UIs[i].SetActive(false);
        }
        UIs[Number].SetActive(true);

    }
    public void PreviousUI()
    {
        Number--;
        if (Number < 0)
        {
            Number = 2;
        }
        for (int i = 0; i < UIs.Length; i++)
        {
            UIs[i].SetActive(false);
        }
        UIs[Number].SetActive(true);
    }
}