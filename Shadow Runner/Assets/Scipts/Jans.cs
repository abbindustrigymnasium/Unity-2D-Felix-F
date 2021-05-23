using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jans : MonoBehaviour{

//Debug.Log("")
//Justerbara variabler
public float MovementSpeed = 2;          
public float JumpForce = 1;
public float DbJumpForce = 4;
public float Timer = 0f;
public float MaxSlide = 1.5f;
public float MoveMultiply = 100f;
float mx;


//Audio

public AudioSource footsteps;
public AudioSource jump;
public AudioSource flip;
public AudioSource slide;
public AudioSource Music;
public bool Taken = false;

//Booleans
public float DbJump = 0; 
public bool JumpingA = false; 
public bool DbJumpA = false;
public bool isSliding = false;
public bool isRunning = true;
public bool isSpeeding = false;
public static bool isAlive = true;
//isGrounded
public LayerMask groundLayers;
public bool isGrounded = false;

//Slide

public BoxCollider2D regularCollider; 
public BoxCollider2D slideCollider; 
//Annat
public Animator animator;
public Rigidbody2D rb;




    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {                
        if(isRunning){
        Vector3 speedster = new Vector3(1f, 0f, 0f);
        transform.position += speedster * Time.deltaTime * MovementSpeed * MoveMultiply;       
        }



    //isGrounded grejer

            isGrounded = Physics2D.OverlapArea(new Vector2(transform.position.x - 0.5f, transform.position.y -2f),  
            new Vector2(transform.position.x + 0.5f, transform.position.y -2.2f), groundLayers);

    //funktioner
        Slide();
        Jump();

    //Code

      Vector3 movement = new Vector3(1f, 0f, 0f);      //skapare en förkortning för att skapa en horizontell vektor och kallar den "movement"
      //transform.position += movement * Time.deltaTime * MovementSpeed * MoveMultiply;          


        movement.x = 1f;
        movement.y = (Input.GetAxis("Vertical"));

//Animation-prarametets

        animator.SetFloat("Speed", movement.x); 
        animator.SetFloat("Height", Mathf.Abs(rb.velocity.y)); 
        animator.SetBool("DBJumpA", DbJumpA);
        animator.SetBool("JumpingA", JumpingA);
        animator.SetBool("isSliding", isSliding);
        

        if(rb.velocity.x < 0.5 && Time.deltaTime > 1){
            Debug.Log("YouDied");
        }

//misc


        if(isGrounded==true)
        {
                DbJumpA = false; 
         }        
         if (DbJump < 1 && isGrounded){
             DbJump = 1;
         }

                //Audio
                
        if(isGrounded && (movement.x != 0f) && !footsteps.isPlaying){
                    footsteps.Play();
        }
         else if(!isGrounded) {
                    footsteps.Stop();
        }
        if(isSliding && !slide.isPlaying && isGrounded){
            slide.Play();
        }
        if(!isGrounded){
            slide.Stop();
        }
        else if(!isSliding){
            slide.Stop();
        }
        if(JumpingA && !jump.isPlaying){
            jump.Play();
        }
        else if(!JumpingA){
            jump.Stop();
        }
        if(DbJumpA && !flip.isPlaying){
            flip.Play();
        }
       else if(!DbJumpA){
            flip.Stop();
        }
        if(!isAlive){
            flip.Stop();
            jump.Stop();
            slide.Stop();
            footsteps.Stop();
            Music.Stop();
        }
        
        if(isAlive == true && !Music.isPlaying){
            Music.Play();
        }
            if(PauseMenu.isPaused == true){
            flip.Pause();
            jump.Pause();
            slide.Pause();
            footsteps.Pause();
            Music.Pause();
        }
            if(!PauseMenu.isPaused){
            flip.UnPause();
            jump.UnPause();
            slide.UnPause();
            footsteps.UnPause();
            Music.UnPause();
        }

        if(isGrounded){
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

    }



    void Jump(){
        mx = Input.GetAxis("Horizontal");
        var velocity2 = Mathf.Abs(rb.velocity.y);
        var velocity = GetComponent<Rigidbody2D>().velocity.y;      //Använd för att lösa dubbelhoppsmomentum
        var JumpForceTrue = JumpForce * MoveMultiply;
        var DbJumpForceTrue = DbJumpForce * MoveMultiply;

        if(Input.GetButtonDown("Jump") && (DbJump > 0)&& !isGrounded){
        rb.velocity = new Vector2(rb.velocity.x, JumpForceTrue);
        DbJumpA = true;
        JumpingA = false;
        DbJump -= DbJump;
        MovementSpeed = 1.5f;
        }
        else if(Input.GetButtonDown("Jump") && isGrounded){
                rb.velocity = new Vector2(rb.velocity.x, DbJumpForceTrue);
                JumpingA = true;
                DbJump += 1;
                MovementSpeed = 1.5f;
           }

    }

        void Slide(){
            bool falling = false;
        if(Input.GetButtonDown("Slide") && !isSliding){
            isSliding = true;

            Timer = 0f;

        }
        if (Input.GetButtonDown("Slide") && !isGrounded)
        {
            Physics2D.gravity = new Vector2 (0f, -25f);
            slide.Play();
            falling = true;
            Timer = 10f;
            
        }
        if(isGrounded){
            Physics2D.gravity = new Vector2 (0f, -9.82f);
        }

        
        if(falling && isGrounded){
            isSliding = true;

            Timer = 0f;
        }


        if (isSliding && isGrounded)
        {
            Timer += Time.deltaTime;

            if(Timer > MaxSlide)
            isSliding = false;
            regularCollider.enabled = true;
            slideCollider.enabled = false;
            MovementSpeed = 1.5f; 

            if (Timer < MaxSlide){
            regularCollider.enabled = false;
            slideCollider.enabled = true;
            MovementSpeed = 2.25f;
            }
        }
        }

    
    void OnDrawGizmos() {       //Visa groundccheckboxen
        Gizmos.color = new Color (1,0,0,1f);
        Gizmos.DrawCube (new Vector2 (transform.position.x, transform.position.y -2.2f),
        new Vector2 (0.2f, 0.01f));
    }
}