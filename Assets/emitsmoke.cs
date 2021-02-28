using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class emitsmoke : MonoBehaviour
{
    public ParticleSystem ps;
    public float psEmission;

    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        var emission = ps.emission; // ps.main, ps.shape
        emission.rate = psEmission;
    }
}
