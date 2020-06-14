﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_EvilStaff : Item {

    public int magicPowerGain = 50;
    public Item_EvilStaff()
    {
        this.itemId = 37;
        this.attribute = "Dark";
        this.itemName = "Evil Staff";
        this.description = "Increases Magic Power";
        this.detailedDescription = "Increases Magic Power by " + magicPowerGain + " per stack";
        this.series.Add(ItemSeries.Series.Curse);
        this.series.Add(ItemSeries.Series.Spellblade);
        this.image = GameObject.FindObjectOfType<ItemIcons>().icons[itemId];
    }

    public override void ApplyEffect(GameObject g)
    {
        g.GetComponent<Statusmanager>().MagicPower += magicPowerGain * stacks;
    }

    public override void RemoveEffect(GameObject g)
    {
        g.GetComponent<Statusmanager>().MagicPower -= magicPowerGain * stacks;
    }

}