﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class InventoryOld : MonoBehaviour {

    //public List<Item> items = new List<Item>();
    //public List<Item> inactiveArtifacts = new List<Item>();
    //public Dictionary<ItemSeries.Series, ItemSeries> itemSeries = new Dictionary<ItemSeries.Series, ItemSeries>();
    //public bool isPlayerInventory = false;
    //public int artifactItemsCount = 0;
    ///// <summary>
    ///// Adds an Item to the inventory and checks the ItemSeries
    ///// </summary>
    ///// <param name="item"></param>
    //public void AddItem(Item item)
    //{
    //    if (item == null)
    //    {
    //        return;
    //    }
    //    foreach (Item inventoryItem in items)
    //    {
    //        if (inventoryItem.itemId == item.itemId)
    //        {
    //            inventoryItem.AddAditionalStack(gameObject, item);
    //            if (isPlayerInventory)
    //            {
    //                UpdateInventoryUI();
    //            }
    //            return;
    //        }
    //    }
    //    item.owner = this;
    //    item.ApplyEffect(gameObject);
    //    items.Add(item);
    //    if(item.position == 0)
    //    { 
    //        item.position = AssignInventoryPosition(item.artifactItem,items);
    //    }

    //    CheckItemSeries();
    //    CountArtifactItems();
    //    if (isPlayerInventory)
    //    {
    //        UpdateInventoryUI();
    //    }
    //}

    //public void AddItem(Item item, bool updateUI)
    //{
    //    if (item == null)
    //    {
    //        return;
    //    }
    //    foreach (Item inventoryItem in items)
    //    {
    //        if (inventoryItem.itemId == item.itemId)
    //        {
    //            inventoryItem.AddAditionalStack(gameObject, item);
    //            if (isPlayerInventory)
    //            {
    //                UpdateInventoryUI();
    //            }
    //            return;
    //        }
    //    }
    //    item.owner = this;
    //    item.ApplyEffect(gameObject);
    //    items.Add(item);
    //    if (item.position == 0)
    //    {
    //        item.position = AssignInventoryPosition(item.artifactItem, items);
    //    }

    //    CheckItemSeries();
    //    CountArtifactItems();
    //    if (isPlayerInventory && updateUI)
    //    {
    //        UpdateInventoryUI();
    //    }
    //}


    ///// <summary>
    ///// Adds an Artifact to the inactive artifact inventroy
    ///// </summary>
    ///// <param name="item"></param>
    //public void AddInactiveArtifact(Item item)
    //{
    //    if (item == null)
    //    {
    //        return;
    //    }
    //    foreach (Item inventoryItem in inactiveArtifacts)
    //    {
    //        if (inventoryItem.itemId == item.itemId)
    //        {
    //            inventoryItem.AddAditionalStackWithoutReapplication(gameObject, item);
    //            return;
    //        }
    //    }
    //    item.owner = this;
    //    item.position = AssignInventoryPosition(item.artifactItem,inactiveArtifacts);
    //    inactiveArtifacts.Add(item);
    //}

    //public int AssignInventoryPosition(bool isArtifactItem,List<Item> itemList)
    //{
    //    if(isArtifactItem)
    //    {
    //        bool[] positions = new bool[8];
    //        foreach(Item i in itemList)
    //        {
    //            if(i.artifactItem)
    //            {
    //                positions[i.position] = true;
    //            }
    //        }
    //        for(int i = 1; i < positions.Length;i++)
    //        {
    //            if(!positions[i])
    //            {
    //                return i;
    //            }
    //        }
    //    }
    //    else
    //    {
    //        bool[] positions = new bool[21];
    //        foreach (Item i in items)
    //        {
    //            if (!i.artifactItem)
    //            {
    //                positions[i.position] = true;
    //            }
    //        }
    //        for (int i = 1; i < positions.Length; i++)
    //        {
    //            if (!positions[i])
    //            {
    //                return i;
    //            }
    //        }
    //    }
    //    return 0;
    //}

    //public void SwitchArtifactInInventorys(Item activeArtifact,Item inactiveArtifact)
    //{
    //    Item item1 = activeArtifact;
    //    Item item2 = inactiveArtifact;
    //    int posA = item1.position;
    //    item1.position = item2.position;
    //    item2.position = posA;
    //    RemoveItem(activeArtifact,false);
    //    inactiveArtifacts.Add(activeArtifact);
    //    inactiveArtifacts.Remove(inactiveArtifact);
    //    AddItem(inactiveArtifact,false);
    //    CheckItemSeries();
    //}

    //public void SwitchArtifactInInventorys(Item artifact, bool activeArtifact)
    //{
    //    if(activeArtifact)
    //    {
    //        RemoveItem(artifact,false);
    //        inactiveArtifacts.Add(artifact);
    //    }
    //    else
    //    {
    //        inactiveArtifacts.Remove(artifact);
    //        AddItem(artifact,false);
    //    }
    //    CheckItemSeries();
    //}

    //public bool ContainsItem(int id)
    //{
    //    foreach(Item item in items)
    //    {
    //        if(item.itemId == id)
    //        {
    //            return true;
    //        }
    //    }
    //    return false;
    //}

    //public bool ContainsInactiveArtifact(int id)
    //{
    //    foreach (Item item in inactiveArtifacts)
    //    {
    //        if (item.itemId == id)
    //        {
    //            return true;
    //        }
    //    }
    //    return false;
    //}

    //private void CheckItemSeries()
    //{
    //    foreach (ItemSeries series in itemSeries.Values)
    //    {
    //        series.RemoveEffect(gameObject);
    //    }
    //    itemSeries = ItemSeries.CheckSeries(items, itemSeries);
    //    foreach (ItemSeries series in itemSeries.Values)
    //    {
    //        series.ApplyEffect(gameObject);
    //    }


    //    if (GetComponent<PlayerController>() != null) // Change Sword Glowcolor depending on series
    //    {
    //        GetComponent<PlayerController>().swordGlowColor = new List<Color>();
    //        foreach (ItemSeries series in itemSeries.Values)
    //        {
    //            if (series.conditionsNeeded[0] <= series.totalConditionsMet)
    //            {
    //                GetComponent<PlayerController>().swordGlowColor.Add(series.color);
    //            }
    //        }
    //        GetComponent<PlayerController>().ChangeSwordGlow();
    //    }
        
    //}

    //public void CountArtifactItems()
    //{
    //    artifactItemsCount = 0;
    //    foreach(Item item in items)
    //    {
    //        if(item.artifactItem)
    //        {
    //            artifactItemsCount++;
    //        }
    //    }
    //}

    //public void RemoveItem(Item pItem)
    //{
    //    Item itemToBeRemoved = null;
    //    foreach(Item item in items)
    //    {
    //        if(item.itemId == pItem.itemId)
    //        {
    //            itemToBeRemoved = item;
    //        }
    //    }
    //    if (itemToBeRemoved != null)
    //    {
    //        itemToBeRemoved.RemoveEffect(gameObject);
    //        items.Remove(itemToBeRemoved);
    //    }
    //    else
    //    {
    //        foreach (Item item in inactiveArtifacts)
    //        {
    //            if (item.itemId == pItem.itemId)
    //            {
    //                itemToBeRemoved = item;
    //            }
    //        }
    //        if (itemToBeRemoved != null)
    //        {
    //            inactiveArtifacts.Remove(itemToBeRemoved);
    //        }
    //    }
    //    CheckItemSeries();
    //    CountArtifactItems();
    //    if (isPlayerInventory)
    //    {
    //        UpdateInventoryUI();
    //    }
    //}
    //public void RemoveItem(Item pItem,bool updateUI)
    //{
    //    Item itemToBeRemoved = null;
    //    foreach (Item item in items)
    //    {
    //        if (item.itemId == pItem.itemId)
    //        {
    //            itemToBeRemoved = item;
    //        }
    //    }
    //    if (itemToBeRemoved != null)
    //    {
    //        itemToBeRemoved.RemoveEffect(gameObject);
    //        items.Remove(itemToBeRemoved);
    //    }
    //    else
    //    {
    //        foreach (Item item in inactiveArtifacts)
    //        {
    //            if (item.itemId == pItem.itemId)
    //            {
    //                itemToBeRemoved = item;
    //            }
    //        }
    //        if (itemToBeRemoved != null)
    //        {
    //            inactiveArtifacts.Remove(itemToBeRemoved);
    //        }
    //    }
    //    CheckItemSeries();
    //    CountArtifactItems();
    //    if (isPlayerInventory && updateUI)
    //    {
    //        UpdateInventoryUI();
    //    }
    //}

    //public void UpdateInventoryUI()
    //{
    //    if(isPlayerInventory)
    //    {
    //        UI_ArtifactManager.ClearInventoryDisplays();
    //        UI_ArtifactManager.FillInventoryDisplays();
    //        UI_InventoryManager.ClearInventoryDisplays();
    //        UI_InventoryManager.FillInventoryDisplays();
    //        UI_ItemSeriesManager.ClearItemSeriesDisplays();
    //        UI_ItemSeriesManager.FillItemSeriesDisplays();
    //    }
    //}
}
