using UnityEngine;
using System.Collections;

public class Sword : BaseWeapon {

    // Use this for initialization
    void Start()
    {
        damageType = DamageTypes.DamageType.slashing;
        damage = 5;
        accuracy = 150f;
    }
}
