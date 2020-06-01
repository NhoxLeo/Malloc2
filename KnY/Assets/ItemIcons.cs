﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemIcons : MonoBehaviour
{
    public List<Sprite> icons = new List<Sprite>();
    private static ItemIcons instance;
    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Sprite GetIcon(int id)
    {
        return icons[id];
    }
    public static Sprite GetIconFromInstance(int id)
    {
        return instance.icons[id];
    }
}
