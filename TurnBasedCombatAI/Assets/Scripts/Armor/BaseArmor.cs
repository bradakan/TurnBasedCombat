using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BaseArmor : MonoBehaviour
{
	public List<DamageTypes.DamageType> resist = new List<DamageTypes.DamageType>();
    public List<DamageTypes.DamageType> vunerable = new List<DamageTypes.DamageType>();
}
