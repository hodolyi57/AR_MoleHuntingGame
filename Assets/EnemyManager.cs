using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    List<Transform> spawnPos = new List<Transform>();
    public float spawnTime = 5.0f;
    public GameObject mole1;
    public GameObject mole2;
    public GameObject mole3;
    public GameObject mole4;
    public GameObject mole5;
    public float exp;
    public float lv2;
    public float lv3;
    public float lv4;
    public float lv5;
    public int killscore = 0;
    public int playerHP = 3;
    float deltaSpawnTime;
    bool isInited = false; 
    public int maxSpawnCnt = 10;
    public int curSpawnCnt = 0;
    public bool snakealive = false;
    public bool powerup = false;
    float powerupTime;
    int[] idx = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (powerup)
        {
            powerupTime += Time.deltaTime;
        }
        if (powerupTime > 5.0f)
        {
            powerupTime = 0.0f;
            powerup = false;
        }
        if (curSpawnCnt > maxSpawnCnt) return;

        GameObject target = GameObject.Find("Land(Clone)");
        // Land가 생성된 이후에만
        if (null!= target)
        {
            // spawnPos 읽기
            if (!isInited)
            {
                foreach (Transform pos in target.transform.Find("RespawnObj").transform)
                {
                    if (pos.tag == "Respawn")
                    {
                        spawnPos.Add(pos);
                    }
                }
                isInited = true;
            }
            deltaSpawnTime += Time.deltaTime;
            exp += Time.deltaTime;


            if (deltaSpawnTime > spawnTime)
            {
                deltaSpawnTime = 0;
                float x = Random.Range(-20.0f, 20.0f);
                int index = 0;
                foreach(int n in idx)
                {
                    if (n == 0)
                    {
                        // 뱀 소환
                        if (x <= -15.0f && !transform.Find("SnakeHeadPrefab").gameObject.active)
                        {
                            transform.Find("SnakeHeadPrefab").gameObject.SetActive(true);
                            return;
                        }
                        if (exp < lv2)
                        {
                            mole1.transform.localPosition = spawnPos[index].localPosition;
                            Instantiate(mole1, target.transform);
                            mole1.GetComponent<StatusController>().idx = index;
                        }
                        else if (exp < lv3)
                        {
                            mole2.transform.localPosition = spawnPos[index].localPosition;
                            Instantiate(mole2, target.transform);
                            mole2.GetComponent<StatusController>().idx = index;
                        }
                        else if (exp < lv4)
                        {

                            mole3.transform.localPosition = spawnPos[index].localPosition;
                            Instantiate(mole3, target.transform);
                            mole3.GetComponent<StatusController>().idx = index;
                        }
                        else if (exp < lv5)
                        {

                            mole4.transform.localPosition = spawnPos[index].localPosition;
                            Instantiate(mole4, target.transform);
                            mole4.GetComponent<StatusController>().idx = index;
                        }
                        else
                        {
                            mole5.transform.localPosition = spawnPos[index].localPosition;
                            Instantiate(mole5, target.transform);
                            mole5.GetComponent<StatusController>().idx = index;
                        }
                        curSpawnCnt++;
                        idx[index] = 1;
                        return;
                    }
                    index++;

                }

            }
        }

    }
    public void cleanIdx(int n)
    {
        Debug.Log("이거됨?");
        idx[n] = 0;
        curSpawnCnt--;
    }
}
