﻿
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Blight : ProcItem {

    public int durration = 5;
    public int damage = 5;
    public double damagePerStack = 2.5f;
    public double durrationPerStack = 0.25f;
    public float procChancePerStack = 2.5f;
    public float baseProcChance = 25f;
    public Item_Blight()
    {
        this.itemId = 5;
        this.itemName = "Blight";
        this.attribute = "Dark";
        this.description = "Chance to inflict Blight onhit.";
        this.detailedDescription = string.Format("Inflicts Blight on hit : {0}% + {1}% chanche to hit per stack, 5 + {2} duration per stack, 5 + {3} damage per stack", procChance, procChancePerStack, durrationPerStack, damagePerStack);
        this.procChance = baseProcChance;
        this.image = GameObject.FindObjectOfType<ItemIcons>().icons[itemId];
        this.series.Add(ItemSeries.Series.Curse);
    }


    public override void ApplyEffect(GameObject g)
    {

    }

    public override void ProcEffect(GameObject g)
    {
        int durration = this.durration + (int)(durrationPerStack * g.GetComponent<Statusmanager>().level);
        int flatDamage =(int)((damage + (damagePerStack * g.GetComponent<Statusmanager>().level)) * owner.GetComponent<Statusmanager>().damageOverTimeDamageMultiplier);
        g.GetComponent<Statusmanager>().ApplyStatusEffect(new StatusEffect_Blighted(durration, flatDamage));
    }

    public override void AddAditionalStack(GameObject g, Item otherItem)
    {

    }
}
