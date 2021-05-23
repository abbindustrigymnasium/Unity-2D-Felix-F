using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI text;
    public TextMeshProUGUI text2;
    public float Score = 0;
    public float CoinTime = 0f;
    public float CoinTimeMax = 0.5f;
    int Coins;
    // Start is called before the first frame update
    void Start()
    {
        if(instance == null){
            instance = this;
        }
    }

    // Update is called once per frame
    public void ChangeScore(int coinValue){
        Coins += coinValue;
        text.text = "$" + Coins.ToString();
    }
        void FixedUpdate(){

        Score += Time.deltaTime * 10; 
        var ScoreRounded = System.Math.Round(Score, 0);
        //int CoinScore = (Coins*1000); //Funkar inte, den tar allt gånger 1000
        text2.text = "Score: " + ScoreRounded.ToString() ;
    }
    public void CoinSounds(){
        var LocalTaken = gameObject.GetComponent<Jans>().Taken;
        if(LocalTaken){
            Debug.Log("UnBruhMomento");
        }
    }
}
