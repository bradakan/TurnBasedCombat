using UnityEngine;
using System.Collections;

public class BaseWeapon : MonoBehaviour {

    public enum DamageTypes { piercing, slashing, bludgeoning }
    public DamageTypes _damageType { get; set; }

}
