using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : ItemCard
{
    protected override void Start()
    {
        ItemName = "asd";
        Description = "·Î³ª·Î³ª¶¥¶¥";
        ButtonText = "1,000";

        base.Start();
    }
    protected override void Action()
    {
    }
}
