using UnityEngine;
using System.Collections;

public class Mace : BaseWeapon {

    // Use this for initialization
    void Start()
    {
        damageType = DamageTypes.DamageType.bludgeoning;
        damage = 15;
        accuracy = 75f;
    }
}
