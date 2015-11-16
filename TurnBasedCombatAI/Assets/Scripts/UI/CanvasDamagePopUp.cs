using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CanvasDamagePopUp : MonoBehaviour {

     public GameObject damagePopUpLocation;


    public void SpawnDamagePopUp(BaseWeapon weapon)
    {
        GameObject temp;
        temp = Instantiate(damagePopUpLocation, transform.position, this.transform.rotation) as GameObject;
        temp.GetComponent<CanvasObjectFollowGameObject>().AddText(-weapon.damage);
    }
}
