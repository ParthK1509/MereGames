using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomLocationKey : MonoBehaviour
{
    public Transform[] GoldLocations;
    public int LocationNum;
    public int LocationNum2;
    public GameObject GoldKey;
    public GameObject SilverKey;
    public GameObject SilverKeyClone;

    void Start(){
            LocationNum= Random.Range(0,GoldLocations.Length);//generate random number
            Instantiate(GoldKey,GoldLocations[LocationNum].position,Quaternion.identity);
            LocationNum2 = Random.Range(0,GoldLocations.Length);
            SilverKeyClone = Instantiate(SilverKey,GoldLocations[LocationNum2].position,Quaternion.identity);
    }

}
