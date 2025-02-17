﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionManager : MonoBehaviour
{   
    // flashlight off and on materials
    public Material offMaterial;
    public Material onMaterial;

    // necessary objects for turning off phone
    public AudioSource phoneTrack;
    public GameObject phoneLight;

    public AudioSource phoneTrack1;
    public GameObject phoneLight1;

    public AudioSource phoneTrack2;
    public GameObject phoneLight2;

    // necessary object for swapping tv between on and off
    public AudioSource tvStatic;
    public GameObject videoPlayer;
    public GameObject offScreen;
    public GameObject onScreen;
    public GameObject tvLight;

    public AudioSource tvStatic1;
    public GameObject videoPlayer1;
    public GameObject offScreen1;
    public GameObject onScreen1;
    public GameObject tvLight1;

    public AudioSource tvStatic2;
    public GameObject videoPlayer2;
    public GameObject offScreen2;
    public GameObject onScreen2;
    public GameObject tvLight2;

    public GameObject lanternLight;

    public TeleportationManager teleportation;

    public GameObject menu;
    public GameObject rotationMenu1;
    public GameObject rotationMenu2;

    private bool onTVState = true;
    private bool onTVState1 = true;
    private bool onTVState2 = true;
    private bool onMenuState = false;

    public void doPrimaryAction(){
        
        // if we are grabbing flashlight other actions should take priority
        if(GrabbedManager.Instance.flashLightGrabbed || GrabbedManager.Instance.flashLightGrabbed1 || GrabbedManager.Instance.flashLightGrabbed2){
            // if phone is grabbed turn it off
            if(GrabbedManager.Instance.phoneGrabbed){
                turnOffPhone();
            }
            // otherwise check if remote is grabbed and turn swap state if it is
            else if(GrabbedManager.Instance.remoteGrabbed){
                swapTVState();
            }
            // if phone is grabbed turn it off
            else if(GrabbedManager.Instance.phoneGrabbed1){
                turnOffPhone1();
            }
            // otherwise check if remote is grabbed and turn swap state if it is
            else if(GrabbedManager.Instance.remoteGrabbed1){
                swapTVState1();
            }
            // otherwise we can turn the flashlight off
            else if(GrabbedManager.Instance.flashLightGrabbed){
                swapFlashLightSource();
            }
            // otherwise we can turn the flashlight off
            else if(GrabbedManager.Instance.flashLightGrabbed2){
                swapFlashLightSource2();
            }
            else{
                swapFlashLightSource1();
            }
        }
        // if we arent holding the flashlight we can do both actions of turning off
        // phone and swapping tv state simultaneously
        else{
            if(GrabbedManager.Instance.phoneGrabbed){
                turnOffPhone();
            }
            if(GrabbedManager.Instance.remoteGrabbed){
                swapTVState();
            }
            if(GrabbedManager.Instance.lanternGrabbed){
                swapLanternState();
            }
            // if phone is grabbed turn it off
            if(GrabbedManager.Instance.phoneGrabbed1){
                turnOffPhone1();
            }
            // otherwise check if remote is grabbed and turn swap state if it is
            if(GrabbedManager.Instance.remoteGrabbed1){
                swapTVState1();
            }
            // if phone is grabbed turn it off
            if(GrabbedManager.Instance.phoneGrabbed2){
                turnOffPhone2();
            }
            // otherwise check if remote is grabbed and turn swap state if it is
            if(GrabbedManager.Instance.remoteGrabbed2){
                swapTVState2();
            }
        }
        
    }

    public void swapLanternState(){
        if(lanternLight.activeSelf)
            lanternLight.SetActive(false);
        else
            lanternLight.SetActive(true);
    }

    public void toggleMenu(){
        onMenuState = !onMenuState;
        menu.SetActive(onMenuState);
        if(teleportation.inCieling){
            rotationMenu1.SetActive(onMenuState);
            rotationMenu2.SetActive(onMenuState);
        }
    }

    // swaps the state of the tv
    public void swapTVState(){
        // if tv is on do this
        if(onTVState){
            // turn off on screen, enable off screen, turn off video player object
            // and stop the audio. Make sure to swap bool
            onScreen.SetActive(false);
            offScreen.SetActive(true);
            videoPlayer.SetActive(false);
            tvLight.SetActive(false);
            tvStatic.Stop();
            onTVState = false;
        }
        // otherwise do this
        else{
            // turn on on screen, turn off off screen, turn on video palyer,
            // and start audio. Make sure to swap bool
            onScreen.SetActive(true);
            offScreen.SetActive(false);
            videoPlayer.SetActive(true);
            tvLight.SetActive(true);
            tvStatic.Play();
            onTVState = true;
        }
    }

    // swaps the state of the tv
    public void swapTVState1(){
        // if tv is on do this
        if(onTVState1){
            // turn off on screen, enable off screen, turn off video player object
            // and stop the audio. Make sure to swap bool
            onScreen1.SetActive(false);
            offScreen1.SetActive(true);
            videoPlayer1.SetActive(false);
            tvLight1.SetActive(false);
            tvStatic1.Stop();
            onTVState1 = false;
        }
        // otherwise do this
        else{
            // turn on on screen, turn off off screen, turn on video palyer,
            // and start audio. Make sure to swap bool
            onScreen1.SetActive(true);
            offScreen1.SetActive(false);
            videoPlayer1.SetActive(true);
            tvLight1.SetActive(true);
            tvStatic1.Play();
            onTVState1 = true;
        }
    }

    // swaps the state of the tv
    public void swapTVState2(){
        // if tv is on do this
        if(onTVState2){
            // turn off on screen, enable off screen, turn off video player object
            // and stop the audio. Make sure to swap bool
            onScreen2.SetActive(false);
            offScreen2.SetActive(true);
            videoPlayer2.SetActive(false);
            tvLight2.SetActive(false);
            tvStatic2.Stop();
            onTVState2 = false;
        }
        // otherwise do this
        else{
            // turn on on screen, turn off off screen, turn on video palyer,
            // and start audio. Make sure to swap bool
            onScreen2.SetActive(true);
            offScreen2.SetActive(false);
            videoPlayer2.SetActive(true);
            tvLight2.SetActive(true);
            tvStatic2.Play();
            onTVState2 = true;
        }
    }

    // turn off the phone
    public void turnOffPhone(){
        // stop the track and turn off the light
        phoneTrack.Stop();
        phoneLight.SetActive(false);
    }

    // turn off the phone
    public void turnOffPhone1(){
        // stop the track and turn off the light
        phoneTrack1.Stop();
        phoneLight1.SetActive(false);
    }

    // turn off the phone
    public void turnOffPhone2(){
        // stop the track and turn off the light
        phoneTrack2.Stop();
        phoneLight2.SetActive(false);
    }

    // swap the flash light on and off
    public void swapFlashLightSource(){
        // find flash light and get its spotlight, and the front of the flash light
        GameObject flash = GameObject.Find("FlashLight");

        GameObject light = flash.transform.GetChild(2).gameObject;

        GameObject light_body = flash.transform.GetChild(1).gameObject;
        
        // if the light is active, turn it off and swap the material on the
        // front of flash light
        if(light.activeSelf){
            light.SetActive(false);

            light_body.GetComponent<MeshRenderer>().material = offMaterial;
        }
        // do the opposite
        else{
            light.SetActive(true);

            light_body.GetComponent<MeshRenderer>().material = onMaterial;
        }
    }

    // swap the flash light on and off
    public void swapFlashLightSource1(){
        // find flash light and get its spotlight, and the front of the flash light
        GameObject flash = GameObject.Find("FlashLight1");

        GameObject light = flash.transform.GetChild(2).gameObject;

        GameObject light_body = flash.transform.GetChild(1).gameObject;
        
        // if the light is active, turn it off and swap the material on the
        // front of flash light
        if(light.activeSelf){
            light.SetActive(false);

            light_body.GetComponent<MeshRenderer>().material = offMaterial;
        }
        // do the opposite
        else{
            light.SetActive(true);

            light_body.GetComponent<MeshRenderer>().material = onMaterial;
        }
    }

    // swap the flash light on and off
    public void swapFlashLightSource2(){
        // find flash light and get its spotlight, and the front of the flash light
        GameObject flash = GameObject.Find("FlashLight2");

        GameObject light = flash.transform.GetChild(2).gameObject;

        GameObject light_body = flash.transform.GetChild(1).gameObject;
        
        // if the light is active, turn it off and swap the material on the
        // front of flash light
        if(light.activeSelf){
            light.SetActive(false);

            light_body.GetComponent<MeshRenderer>().material = offMaterial;
        }
        // do the opposite
        else{
            light.SetActive(true);

            light_body.GetComponent<MeshRenderer>().material = onMaterial;
        }
    }
}
