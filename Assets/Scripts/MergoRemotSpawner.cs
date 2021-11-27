using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergoRemotSpawner : MonoBehaviour
{
    public GameObject currentRemote;
    public GameObject parentObject;
    public Vector3 scale;

    public void spawnNewRemote(){
        // create new object
        GameObject newRemote = GameObject.Instantiate(currentRemote, parentObject.transform, false);
        // set its transform
        newRemote.transform.position = gameObject.transform.position;
        newRemote.transform.localScale = scale;

        if(newRemote.GetComponent<Rigidbody>() == null){
            newRemote.AddComponent<Rigidbody>();
        }
        
        // destoy old one
        Destroy(currentRemote);
        // update current
        currentRemote = newRemote;
    }
}
