using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    public GameObject[] sections;
    public int xPos = 20;
    public bool creatingSection = false;
    public int secnum;
    // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // Update is called once per frame
    void Update()
    {
        if(creatingSection == false){
                creatingSection = true;
                StartCoroutine(GenerateSection());
        }
        IEnumerator GenerateSection()
        {
            secnum = Random.Range(0,3);//generate random number
            Instantiate(sections[secnum],new Vector3(xPos,0,0),Quaternion.identity);//for no rotation
            xPos+=20;
            yield return new WaitForSeconds(1);
            creatingSection = false;

        }
    }
}
