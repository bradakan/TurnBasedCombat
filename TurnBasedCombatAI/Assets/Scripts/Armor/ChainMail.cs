using UnityEngine;
using System.Collections;

public class ChainMail : BaseArmor {

    // Use this for initialization
    void Start()
    {
        vunerable.Add(DamageTypes.DamageType.piercing);
        resist.Add(DamageTypes.DamageType.slashing);
    }
}
