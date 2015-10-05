using UnityEngine;
using System.Collections;

public class TestStuff : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        BaseWeapon temp = GetComponent<BaseWeapon>();
        temp._damageType = BaseWeapon.DamageTypes.slashing;
        Debug.Log(temp._damageType);
	}
}
