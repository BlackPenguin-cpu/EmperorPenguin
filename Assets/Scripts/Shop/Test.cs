using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : ItemCard
{
    protected override void Start()
    {
        itemName = "asd";
        description = "·Î³ª·Î³ª¶¥¶¥";
        buttonTextString = "1,000";

        base.Start();
    }
    protected override void Action()
    {
    }
}
