using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RetryScore : MonoBehaviour
{
    int score;

    public Text ScoreText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject target = GameObject.Find("EnemyManager");
        score = target.GetComponent<EnemyManager>().killscore;
        gameObject.GetComponent<Text>().text = "Score: " + score.ToString();
    }
}
