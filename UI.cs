using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI : MonoBehaviour {
   static public List<GameObject> UIlist = new List<GameObject>();
    static public List<Image> LoonImg = new List<Image>();
    public GameObject main;
    public GameObject user;
    public GameObject dun;
    public GameObject dunenter;
    public GameObject ChooseStage;
    public GameObject Drop_info;
    public GameObject Garen_Edge;
    public GameObject MonsterUI;
    public GameObject Star1;
    public GameObject Star2;
    public GameObject Star3;
    public GameObject Info_UI;
    public GameObject Skill_UI;
    public GameObject Loon_UI;
    public GameObject Info_UI_bt;
    public GameObject Skill_UI_bt;
    public GameObject Loon_UI_bt;
    public GameObject UNClick_Info_bt;
    public GameObject UNClick_Skill_bt;
    public GameObject UNClick_Loon_bt;
    public GameObject Rune1_case;
    public GameObject Rune2_case;
    public GameObject Rune3_case;
    public GameObject Quest;
    public GameObject Quest_Info;
    public GameObject Rune1_1;
    public GameObject Rune1_2;
    public GameObject Rune1_3;
    public GameObject Rune1_4;
    public GameObject Rune2_1;
    public GameObject Rune2_2;
    public GameObject Rune2_3;
    public GameObject Rune2_4;
    public GameObject Rune3_1;
    public GameObject Rune3_2;
    public GameObject Rune3_3;
    public GameObject Rune3_4;
    public GameObject Rune1Mount;
    public GameObject Rune2Mount;
    public GameObject Rune3Mount;
    public GameObject R1;
    public GameObject R2;
    public GameObject R3;
    public List<Text> Monster_Info = new List<Text>();
    public Image Num1Loon;
    public Image Num2Loon;
    public Image Num3Loon;
    public Image Num4Loon;
    public Image Num5Loon;
    public Image Num6Loon;
    public Text Dungeon_Energy;
    public Text Town_Energy;
    static public List<GameObject> Rune1_item_bt = new List<GameObject>();
    static public List<GameObject> Rune2_item_bt = new List<GameObject>();
    static public List<GameObject> Rune3_item_bt = new List<GameObject>();
    public Text QuestCount;
    static Sprite R1_s;
    static Sprite R2_s;
    static Sprite R3_s;
    //public Text Town_Mana;
    //public Text Shop_Mana;
    public Text MonsterCount;
    static public GameManager gameManager;
    Dungeon Dungeon_UI;
    Hero hero;
    public enum UIs { Main_bt,User_info,Dungeon_UI,Monster_UI,ChooseStage,Drop_info,GE,Dungeon_Enter, Info_UI , Skill_UI ,
        Loon_UI,UNClick_Info_bt, UNClick_Skill_bt, UNClick_Loon_bt,Info_UI_bt, Skill_UI_bt, Loon_UI_bt,
        Rune1_case, Rune2_case, Rune3_case,Quest,Quest_Info,LM_1,LM_2,LM_3,R1,R2,R3
    }
    public enum ELoonImg
    {
        NUM1_LOON,NUM2_LOON, NUM3_LOON, NUM4_LOON, NUM5_LOON, NUM6_LOON
    }
    public enum E_Monster_Info { Level,Hp,Str,Shield,AttackSpeed}
    static public UIs Euis;
    // Use this for initialization
    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        Dungeon_UI = new Dungeon();
        hero = GameObject.Find("Hero").GetComponent<Hero>();
    }
    void Start () {
        Init();
	}
	
	// Update is called once per frame
	void Update () {
        Dungeon_Energy.text = GameManager.m_nEnergy.ToString() + " / " + gameManager.m_nMaxEnergy;
        Town_Energy.text = GameManager.m_nEnergy.ToString() + " / " + gameManager.m_nMaxEnergy;
        //gameManager.TownMana += 2;
        //Shop_Mana.text = gameManager.TownMana.ToString();
        //Town_Mana.text = gameManager.TownMana.ToString();
        Debug.Log(Monster_Info[0].name);
        QuestCount.text=gameManager.m_nStageClearCnt.ToString()+"/"+3.ToString();
        Monster_Info[(int)E_Monster_Info.Level].text = hero.GetStat(Stat.EStat.LEVEL).ToString();
        Monster_Info[(int)E_Monster_Info.Hp].text = hero.GetStat(Stat.EStat.M_HP).ToString();
        Monster_Info[(int)E_Monster_Info.Str].text = hero.GetStat(Stat.EStat.STR).ToString();
        Monster_Info[(int)E_Monster_Info.Shield].text = hero.GetStat(Stat.EStat.SHIELD).ToString();
        Monster_Info[(int)E_Monster_Info.AttackSpeed].text = hero.GetStat(Stat.EStat.HITSPEED).ToString();
    }
    
    public void UIlistAdd()
    {
        UIlist.Add(main);
        UIlist.Add(user);
        UIlist.Add(dun);
        UIlist.Add(MonsterUI);
        UIlist.Add(ChooseStage);
        UIlist.Add(Drop_info);
        UIlist.Add(Garen_Edge);
        UIlist.Add(dunenter);
        UIlist.Add(Info_UI);
        UIlist.Add(Skill_UI);
        UIlist.Add(Loon_UI);
        UIlist.Add(UNClick_Info_bt);
        UIlist.Add(UNClick_Skill_bt);
        UIlist.Add(UNClick_Loon_bt);
        UIlist.Add(Info_UI_bt);
        UIlist.Add(Skill_UI_bt);
        UIlist.Add(Loon_UI_bt);
        UIlist.Add(Rune1_case);
        UIlist.Add(Rune2_case);
        UIlist.Add(Rune3_case);
        UIlist.Add(Quest);
        UIlist.Add(Quest_Info);
        UIlist.Add(Rune1Mount);
        UIlist.Add(Rune2Mount);
        UIlist.Add(Rune3Mount);
        UIlist.Add(R1);
        UIlist.Add(R2);
        UIlist.Add(R3);
        Debug.Log("AddSuc");
    }
    void ItemBtAdd()
    {
        Rune1_item_bt.Add(Rune1_1);
        Rune1_item_bt.Add(Rune1_2);
        Rune1_item_bt.Add(Rune1_3);
        Rune1_item_bt.Add(Rune1_4);
        Rune2_item_bt.Add(Rune2_1);
        Rune2_item_bt.Add(Rune2_2);
        Rune2_item_bt.Add(Rune2_3);
        Rune2_item_bt.Add(Rune2_4);
        Rune3_item_bt.Add(Rune3_1);
        Rune3_item_bt.Add(Rune3_2);
        Rune3_item_bt.Add(Rune3_3);
        Rune3_item_bt.Add(Rune3_4);

    }
    public void Init()
    {
        UIlistAdd();
        ItemBtAdd();
        LoonImg.Add(Num1Loon);
        LoonImg.Add(Num2Loon);
        LoonImg.Add(Num3Loon);
        LoonImg.Add(Num4Loon);
        LoonImg.Add(Num5Loon);
        LoonImg.Add(Num6Loon);
        R1_s = LoonImg[0].sprite;
        R2_s = LoonImg[5].sprite;
        R3_s = LoonImg[1].sprite;
        SelecteUIs(UIs.Main_bt);
        //Dungeon_Energy.text = GameManager.m_nEnergy.ToString() + " / " + gameManager.m_nMaxEnergy;
        //Town_Energy.text = GameManager.m_nEnergy.ToString() + " / " + gameManager.m_nMaxEnergy;
        Debug.Log("suc2");
    
    }
    public void SetRune(ItemManager.EItem eItem)
    {
        hero = GameObject.Find("Hero").GetComponent<Hero>();
        hero.SetEquipment(eItem);
    }
    static public void SetRuneImg(Button.Rune rune)
    {
        switch(rune)
        {
            case Button.Rune.RUNE1:
                Sprite rune1 = Resources.Load<Sprite>("Tex/rune1");
                LoonImg[0].sprite = rune1;
                break;
            case Button.Rune.RUNE2:
                Sprite rune2 = Resources.Load<Sprite>("Tex/rune3");
                LoonImg[5].sprite = rune2;
                break;
            case Button.Rune.RUNE3:
                Sprite rune3 = Resources.Load<Sprite>("Tex/rune2");
                LoonImg[1].sprite = rune3;
                break;
        }
    }
    static public void RuneImgReset(Button.Rune rune)
    {
        switch (rune)
        {
            case Button.Rune.RUNE1:
                LoonImg[0].sprite = R1_s;
                break;
            case Button.Rune.RUNE2:
                LoonImg[5].sprite = R2_s;
                break;
            case Button.Rune.RUNE3:
                LoonImg[1].sprite = R3_s;
                break;
        }
    }

    public void SetRune_Item_img(Button.Rune rune,int cnt)
    {
        switch(rune)
        {
            case Button.Rune.RUNE1:
                for (int i = 0; i < User.m_listInvetory.Count; i++)
                {
                    Rune1_item_bt[i].GetComponent<Image>().enabled = true;
                    Rune1_item_bt[i].GetComponent<Button>().enabled = true;
                }
                break;
            case Button.Rune.RUNE2:
                for (int i = 0; i < User.m_listInvetory.Count; i++)
                {
                    Rune2_item_bt[0].GetComponent<Image>().enabled = true;
                    Rune2_item_bt[0].GetComponent<Button>().enabled = true;
                }
                break;
            case Button.Rune.RUNE3:
                for (int i = 0; i < User.m_listInvetory.Count; i++)
                {
                    Rune3_item_bt[0].GetComponent<Image>().enabled = true;
                    Rune3_item_bt[0].GetComponent<Button>().enabled = true;
                }
                break;
        }
    }
   static public void MonsterUI_btReset()
    {
        for(int i=14;i<17;i++)
        {
            UIlist[i].SetActive(false);
        }
        for(int i=8;i<11;i++)
        {
            UIlist[i].SetActive(false);
        }
    }
    static public void MonsterUI_BT(UIs uis)
    {
        switch(uis)
        {
            case UIs.Info_UI_bt:
                MonsterUI_btReset();
                UIlist[16].SetActive(false);
                UIlist[(int)UIs.Info_UI_bt].SetActive(true);
                UIlist[(int)UIs.Info_UI].SetActive(true);
                UIlist[(int)UIs.UNClick_Info_bt].SetActive(true);
                break;
            case UIs.Skill_UI_bt:
                MonsterUI_btReset();
                UIlist[16].SetActive(false);
                UIlist[(int)UIs.Skill_UI_bt].SetActive(true);
                UIlist[(int)UIs.Skill_UI].SetActive(true);
                UIlist[(int)UIs.UNClick_Skill_bt].SetActive(true);
                break;
            case UIs.Loon_UI_bt:
                MonsterUI_btReset();
                UIlist[(int)UIs.Loon_UI_bt].SetActive(true);
                UIlist[(int)UIs.Loon_UI].SetActive(true);
                UIlist[(int)UIs.UNClick_Loon_bt].SetActive(true);
                break;
        }
    }
   static public void Closer(UIs uis)
    {
        switch (uis)
        {
            case UIs.Dungeon_UI:
                UIlist[(int)uis].SetActive(false); break;
            case UIs.ChooseStage:
                UIlist[(int)uis].SetActive(false);
                UIlist[(int)UIs.GE].SetActive(false);
                break;
            case UIs.Drop_info:
                UIlist[(int)uis].SetActive(false);break;
            case UIs.Dungeon_Enter:
                UIlist[(int)uis].SetActive(false); break;
            case UIs.Monster_UI:
                UIlist[(int)uis].SetActive(false);break;
            case UIs.Rune1_case:
                UIlist[(int)uis].SetActive(false); break;
            case UIs.Rune2_case:
                UIlist[(int)uis].SetActive(false); break;
            case UIs.Rune3_case:
                UIlist[(int)uis].SetActive(false); break;
            case UIs.Quest:
                UIlist[(int)uis].SetActive(false); break;
            case UIs.Quest_Info:
                UIlist[(int)uis].SetActive(false); break;
            case UIs.LM_1:
                UIlist[(int)uis].SetActive(false); break;
            case UIs.LM_2:
                UIlist[(int)uis].SetActive(false); break;
            case UIs.LM_3:
                UIlist[(int)uis].SetActive(false); break;
            case UIs.R1:
                UIlist[(int)uis].SetActive(false); break;
            case UIs.R2:
                UIlist[(int)uis].SetActive(false); break;
            case UIs.R3:
                UIlist[(int)uis].SetActive(false); break;
        }
    }
  static public void SelecteUIs(UIs uis)
    {
        switch(uis)
        {
            case UIs.Main_bt:
               UIlist[(int)UIs.Main_bt].SetActive(true); UIlist[(int)UIs.User_info].SetActive(true); break;
            case UIs.Dungeon_UI:
                UIlist[(int)uis].SetActive(true); break;
            case UIs.ChooseStage:
                UIlist[(int)uis].SetActive(true);
                UIlist[(int)UIs.GE].SetActive(true); break;
            case UIs.Drop_info:
                UIlist[(int)uis].SetActive(true); break;
            case UIs.Dungeon_Enter:
                UIlist[(int)uis].SetActive(true); break;
            case UIs.Rune1_case:
                UIlist[(int)uis].SetActive(true); break;
            case UIs.Rune2_case:
                UIlist[(int)uis].SetActive(true);break;
            case UIs.Rune3_case:
                UIlist[(int)uis].SetActive(true);break;
            case UIs.Quest:
                UIlist[(int)uis].SetActive(true); gameManager.Quest(); break;
            case UIs.Quest_Info:
                UIlist[(int)uis].SetActive(true);break;
            case UIs.Monster_UI:
                UIlist[(int)uis].SetActive(true);break;
            case UIs.LM_1:
                UIlist[(int)uis].SetActive(true);break;
            case UIs.LM_2:
                UIlist[(int)uis].SetActive(true); break;
            case UIs.LM_3:
                UIlist[(int)uis].SetActive(true); break;
            case UIs.R1:
                UIlist[(int)uis].SetActive(true); break;
            case UIs.R2:
                UIlist[(int)uis].SetActive(true); break;
            case UIs.R3:
                UIlist[(int)uis].SetActive(true); break;

        }
    }
    private void OnDestroy()
    {
        UIlist.Clear();
        LoonImg.Clear();
        Rune1_item_bt.Clear();
        Rune2_item_bt.Clear();
        Rune3_item_bt.Clear();
        Dungeon_Energy.IsDestroyed();
        Town_Energy.IsDestroyed();
    }
}
