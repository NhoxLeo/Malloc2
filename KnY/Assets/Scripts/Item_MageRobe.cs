﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_MageRobe : Item {

    public int intelectGain = 15;
    public int pietyGain = 15;
    public Item_MageRobe()
    {
        this.itemId = 39;
        this.attribute = "Water";
        this.itemName = "Mage Robe";
        this.description = "Increases Int and Pie";
        this.detailedDescription = string.Format("Increases intellect by {0} per stack and piety by {1} per stack", intelectGain, pietyGain);
        this.series.Add(ItemSeries.Series.Magus);
        this.series.Add(ItemSeries.Series.Spellblade);
        this.image = GameObject.FindObjectOfType<ItemIcons>().icons[itemId];
    }

    public override void ApplyEffect(GameObject g)
    {
        g.GetComponent<Statusmanager>().Intellect += intelectGain * g.GetComponent<Statusmanager>().level;
        g.GetComponent<Statusmanager>().Intellect += pietyGain * g.GetComponent<Statusmanager>().level;
    }

    public override void RemoveEffect(GameObject g)
    {
        g.GetComponent<Statusmanager>().Intellect -= intelectGain * g.GetComponent<Statusmanager>().level;
        g.GetComponent<Statusmanager>().Intellect -= pietyGain * g.GetComponent<Statusmanager>().level;
    }

}
