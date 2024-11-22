using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_DestroyAfterTime : MonoBehaviour
{
    private float time;
    public float secondsToLive;

    public void Start()
    {
        time = 0;
    }

    public void Update()
    {
        if (time < secondsToLive) 
        { 
            time += Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
