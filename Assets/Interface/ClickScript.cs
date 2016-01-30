﻿using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils;

public class ClickScript : MonoBehaviour {

    public bool testActivate;

	// Use this for initialization
	public void Start () 
    {
        VRInteractiveItem interactiveItem = gameObject.GetComponent<VRInteractiveItem>();
        if (interactiveItem == null)
        {
            Debug.LogError("Could not find VR interactive item script - does this object have it?");
            return;
        }

        interactiveItem.OnClick += OnActivate;
	
	}

    public void OnActivate()
    {
        Jam.Actions.RotateConsole instance = gameObject.GetComponent<Jam.Actions.RotateConsole>();
        instance.action.execute = true;
    }

    public void Update()
    {
        if (testActivate)
        {
            OnActivate();
            testActivate = false;
        }
    }
}