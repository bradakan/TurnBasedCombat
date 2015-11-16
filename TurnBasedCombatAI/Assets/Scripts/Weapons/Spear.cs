using UnityEngine;
using System.Collections;

public class Spear : BaseWeapon
{

    // Use this for initialization
    void Start()
    {
        damageType = DamageTypes.DamageType.piercing;
        damage = 10;
        accuracy = 100f;
    }

}
