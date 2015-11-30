using UnityEngine;
using System.Collections;

public class SendDamageFromAnimation : MonoBehaviour {

    CharacterBehavior parent;

    void Start()
    {
        parent = GetComponentInParent<CharacterBehavior>();
    }

    public void SendDamage()
    {
        parent.DealDamage();
    }
}
