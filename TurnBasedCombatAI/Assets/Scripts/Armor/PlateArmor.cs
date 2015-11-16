using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlateArmor : BaseArmor {

	// Use this for initialization
	void Start ()
    {
        vunerable.Add(DamageTypes.DamageType.bludgeoning);
        resist.Add(DamageTypes.DamageType.piercing);
        resist.Add(DamageTypes.DamageType.slashing);
    }
}
