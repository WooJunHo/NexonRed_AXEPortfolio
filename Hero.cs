using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : Stat
{
    User m_cUser;
    List<ItemManager.EItem> Equipmentlist = new List<ItemManager.EItem>();
    // Use this for initialization
    void Start () {
        m_cUser = GetComponent<User>();
    }
	
	// Update is called once per frame
	void Update () {
        
	}
    public int GetStat(EStat eStat)
    {
        switch (eStat)
        {
            case EStat.EXP:
                return m_nExp;
            case EStat.M_HP:
                return m_nMaxHp;
            case EStat.HP:
                return m_nHp;
            case EStat.STR:
                return m_nStr;
            case EStat.SHIELD:
                return m_nShield;
            case EStat.HITSPEED:
                return m_nHitSpeed;
            case EStat.CRITICALITY:
                return m_nCriticality;
            case EStat.CDMAGE:
                return m_nCDamage;
            case EStat.EFFECTRESIST:
                return m_nEffectResist;
            case EStat.EFFECTHIT:
                return m_nEffectHit;
            case EStat.LEVEL:
                return m_nLevel;
            case EStat.M_LEVEL:
                return m_nMaxLevel;
            case EStat.STAR:
                return m_nStar;

        }
        return 0;
    }
    public void SetStat(EStat eStat, int stat)
    {
        switch (eStat)
        {
            case EStat.EXP:
                m_nExp += stat; break;
            case EStat.M_HP:
                m_nHp += stat; break;
            case EStat.STR:
                m_nStr += stat; break;
            case EStat.SHIELD:
                m_nShield += stat; break;
            case EStat.HITSPEED:
                m_nHitSpeed += stat; break;
            case EStat.CRITICALITY:
                m_nCriticality += stat; break;
            case EStat.CDMAGE:
                m_nCDamage += stat; break;
            case EStat.EFFECTRESIST:
                m_nEffectResist += stat; break;
            case EStat.EFFECTHIT:
                m_nEffectHit += stat; break;
            case EStat.LEVEL:
                m_nLevel += stat; break;
            case EStat.M_LEVEL:
                m_nMaxLevel = 10; break;
            case EStat.STAR:
                m_nStar = 1; break;
            case EStat.SKILLPOINTE:
                m_nSkillpointe = stat;break;
            case EStat.HP:
                m_nHp += stat;break;
        }

    }
    
    void Demage(int dem)
    {
        m_nHp = m_nHp - (dem - m_nShield);
    }
    void Demage(ESkill eSkill)
    {
        switch (eSkill)
        {
            case ESkill.SKILL_1:
                m_nHp = m_nHp - (m_nSkillpointe - m_nShield); break;
            case ESkill.SKILL_2:
                m_nHp = m_nHp - (m_nSkillpointe - m_nShield); break;
        }
    }
   
    public void Recovery()
    {
        m_nHp = m_nMaxHp;
    }
    public void LvUp()
    {
        if (m_nExp == 100)
        {
            SetStat(EStat.LEVEL, 1);
        }
        else
            return;
    }
    public bool Dead()
    {
        if (m_nHp <= 0)
        {
            m_nHp = 0;
            return true;
        }
        else
            return false; 
    }
    public bool MonsterDead()
    {
        if (m_nHp <= 0)
        {
            m_nHp = 0;
            return true;
        }
        else
            return false;
    }
    public void Attack(Hero cMon)
    {
        cMon.Demage(m_nStr);
    }
    public void Skill(Hero cMon,ESkill eSkill)
    {
        cMon.Demage(eSkill);
    }
    
  

    int EquipmentCal(ItemManager.EItem eItem)
    {
        int result = 0;
        switch(eItem)
        {
            case ItemManager.EItem.VITALITY:
                result=(m_nMaxHp / 100)*15;
                break;
            case ItemManager.EItem.ONSLAUGHT:
                result = (m_nStr / 100) * 30;
                break;
            case ItemManager.EItem.PATRONAGE:
                result = (m_nShield / 100) * 15;
                break;
        }
        return result;
    }
  public  void SetEquipment(ItemManager.EItem eItem)
    {
        switch(eItem)
        {
            case ItemManager.EItem.VITALITY:
                SetStat(EStat.M_HP, EquipmentCal(ItemManager.EItem.VITALITY));
                break;
            case ItemManager.EItem.ONSLAUGHT:
                SetStat(EStat.STR, EquipmentCal(ItemManager.EItem.ONSLAUGHT));
                break;
            case ItemManager.EItem.PATRONAGE:
                SetStat(EStat.SHIELD, EquipmentCal(ItemManager.EItem.PATRONAGE)); 
                break;
        }
    }
}
