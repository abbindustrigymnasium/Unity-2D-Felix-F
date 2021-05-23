﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawn : MonoBehaviour
{

private float secondsToDestroy = 25f;   
void Start()
    {
        StartCoroutine(DestroySelf());
    }

    IEnumerator DestroySelf() 
    {
        yield return new WaitForSeconds(secondsToDestroy);
        Destroy(gameObject);
    }
    
}
