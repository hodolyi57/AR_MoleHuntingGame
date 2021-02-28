using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusController : MonoBehaviour
{
    // Start is called before the first frame update
    public int hp;
    public int level;
    public int idx;
    public GameObject explodeEffect;
    public GameObject deathEffect;
    public GameObject hitEffect;
    public EnemyManager EnemyManager;
    public double maxLifetime;
    public double curLifetime;
    private bool dead = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!dead)
        {
            // 수명 지나면 폭발
            curLifetime += Time.deltaTime;
            if (curLifetime >= maxLifetime)
            {
                Explode();
                dead = true;
            }
        }

    }

    // 두더지 맞음
    public void MoleHit()
    {
        if(!dead)
        {
            GameObject sound = transform.GetChild(8).gameObject;
            sound.SendMessage("SoundHit");
            hitEffect.transform.localPosition = transform.localPosition;
            Instantiate(hitEffect, transform.parent);
            //Destroy(hitEffect, 1.0f);
            hp -= 10;
            if (hp <= 0)
            {
                MoleDead();
                dead = true;
            }
        }

    }


    // 두더지 사망
    void MoleDead()
    {
        if(!dead)
        {

            deathEffect.transform.localPosition = transform.localPosition;
            Instantiate(deathEffect, transform.parent);
            gameObject.SetActive(false);
            GameObject target = GameObject.Find("EnemyManager");
            // 뱀이라면
            if (level == 10)
            {
                target.GetComponent<EnemyManager>().powerup = true;

                target.GetComponent<EnemyManager>().killscore += 1;
                return;
            }
            target.GetComponent<EnemyManager>().cleanIdx(idx);
            target.GetComponent<EnemyManager>().killscore += 1;
        }
    }

    // 두더지 폭발
    public void Explode()
    {
        if(!dead)
        {
            //audioSource.clip = ad[1];
            //audioSource.Play();
            GameObject sound = transform.GetChild(8).gameObject;
            sound.SendMessage("SoundExplosive");
            explodeEffect.transform.localPosition = transform.localPosition;
            Instantiate(explodeEffect, transform.parent);
            gameObject.SetActive(false);
            GameObject target = GameObject.Find("EnemyManager");
            target.GetComponent<EnemyManager>().cleanIdx(idx);
            // 무적 상태 체크
            if(target.GetComponent<EnemyManager>().powerup == true)
            {
                return;
            }
            if(target.GetComponent<EnemyManager>().playerHP == 3)
            {
                GameObject heart = GameObject.Find("heart3");
                heart.SetActive(false);
                target.GetComponent<EnemyManager>().playerHP = 2;
                return;
            }
            if (target.GetComponent<EnemyManager>().playerHP == 2)
            {
                GameObject heart = GameObject.Find("heart2");
                heart.SetActive(false);
                target.GetComponent<EnemyManager>().playerHP = 1;
                return;
            }
            if (target.GetComponent<EnemyManager>().playerHP == 1)
            {
                GameObject heart = GameObject.Find("heart1");
                heart.SetActive(false);
                target.GetComponent<EnemyManager>().playerHP = 0;

                // 게임 오버 화면으로 이동
                target.GetComponent<TouchAction>().gameOver = true;
                return;
            }
        }
    }
}
