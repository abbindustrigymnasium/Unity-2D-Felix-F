using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("Player")){        
            Debug.Log("Spiked");
            ///Destroy(other.gameObject);                       //Ändra till other.gameObject för en spike
            Jans.isAlive = false;       
        }   
         if (other.gameObject.CompareTag("Killer")){        
            Debug.Log("ItemDestroyed");
            Destroy(this.gameObject);                       //Ändra till other.gameObject för en spike
        }   
}
}
