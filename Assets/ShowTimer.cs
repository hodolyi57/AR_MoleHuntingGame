using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowTimer : MonoBehaviour
{
    public Image img;
    float ratio;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 가장 수명이 얼마 안 남은 놈 찾기
        double max = 0;
        GameObject[] moles = GameObject.FindGameObjectsWithTag("Moles");
        foreach(GameObject n in moles)
        {
            if(max < n.GetComponent<StatusController>().curLifetime)
            {
                max = n.GetComponent<StatusController>().curLifetime;
                ratio = (float)(max / n.GetComponent<StatusController>().maxLifetime);
            }
        }
        //GameObject target = GameObject.Find("EnemyManager");
        //target.GetComponent<EnemyManager>().exp
        gameObject.GetComponent<Image>().fillAmount = ratio;
    }
}
