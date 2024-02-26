using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuel : Item
{
    protected override void SetBuff()
    {
        Manager.Instance.player.GetComponent<PlayerController>().state.fuel.fillAmount += 0.25f;
    }
}
