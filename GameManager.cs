using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    User m_cUser;
    static public float PlusTurn;
    public enum Scenes { Town, Shop, Hero, Dungeon }
    public Scenes scenes;
    public enum E_Shop { Land, Rein }
    public E_Shop e_Shop;
    public GameObject Land;
    public GameObject Rein;
    GameObject HF;
    public Text m_TMana;
    public Dictionary<string, GameObject> m_HeroDic = new Dictionary<string, GameObject>();//플레이어가 소유하고있는 영웅들 
    static public List<GameObject> BulidingList = new List<GameObject>();//플레이어가 소유하고 있는건물;
    public List<GameObject> LoonImg = new List<GameObject>();
    int m_nMana = 5300;
    public int m_nMaxEnergy = 54;
   static public int m_nEnergy = 30;
    public int m_nMonsterCnt = 5;
    public int m_nMaxMonsterCnt = 30;
    public int m_nStageClearCnt = 2;
    public bool m_bLandBuy;
    public bool m_bReinMagecCIrcleBuy;
    public bool m_bLoon1_mo;
    public bool m_bLoon2_mo;
    public bool m_bLoon3_mo;
    public bool m_bVi;
    public bool m_bOn;
    public bool m_bPa;
    public bool m_bShop;
    public bool m_bHero1;
    public bool m_bHero2;
    public bool m_bHero3;
    public enum E_Monster_Info { Level, Hp, Str, Shield, AttackSpeed }
    public Text Info1;
    public Text Info2;
    public Text Info3;
    public Text Info4;
    public Text Info5;
    Button m_cButton;
    Dungeon dungeon;
    Hero m_cHero;
    UI m_cUi;
    //활력,맹공,격노,칼날,신속,집중,수호,인내,폭주,절망,흡혈
    private void Awake()
    {
        dungeon = new Dungeon();
        m_cHero = new Hero();
        m_cUser = new User();
        m_cUi = new UI();
        Init();
    }
       
    // Use this for initialization
    void Start() {
        // Init();
        HF = GameObject.Find("HeroFram");
         m_cUser.SetInventory(ItemManager.EItem.VITALITY);
        m_cUser.SetInventory(ItemManager.EItem.PATRONAGE);
        m_cUser.SetInventory(ItemManager.EItem.ONSLAUGHT);
       
    }
    // Update is called once per frame
    void Update() { 
        Debug.Log(m_nMana);
        GameObject.Find("T_Mana").GetComponent<Text>().text = m_nMana.ToString();
        Debug.Log(m_bLandBuy);
        Debug.Log(m_bReinMagecCIrcleBuy);
        Debug.Log(scenes);


    }
    public enum E_Hero { H1,H2,H3}
   
   public void M_info()
    {
    }
    public void SelectScence(Scenes sceness)
    {
        switch(sceness)
        {
            case Scenes.Town:
               ;break;
            case Scenes.Hero:
               break;
        }
    }
  public  void Init()
    {
        m_nMana = 5300;
        m_cUser = new User();
        m_cButton = new Button();
        m_bLandBuy = true;
    }
    public enum RuneMountHero { H1,H2,H3}
    public void LoonMounting(ItemManager.EItem eItem)
    {
        Hero h1 = dungeon.m_cHeroPrefab1;
        
        switch (eItem)
        {
            case ItemManager.EItem.VITALITY:
                h1.SetEquipment(eItem);
                User.DeleteInventory(eItem);
                break;
            case ItemManager.EItem.ONSLAUGHT:
                h1.SetEquipment(eItem);
                User.DeleteInventory(eItem);
                break;
            case ItemManager.EItem.PATRONAGE:
                h1.SetEquipment(eItem);
                User.DeleteInventory(eItem);
                break;
        }
    }
  public void Quest()
    {
        if (m_nStageClearCnt > 3)
        {
            QuestReWard(2000);
        }
        else
            return;
    }
    void QuestReWard(int Mana)
    {
        m_nMana += Mana;
    }
}
