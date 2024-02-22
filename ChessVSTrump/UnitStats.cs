using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum EffectType
{
    ContactAttack,
    RangedAttack,
    Defense,
    Heal,
    Mine
}


[CreateAssetMenu (fileName = "UnitStats", menuName = "UnitStats/BaseStats")]
public class UnitStats : ScriptableObject
{
    [Header("Base")]
    public int maxHealth;
    public float speed;
    public int level = 1;

    [Header("Effect")]
    public EffectType type;
    public int effectPower; //효과 ex. 공격력, 힐, 마이닝 등) 수치
    public float effectRate; // 효과 주기

}
