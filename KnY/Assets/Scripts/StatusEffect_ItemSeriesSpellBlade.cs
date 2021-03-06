﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusEffect_ItemSeriesSpellBlade : StatusEffect {
    public int spGain = 8;
    public StatusEffect_ItemSeriesSpellBlade()
    {
        this.statusName = new ItemSeries_SpellBlade().seriesName;
        this.description = new ItemSeries_SpellBlade().description[0];
        this.image = new Item_EvilStaff().image;
        this.type = Type.Series;
        this.duration = 36000;
    }

    public override void ApplyEffect(GameObject g)
    {
        if(!effectApplied)
        {
            effectApplied = true;
        }
    }

    public override void RemoveEffect(GameObject g)
    {
        if (effectApplied)
        {
        }
    }

    public override void OnAdditionalApplication(GameObject g, StatusEffect s)
    {

    }
}
