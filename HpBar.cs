using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour {
    public Image H1Bar;
    public Image H2Bar;
    public Image H3Bar;
    public Image M1Bar;
    public Image M2Bar;
    public Image M3Bar;
   static public List<Image> HeroHP_list = new List<Image>();
    static public List<Image> MonsterHP_List = new List<Image>();
    static public List<RectTransform> HrecTr = new List<RectTransform>();
    static public List<RectTransform> MrecTr = new List<RectTransform>();
    float m_fMax;
    public enum H_Hero { H1,H2,H3}
    public enum H_Monster { M1,M2,M3}
    // Use this for initialization
    void Start () {
        HeroHP_list.Add(H1Bar);
        HeroHP_list.Add(H2Bar);
        HeroHP_list.Add(H3Bar);
        MonsterHP_List.Add(M1Bar);
        MonsterHP_List.Add(M2Bar);
        MonsterHP_List.Add(M3Bar);
        
        for(int i=0;i<3;i++)
        {
            HrecTr.Add(HeroHP_list[i].GetComponent<RectTransform>());
            HrecTr.Add(HeroHP_list[i].GetComponent<RectTransform>());
            
        }
        m_fMax = HrecTr[0].sizeDelta.x;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Set(float cur, float max,H_Hero mon)
    {
        float fVal = cur / max;
        float fStatusBar = m_fMax * fVal;
        switch(mon)
        {
            case H_Hero.H1:
                HeroHP_list[(int)mon].fillAmount = cur / max;
                break;
            case H_Hero.H2:
                HeroHP_list[(int)mon].fillAmount = cur / max;
                break;
            case H_Hero.H3:
                HeroHP_list[(int)mon].fillAmount = cur / max;
                break;
        }
    }
    public void Set(float cur, float max, H_Monster mon)
    {
        float fVal = cur / max;
        float fStatusBar = m_fMax * fVal;
        switch (mon)
        {
            case H_Monster.M1:
                MonsterHP_List[(int)mon].fillAmount = cur / max;
                break;
            case H_Monster.M2:
                MonsterHP_List[(int)mon].fillAmount = cur / max;
                break;
            case H_Monster.M3:
                MonsterHP_List[(int)mon].fillAmount = cur / max;
                break;
        }
    }
}
