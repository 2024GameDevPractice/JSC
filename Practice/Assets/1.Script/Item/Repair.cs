using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repair : Item
{
    protected override void SetBuff()
    {
        if(Manager.Instance.player.GetComponent<PlayerController>().HP == 4)
        {
            //���� ȹ��
        }
        else
        {
            Manager.Instance.player.GetComponent<PlayerController>().HP++; 
        }
    }
}
