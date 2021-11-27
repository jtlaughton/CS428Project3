using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergoFlashLightSpawner : MonoBehaviour
{
    public GameObject currentFlashLight;
    public GameObject parentObject;
    public Vector3 scale;

    public void spawnNewFlash(){
        // create new object
        GameObject newFlash = GameObject.Instantiate(currentFlashLight, parentObject.transform, false);
        // set its transform
        newFlash.transform.position = gameObject.transform.position;
        newFlash.transform.localScale = scale;

        if(newFlash.GetComponent<Rigidbody>() == null){
            newFlash.AddComponent<Rigidbody>();
        }
        
        // destoy old one
        Destroy(currentFlashLight);
        // update current
        currentFlashLight = newFlash;
    }
}
