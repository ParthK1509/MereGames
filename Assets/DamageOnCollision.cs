using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Enemy"){
           gameObject.GetComponent<PlayerHealth>().TakeDamage(2);
        }
 
    }
}
