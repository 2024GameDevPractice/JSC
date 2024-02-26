using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : Item
{
    protected override void SetBuff()
    {
        if (Manager.Instance.player.GetComponent<PlayerController>().level == 4)
        {
            Manager.Instance.score += 200;
            return;
        }
        Manager.Instance.player.GetComponent<PlayerController>().level++;
    }
}
