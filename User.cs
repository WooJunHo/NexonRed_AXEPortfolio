using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User : MonoBehaviour {
   static public List<ItemManager.EItem> m_listInvetory = new List<ItemManager.EItem>();
    // Use this for initialization
    static public UI m_cUI;
    static public int VITALITY_Cnt = 0;
    static public int ONSLAUGHT_Cnt = 0;
    static public int PATRONAGE_Cnt = 0;
    void Start () {
        m_cUI = new UI();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void SetInventory(ItemManager.EItem eItem)
    {
        switch(eItem)
        {
            case ItemManager.EItem.VITALITY:
                m_listInvetory.Add(ItemManager.EItem.VITALITY);
                VITALITY_Cnt += 1;
                m_cUI.SetRune_Item_img(Button.Rune.RUNE1, 1);
                break;
            case ItemManager.EItem.ONSLAUGHT:
                m_listInvetory.Add(ItemManager.EItem.ONSLAUGHT);
                ONSLAUGHT_Cnt += 1;
                m_cUI.SetRune_Item_img(Button.Rune.RUNE2, ONSLAUGHT_Cnt);
                break;
            case ItemManager.EItem.PATRONAGE:
                m_listInvetory.Add(ItemManager.EItem.PATRONAGE);
                PATRONAGE_Cnt += 1;
                m_cUI.SetRune_Item_img(Button.Rune.RUNE3, PATRONAGE_Cnt);
                break;
        }
    }
    static public void Event(ItemManager.EItem eitem,Hero hero)
    {
        int hero_m_Hp = hero.GetStat(Stat.EStat.M_HP);
        int hero_m_Str = hero.GetStat(Stat.EStat.STR);
        int hero_m_Shield = hero.GetStat(Stat.EStat.SHIELD);
        switch(eitem)
        {
            case ItemManager.EItem.VITALITY: hero.SetStat(Stat.EStat.M_HP,hero_m_Hp+hero_m_Hp/100*15);break;
            case ItemManager.EItem.ONSLAUGHT:hero.SetStat(Stat.EStat.STR, hero_m_Str + hero_m_Str / 100 * 30);break;
            case ItemManager.EItem.PATRONAGE:hero.SetStat(Stat.EStat.SHIELD, hero_m_Shield + hero_m_Shield / 100 * 15);break;
        }
    }
   static public void DeleteInventory(ItemManager.EItem eItem)
    {
        m_listInvetory.Remove(eItem);
    }
    public ItemManager.EItem GetInventory(ItemManager.EItem eItem)
    {
      return  eItem;
    }
}
 