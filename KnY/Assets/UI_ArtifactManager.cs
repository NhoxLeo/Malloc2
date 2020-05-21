﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Handles the display of Artifacts in UI
/// </summary>
public class UI_ArtifactManager : MonoBehaviour
{
    public List<GameObject> inventoryDisplays;
    public Inventory playerInventory;
    public GameObject inventoryDisplayInstantiationTarget;

    private static List<UI_ArtifactManager> instances = new List<UI_ArtifactManager>();
    
    // Start is called before the first frame update
    void Start()
    {
        instances.RemoveAll(item => item == null);
        instances.Add(this);
        playerInventory = FindObjectOfType<PlayerController>().GetComponent<Inventory>();
    }

    /// <summary>
    /// Clears Artifact-Displays
    /// </summary>
    public static void ClearInventoryDisplays()
    {
        foreach(UI_ArtifactManager instance in instances)
        { 
            List<GameObject> removalList = new List<GameObject>();
            foreach(GameObject go in instance.inventoryDisplays)
            {
                removalList.Add(go);
            }
            foreach(GameObject go in removalList)
            {
                instance.inventoryDisplays.Remove(go);
                Destroy(go);
            }
        }
    }

    /// <summary>
    /// Fills Arifact-Displays
    /// </summary>
    public static void FillInventoryDisplays()
    {
        foreach (UI_ArtifactManager instance in instances)
        {
            int xPos = 40;
            int yPos = 0;
            foreach (Item item in instance.playerInventory.items)
            {
                GameObject instanceDisplay = Instantiate(instance.inventoryDisplayInstantiationTarget, instance.transform);
                instanceDisplay.GetComponent<RectTransform>().anchoredPosition = new Vector3(xPos, yPos);
                instanceDisplay.GetComponent<RectTransform>().localPosition = new Vector3(instanceDisplay.GetComponent<RectTransform>().localPosition.x, instanceDisplay.GetComponent<RectTransform>().localPosition.y, -1);
                instanceDisplay.GetComponent<Image>().sprite = FindObjectOfType<ItemIcons>().GetIcon(item.itemId);
                instanceDisplay.GetComponent<Image>().material = Item.GetItemMaterial(item.itemId);
                instanceDisplay.GetComponent<UI_ArtifactDisplayOnHover>().item = Item.GenerateItem(item.itemId);
                instanceDisplay.transform.GetChild(0).GetComponent<Text>().text = "x" + item.stacks;
                instance.inventoryDisplays.Add(instanceDisplay);
                xPos += 65;
            }
        }
    }
}