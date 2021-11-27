using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zinnia.Data.Collection.List;

public class CielingSpawnRemote : MonoBehaviour
{
    public GameObject currentRemote;
    public GameObjectObservableList current_ignored;
    public GameObject parentObject;
    public Vector3 scale;

    public void spawnNewRemote(){
        // only spawn when not grabbed
        if(!GrabbedManager.Instance.remoteGrabbed2){
            // create new object
            GameObject newRemote = GameObject.Instantiate(currentRemote, parentObject.transform, false);
            // set its transform
            newRemote.transform.position = gameObject.transform.position;
            newRemote.transform.localScale = scale;
            // remove from ignored list
            current_ignored.Remove(currentRemote);
            // destoy old one
            Destroy(currentRemote);
            // update current
            currentRemote = newRemote;
        }
    }
}
