using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBox : MonoBehaviour
{
    public bool PlayerDead = true;
    // Start is called before the first frame update
        private void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("Player")){        
            Debug.Log("Killboxed");
            Jans.isAlive = false;                           //Ändra till other.gameObject för en spike
        }   
    }
}
