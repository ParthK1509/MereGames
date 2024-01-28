using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnWayPoints : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> waypoints;
    public float speed = 2;
    int index = 0;

    // Update is called once per frame
    void Update()
    {
        Vector3 newpos = Vector3.MoveTowards(transform.position, waypoints[index].transform.position, speed * Time.deltaTime);
        transform.position = newpos;

        // if(index = index.Count-1){

        // }
        if(index<waypoints.Count-1 && waypoints[index].transform.position == transform.position){
            index++;
        }else if(waypoints[index].transform.position == transform.position){
            index =0;
        }
    }
}
