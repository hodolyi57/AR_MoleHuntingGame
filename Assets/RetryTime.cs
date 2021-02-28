using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RetryTime : MonoBehaviour
{
    public string time;

    public Text TimeText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        GameObject target = GameObject.Find("EnemyManager");
        if(!target.GetComponent<TouchAction>().gameOver)
        {
            time = string.Format("{0:0.#}", target.GetComponent<EnemyManager>().exp);
            
        }
        gameObject.GetComponent<Text>().text = "Time: " + time;
    }
}
