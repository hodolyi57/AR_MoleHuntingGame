using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;
using GoogleARCore.Examples.Common;

#if UNITY_EDITOR
// Set up touch input propagation while using Instant Preview in the editor.
using Input = GoogleARCore.InstantPreviewInput;
#endif
public class TouchAction : MonoBehaviour
{
    public StatusController StatusController;
    //private Touch tempTouchs;
    private Vector3 touchPosition;
    public bool gameOver;
    //private bool touchOn;

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
    }



    // Update is called once per frame
    void Update()
    {
        // 게임오버일 때 재시작 처리
        if(gameOver)
        {
            if(Input.touchCount>0)
            {
                Touch restart = Input.GetTouch(0);
                if(restart.phase == TouchPhase.Began)
                {
                    Application.LoadLevel(Application.loadedLevel);
                }
            }
        }
        if (Input.touchCount > 0)
        {
            //Debug.Log(Input.touchCount);
            Touch touch = Input.GetTouch(0); ;

            RaycastHit hit;
            touchPosition = Input.GetTouch(0).position;
            Ray ray = Camera.main.ScreenPointToRay(touchPosition);
            //Destroy(gameObject);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.transform.tag == "Moles")
                {
                    if (touch.phase == TouchPhase.Began)
                    {
                        hit.transform.GetComponent<StatusController>().MoleHit();
                    }
                }
            }
        }
    }
}