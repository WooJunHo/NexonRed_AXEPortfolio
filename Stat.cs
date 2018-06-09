using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stat : MonoBehaviour
{
    protected int m_nLevel = 1;
    protected int m_nMaxLevel = 25;
    protected int m_nExp = 0;
    protected int m_nStar = 1;
    protected int m_nMaxHp = 0;
    protected int m_nHp = 0;
    protected int m_nStr = 20;
    protected int m_nShield = 5;
    protected int m_nHitSpeed = 0;
    protected int m_nCriticality = 15;
    protected int m_nCDamage = 50;
    protected int m_nEffectResist = 17;
    protected int m_nEffectHit = 0;
    protected int m_nSkillpointe = 20;
    public enum EStat
    {
        LEVEL, M_LEVEL, EXP, STAR,
        M_HP, HP, M_MP, MP, STR, SHIELD,
        HITSPEED, CRITICALITY, CDMAGE,
        EFFECTRESIST, EFFECTHIT,SKILLPOINTE
    }
    public enum ESkill
    {
        SKILL_1, SKILL_2
    }
   
    
}
