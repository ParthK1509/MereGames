using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerDeath : MonoBehaviour
{
    public float restartDelay=0.5f;
    //   public Vector3 pos(2.128035f,-0.05120653f,-0.04536989f);
    // public GameObject Parth;
    private int Lives=4;
    [SerializeField] private TextMeshProUGUI Livestext;
    void OnTriggerEnter2D(Collider2D collision) {
         if (collision.gameObject.CompareTag("Enemy")) {
             // Moves an object to the set position
            //  transform.position = new Vector2(-10.69199f,1.221235f);
             --Lives;
             Livestext.text = "Lives: "+ Lives;
             GetComponent<PlayerMovement>().enabled=false;
            Invoke("Restart", restartDelay);
             //this.gameObject.transform.position = new Vector3(2.128035f,-0.05120653f,-0.04536989f);
            //  this.gameObject.GetComponent<SpriteRenderer>().enabled=true;

             
            

             
              if(Lives == 0){
            //     En
            SceneManager.LoadScene("EndScene");
        
         }                          
              }
               if(collision.gameObject.CompareTag("House")){
          
          SceneManager.LoadScene("FinishScene");
         }

    }
    void Restart()
    {
         transform.position = new Vector2(-10.69199f,1.221235f);
             GetComponent<PlayerMovement>().enabled=true;
         
    }

 

 
}
