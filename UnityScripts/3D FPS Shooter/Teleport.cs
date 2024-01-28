using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject Playerg;
    public Transform Exit,playert;
    // public bool inside = false;
    void OnTriggerEnter(Collider other) {
    //         Debug.Log("Hello");
         if(other.CompareTag("Player"))
            Debug.Log("Hell");

    //         inside = true;
            Playerg.SetActive(false);
            playert.position = Exit.position;
            //WaitForSeconds
            Playerg.SetActive(true);
 
}
}
