using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//활력,맹공,격노,칼날,신속,집중,수호,인내,폭주,절망,흡혈
//Vitality, onslaught, fury, blades, swiftness, concentration, patronage, Patience, runaway, despair, bloodshed
public class ItemManager : MonoBehaviour
{
    GameManager m_cGameManager;
    private void Awake()
    {
        m_cGameManager = new GameManager();
    }
    public class Item : MonoBehaviour
    {

        string m_strName;
        string m_Coment;
        string m_strImage;
        int m_nFuction;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        public Item()
        {

        }
           
        public Item(string name, string coment, int fuc, string img)
        {
            m_strName = name;
            m_Coment = coment;

            m_strImage = img;
            m_nFuction = fuc;
        }
        public string LoonName
        {
            get
            {
                return m_strName;
            }
        }
        public string LoonComent
        {
            get
            {
                return m_Coment;
            }
        }
        public int Fuction
        {
            get
            {
                return m_nFuction;
            }
        }
    }
    static Dictionary<string, Item> m_Itemdic = new Dictionary<string, Item>();
    // Use this for initialization
    void Start () {
        Init();
	}
    public  enum EItem
    {
        VITALITY, ONSLAUGHT, PATRONAGE,
        
    }
    // Update is called once per frame
    void Update () {
       
	}
    private void Init()
    {
        m_Itemdic.Add("활력",new Item("활력", "체력 15% 증가",15,"VITALITY"));
        m_Itemdic.Add("맹공", new Item("맹공", "공격력 30% 증가", 30, "ONSLAUGHT"));
        m_Itemdic.Add("수호", new Item("수호", "방어력 15% 증가", 15, "PATRONAGE"));
    }
   static public Item GetItem(string name)
    {
        return m_Itemdic[name];
    }
  
    //추후예정
    bool LoadItemInfo()
    {
        return true;
    }
}
