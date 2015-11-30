using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CanvasDamagePopUp : MonoBehaviour {

     public GameObject damagePopUpLocation;
    public float xRandomRange = 1;


    public void SpawnDamagePopUp(int damage)
    {
        GameObject temp;
        temp = Instantiate(damagePopUpLocation, new Vector3(transform.position.x + Random.value * (xRandomRange) - xRandomRange,transform.position.y,transform.position.z), this.transform.rotation) as GameObject;
        temp.GetComponent<CanvasObjectFollowGameObject>().AddText(damage);
        if (damage > 0)
        {
            temp.GetComponent<CanvasObjectFollowGameObject>().text.GetComponent<Text>().color = Color.red;
        }
        else
        {
            temp.GetComponent<CanvasObjectFollowGameObject>().text.GetComponent<Text>().color = Color.green;
        }
    }
}
