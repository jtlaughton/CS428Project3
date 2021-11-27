using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zinnia.Data.Collection.List;

public class GiantFlashSpawner : MonoBehaviour
{
    public GameObject currentFlashLight;
    public GameObject parentObject;
    public Vector3 scale;
    public GameObjectObservableList current_ignored;

    public void spawnNewFlash(){
        // only spawn when not grabbed
        if(!GrabbedManager.Instance.flashLightGrabbed1){
            // create new object
            GameObject newFlash = GameObject.Instantiate(currentFlashLight, parentObject.transform, false);
            // set its transform
            newFlash.transform.position = gameObject.transform.position;
            newFlash.transform.localScale = scale;
            // remove from ignored list
            current_ignored.Remove(currentFlashLight);
            // destoy old one
            Destroy(currentFlashLight);
            // update current
            currentFlashLight = newFlash;
        }
    }
}
