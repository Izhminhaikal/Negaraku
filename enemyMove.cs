using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemyMove : MonoBehaviour
{
    public int EnemySpeed;
    public int XMoveDirection;
    public bool facingRight = true;

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast (transform.position, new Vector2 (XMoveDirection, 0));
        gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (XMoveDirection, 0) * EnemySpeed;
        if (hit.distance < 2){
            Debug.Log("Ray Hit: " + hit.transform.name);
            Flip ();
            FlipEnemy ();
        if(hit && hit.collider.tag == "Player"){
            Destroy (hit.collider.gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }    
        }
    }
    void Flip (){
        if (XMoveDirection > 0){
            XMoveDirection = -1;
        } else{
            XMoveDirection = 1;
        }
    }

    void FlipEnemy(){
        facingRight = !facingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *=-1;
        transform.localScale= localScale;
    }
}