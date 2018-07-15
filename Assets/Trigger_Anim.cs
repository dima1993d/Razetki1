using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_Anim : MonoBehaviour {

    Animator anim;
    bool Up = true;
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == "Top")
                {
                    if (Up)
                    {
                        anim.SetTrigger("Down");
                        Up = !Up;
                    }
                    else
                    {
                        anim.SetTrigger("Up");
                        Up = !Up;
                    }
                }
            }

            

        }



    }
}
