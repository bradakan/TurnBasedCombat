using UnityEngine;
using System.Collections;

public class PlayerBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Attack()
    {
        Debug.Log("Attack");
    }

    public void Spell(int slot = 1)
    {
        Debug.Log("Spell" + slot);
    }
}
