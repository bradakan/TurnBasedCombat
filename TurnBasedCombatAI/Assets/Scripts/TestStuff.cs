using UnityEngine;
using System.Collections;

public class TestStuff : BaseWeapon {

	// Use this for initialization
	void Start ()
    {
        damageType = DamageTypes.DamageType.slashing;
        damage = 10;
	}

    void Test()
    {
        Debug.Log("test");
    }
}
