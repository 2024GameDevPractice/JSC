using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnDamage : Item
{
    protected override void SetBuff()
    {
        Manager.Instance.player.transform.GetChild(0).gameObject.SetActive(true);
        Manager.Instance.player.GetComponentInChildren<Guard>().AddTime();
    }
}
