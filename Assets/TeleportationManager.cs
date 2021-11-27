using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportationManager : MonoBehaviour
{
    public Vector3 defaultPosition;
    public Vector3 mergoPosition;
    public Vector3 giantPosition;
    public Vector3 cielingPosition;

    public GameObject player;
    public GameObject playerCollider;
    
    public bool inCieling = false;

    public GameObject rotationMenu1;
    public GameObject rotationMenu2;

    public void teleportToDefault(){
        player.SetActive(false);  
        player.transform.position = defaultPosition;
        playerCollider.transform.position = defaultPosition;
        player.SetActive(true);
        inCieling = false;
        rotationMenu1.SetActive(false);
        rotationMenu2.SetActive(false);
    }

    public void teleportToMergo(){
        player.SetActive(false);
        player.transform.position = mergoPosition;
        playerCollider.transform.position = mergoPosition;
        player.SetActive(true);
        inCieling = false;
        rotationMenu1.SetActive(false);
        rotationMenu2.SetActive(false);
    }

    public void teleportToGiant(){
        player.SetActive(false);
        player.transform.position = giantPosition;
        playerCollider.transform.position = giantPosition;
        player.SetActive(true);
        inCieling = false;
        rotationMenu1.SetActive(false);
        rotationMenu2.SetActive(false);
    }

    public void teleportToCieling(){
        player.SetActive(false);
        player.transform.position = cielingPosition;
        playerCollider.transform.position = cielingPosition;
        player.SetActive(true);
        inCieling = true;
        rotationMenu1.SetActive(true);
        rotationMenu2.SetActive(true);
    }
}
