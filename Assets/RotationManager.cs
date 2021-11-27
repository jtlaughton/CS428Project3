using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationManager : MonoBehaviour
{
    public GameObject toRotate;
    public GameObject playerBody;
    public GameObject playerAlias;
    public GameObject center;

    private int state = 0;

    public void doRotationClock(){
        Vector3 newRotation = new Vector3(0,0,0);

        switch(state){
            case 0:
                newRotation = new Vector3(90, 0, 0);
                state = 1;
                break;
            case 1:
                newRotation = new Vector3(180, 0, 0);
                state = 2;
                break;
            case 2:
                newRotation = new Vector3(270, 0, 0);
                state = 3;
                break;
            case 3:
                newRotation = new Vector3(0, 0, 0);
                state = 0;
                break;
        }
        
        toRotate.transform.rotation = Quaternion.Euler(newRotation);
        playerBody.SetActive(false);
        playerAlias.transform.position = center.transform.position;
        playerBody.SetActive(true);
    }
    public void doRotationCounter(){
        Vector3 newRotation = new Vector3(0,0,0);

        switch(state){
            case 0:
                newRotation = new Vector3(270, 0, 0);
                state = 3;
                break;
            case 1:
                newRotation = new Vector3(0, 0, 0);
                state = 0;
                break;
            case 2:
                newRotation = new Vector3(90, 0, 0);
                state = 1;
                break;
            case 3:
                newRotation = new Vector3(180, 0, 0);
                state = 2;
                break;
        }
        
        toRotate.transform.rotation = Quaternion.Euler(newRotation);
        playerBody.SetActive(false);
        playerAlias.transform.position = center.transform.position;
        playerBody.SetActive(true);
    }
}
