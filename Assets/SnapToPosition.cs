using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapToPosition : MonoBehaviour
{
    public string myTag;
    public GameObject ourObject;
    public Rigidbody rb = null;
    private Vector3 position;
    private Vector3 rotation;
    
    [SerializeField]
    int type = -1;

    void Start(){
        position = ourObject.transform.position;
        rotation = ourObject.transform.rotation.eulerAngles;
    }

    private void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == myTag){
            switch(type){
                case 1:
                    if(GrabbedManager.Instance.mergoCeilingGrabbed)
                        return;
                    break;
                case 2:
                    if(GrabbedManager.Instance.mergoSideWallGrabbed)
                        return;
                    break;
                case 3:
                    if(GrabbedManager.Instance.mergoOtherWallGrabbed)
                        return;
                    break;
                default:
                    return;
            }

            if(myTag != "MergoPlayset"){
                rb = ourObject.GetComponent<Rigidbody>();
                rb.isKinematic = true;
                rb.useGravity = false;
            }
            
            ourObject.transform.position = position;
            ourObject.transform.rotation = Quaternion.Euler(rotation);
            
        }
    }
}
