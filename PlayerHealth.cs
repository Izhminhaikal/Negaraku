using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y <-30){
            Die ();
        }
    }

    void OnCollisionEnter2D (Collision2D col){
        //Debug.Log("Player has collided with " + col.collider.name);
        if (col.gameObject.tag == "Threat"){
                Die ();
        }
    }
    void Die (){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        DataManagement.datamanagement.LoadData();
    }
}