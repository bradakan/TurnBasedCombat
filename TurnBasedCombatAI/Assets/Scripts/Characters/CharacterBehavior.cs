using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterBehavior : MonoBehaviour
{

    //TODO convert this to character behavior
    private const string _playerTag = "Player";
    private const string _EnemyTag = "Enemy";
    private const string _animTag = "Animation";
    private const string _turnHandler = "TurnHandler";
    private const string _attackAnimString = "Attack";
    private int hp = 100;
    Animator anim;
    public BaseWeapon weapon;
    public List<DamageTypes.DamageType> resist;
    public List<DamageTypes.DamageType> vunerable;
    public CanvasObjectFollowGameObject hpIndicator;
    public int maxHp;
    TurnHandler turnhandler;

    // Use this for initialization
    void Start()
    {
        foreach (Transform child in transform)
        {
            if (child.tag == _animTag)
            {
                anim = child.GetComponent<Animator>();
                break;
            }
        }
        hp = maxHp;
        hpIndicator = GetComponentInChildren<CanvasObjectFollowGameObject>();
        weapon = GetComponent<BaseWeapon>();
        BaseArmor tempArmorVar = GetComponent<BaseArmor>();
        resist = tempArmorVar.resist;
        vunerable = tempArmorVar.vunerable;
        hpIndicator.ChangeText(hp);
        turnhandler = GameObject.FindGameObjectWithTag(_turnHandler).GetComponent<TurnHandler>();
    }

    public void Attack()
    {
        //TODO move to point
        anim.SetTrigger(_attackAnimString);
        turnhandler.SwitchTurn();
        
    }

    //TODO function om terug naar start te moven
    public void MoveBackToStartPos()
    {

    }

    public void DealDamage()
    {
        if (tag == _playerTag)
        {
            GameObject.FindGameObjectWithTag(_EnemyTag).GetComponent<CharacterBehavior>().TakeDamage(weapon);
        }
        else
        {
            GameObject.FindGameObjectWithTag(_playerTag).GetComponent<CharacterBehavior>().TakeDamage(weapon);
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
        ChangeHealth((int)damage);
        if (GetComponent<CanvasDamagePopUp>())
        {
            GetComponent<CanvasDamagePopUp>().SpawnDamagePopUp((int)damage);
        }
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
