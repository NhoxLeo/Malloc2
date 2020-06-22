﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// Handles Artifact Descriptions
/// </summary>
public class UI_ArtifactDisplayDescriptionPopup : MonoBehaviour
{
    public Text text;
    public static void DespawnAllInstances()
    {
        UI_ArtifactDisplayDescriptionPopup o = GameObject.Find("ItemDescriptionPopupWindow").GetComponent<UI_ArtifactDisplayDescriptionPopup>();
            o.transform.position = new Vector3(10000, 10000);
    }
}
