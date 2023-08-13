using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_Move : MonoBehaviour
{
    public int playerSpeed = 10;
    public int playerJumpPower = 500;
    private float moveX;
    public bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        PlayerMove ();
    }

    void PlayerMove(){
        //CONTROLS
        moveX = Input.GetAxis("Horizontal");
        if(Input.GetButtonDown ("Jump") && isGrounded == true){
            Jump();
        }
        //ANIMTIONS
        if (moveX != 0){
            GetComponent<Animator>().SetBool("isWalking",true);
        }else{
            GetComponent<Animator>().SetBool("isWalking",false);
        }
        //DIRECTION of PLAYER
        if(moveX<0.0f){
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (moveX > 0.0f){
            GetComponent<SpriteRenderer>().flipX = false;

        }
        //PHYSICS
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }

    void Jump(){
        //JUMPING CODE
        GetComponent<Rigidbody2D>().AddForce (Vector2.up * playerJumpPower);
        isGrounded = false;
    }

    void OnCollisionEnter2D (Collision2D col){
        if (col.gameObject.tag == "Ground"){
            isGrounded = true;
        }

    }
}
 