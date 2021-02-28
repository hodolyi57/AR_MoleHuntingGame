using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverCheck : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = transform.parent.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject target = GameObject.Find("EnemyManager");
        if (target.GetComponent<TouchAction>().gameOver)
        {
            animator.SetBool("isGameOver", true);
        }
        
    }
}
