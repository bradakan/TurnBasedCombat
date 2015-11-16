using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterBehavior : MonoBehaviour
{

    //TODO convert this to character behavior
    private int hp = 100;
    public BaseWeapon weapon;
    public List<DamageTypes.DamageType> resist;
    public List<DamageTypes.DamageType> vunerable;
    public CanvasObjectFollowGameObject hpIndicator;

    // Use this for initialization
    void Start()
    {
        hpIndicator = GetComponentInChildren<CanvasObjectFollowGameObject>();
        weapon = GetComponent<BaseWeapon>();
        BaseArmor tempArmorVar = GetComponent<BaseArmor>();
        resist = tempArmorVar.resist;
        vunerable = tempArmorVar.vunerable;
    }

    public void Attack()
    {
        if (tag == "Player")
        {
            GameObject.FindGameObjectWithTag("Enemy").GetComponent<CharacterBehavior>().TakeDamage(weapon);
            Debug.Log("attack enemy");
        }
        else
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterBehavior>().TakeDamage(weapon);
            Debug.Log("attack Player");
        }
    }
    /*
    //TODO something for later when the basics are polished
    public void Spell(int slot = 1)
    {
        Debug.Log("Spell" + slot);
    }
    */
    public void TakeDamage(BaseWeapon damageSource)
    {
        if (GetComponent<CanvasDamagePopUp>())
        {
            GetComponent<CanvasDamagePopUp>().SpawnDamagePopUp(damageSource);
        }
        float damage = 0;
        if (resist.Contains(damageSource.damageType))
        {
            damage = damageSource.damage * 0.5f;
            damage = Mathf.RoundToInt(damage);
        }
        else if (vunerable.Contains(damageSource.damageType))
        {
            damage = damageSource.damage * 2f;
        }
        else
        {
            damage = damageSource.damage;
        }
        Debug.Log(damage);
        ChangeHealth((int)damage);
    }

    public void ChangeHealth(int value)
    {
        if (value > 0)
        {
            hp -= value;
        }
        else if (value < 0)
        {
            hp -= value;
            if (hp > 100)
            {
                hp = 100;
            }
        }
        hpIndicator.ChangeText(hp);
    }
}
