using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour

{
    public AudioSource coin;
    public int rotateSpeed;
    // Start is called before the first frame update
public int coinValue = 1;
        private void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("Player")){
            ScoreManager.instance.ChangeScore(coinValue);   
            transform.position = new Vector3 (0f, 0f, 0f);
            //Destroy(this.gameObject);                       //Ändra till other.gameObject för en spike
        coin.Play();
            
        }   
    }
    void Update (){
        transform.Rotate(0, rotateSpeed, 0, Space.World);
    }
}
 