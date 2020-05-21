﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_TitansKidney : Item {

    public float healthRegenerationBonus = 5f;

    public Item_TitansKidney()
    {
        this.itemId = 4;
        this.itemName = "Titans Kidney";
        this.description = "Increases health regeneration.";
    }


    public override void ApplyEffect(GameObject g)
    {
        g.GetComponent<Statusmanager>().healthRegeneration += healthRegenerationBonus * stacks;
    }

    public override void RemoveEffect(GameObject g)
    {
        g.GetComponent<Statusmanager>().healthRegeneration -= healthRegenerationBonus * stacks;
    }
}