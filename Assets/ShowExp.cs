using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowExp : MonoBehaviour
{
    float exp;
    float std;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject target = GameObject.Find("EnemyManager");
        // 현재 누적 시간
        exp = target.GetComponent<EnemyManager>().exp;
        if(exp / target.GetComponent<EnemyManager>().lv5 > 1.0f)
            gameObject.GetComponent<Image>().fillAmount = 1.0f;
        else
            gameObject.GetComponent<Image>().fillAmount = exp / target.GetComponent<EnemyManager>().lv5;

    }
}
