using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// class to keep track of what items are being held in the scene
public class GrabbedManager : MonoBehaviour
{
    // create a singleton
    public static GrabbedManager Instance {get; private set;}

    // booleans to track which objects are grabbed
    public bool flashLightGrabbed = false;
    public bool remoteGrabbed = false;
    public bool phoneGrabbed = false;
    public bool lanternGrabbed = false;

    public bool mergoCeilingGrabbed = false;
    public bool mergoSideWallGrabbed = false;
    public bool mergoOtherWallGrabbed = false;

    public Rigidbody rb;
    public Rigidbody rb2;

    // assign singleton
    void Start(){
        Instance = this;
    }

    // set flashLightGrabbed to true
    public void activateFlashGrab(){
        flashLightGrabbed = true;
    }

    // set flashLightGrabbed to false
    public void deactivateFlashGrab(){
        flashLightGrabbed = false;
    }

    // set flashLightGrabbed to true
    public void activateLantern(){
        lanternGrabbed = true;
    }

    // set flashLightGrabbed to false
    public void deactivateLantern(){
        lanternGrabbed = false;
    }

    // set remoteGrabbed to true
    public void activateRemoteGrab(){
        remoteGrabbed = true;
    }

    // set remoteGrabbed to false
    public void deactivateRemoteGrab(){
        remoteGrabbed = false;
    }

    // set phoneGrabbed to true
    public void activatePhoneGrab(){
        phoneGrabbed = true;
    }

    // set phoneGrabbed to false
    public void deactivatePhoneGrab(){
        phoneGrabbed = false;
    }

    public void activateCeiling(){
        mergoCeilingGrabbed = true;
    }

    public void deactivateCeiling(){
        mergoCeilingGrabbed = false;
    }

    public void activateSideWall(){
        mergoSideWallGrabbed = true;
    }

    public void deactivateSideWall(){
        mergoSideWallGrabbed = false;
    }

    public void activateOtherWall(){
        mergoOtherWallGrabbed = true;
    }

    public void deactivateOtherWall(){
        mergoOtherWallGrabbed = false;
    }

    public void turnOnGravitySideWall(){
        rb.isKinematic = false;
        rb.useGravity = true;
    }

    public void turnOnGravityOtherWall(){
        rb2.isKinematic = false;
        rb2.useGravity = true;
    }
}
