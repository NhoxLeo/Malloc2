﻿
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Affliction : ProcItem {

    public int durration = 4;
    public int damage = 2;
    public double damagePerStack = 2.5f;
    public double durrationPerStack = 0.25f;
    public float procChancePerStack = 5f;
    public float baseProcChance = 25f;
    public Item_Affliction()
    {
        this.itemId = 20;
        this.itemName = "Affliction";
        this.attribute = "Dark";
        this.description = "Chance to inflict Affliction onhit.";
        this.procChance = baseProcChance;
        this.series.Add(ItemSeries.Series.Curse);
        this.image = GameObject.FindObjectOfType<ItemIcons>().icons[itemId];
    }


    public override void ApplyEffect(GameObject g)
    {

    }

    public override void ProcEffect(GameObject g)
    {
        int durration = this.durration + (int)(durrationPerStack * g.GetComponent<Statusmanager>().level);
        int flatDamage =(int)((damage + (damagePerStack * g.GetComponent<Statusmanager>().level) + (owner.GetComponent<Statusmanager>().TotalAttackDamage * 0.1f)) * owner.GetComponent<Statusmanager>().damageOverTimeDamageMultiplier);
        g.GetComponent<Statusmanager>().ApplyStatusEffect(new StatusEffect_Afflicted(durration, flatDamage));
    }

    public override void AddAditionalStack(GameObject g, Item otherItem)
    {

    }
}
