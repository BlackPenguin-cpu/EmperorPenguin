using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : ItemCard
{
    protected override void Start()
    {
        itemName = "asd";
        description = "�γ��γ�����";
        buttonTextString = "1,000";

        base.Start();
    }
    protected override void Action()
    {
    }
}
