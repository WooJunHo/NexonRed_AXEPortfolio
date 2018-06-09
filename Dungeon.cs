﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dungeon : MonoBehaviour
{
    public Camera m_camera;
    public GameObject StageClearUI;
    public GameObject StageGameOverUI;
    public GameObject M_turnPrefab;
    public enum EStage { Stage1, Stage2, Stage3 }
    public bool m_bMonsterturn;
    public bool m_bHeroturn1, m_bHeroturn2, m_bHeroturn3;
    public bool m_bMonsterturn1, m_bMonsterturn2, m_bMonsterturn3;
    public static bool m_bskillkey;
    public static bool m_bAttack;
    public static EStage eStage;
   public Hero m_cMonsterPrefab_1, m_cMonsterPrefab_2, m_cMonsterPrefab_3;
   public Hero m_cHeroPrefab1, m_cHeroPrefab2, m_cHeroPrefab3;
    static public int m_nMonsterStun;
    static public int m_nHeroDamage;
    public bool m_bStageClear;
    public float m_fAttackDlaytime;
    public float m_fTime;
    bool m_bMonsterDead;
    bool m_bAllHeroDead;
    GameManager gameManager;
    public enum Monster { Monster1, Monster2, Monster3 }
    public enum EHero { Hero1, Hero2, Hero3 }
    public static Monster e_monster;
    public EHero e_hero;
    public int HpSmall = 0;
    public int turncnt = 1;
    public int StageClear_Cnt = 0;
    public Dictionary<string,GameObject> m_Monsterlist = new Dictionary<string,GameObject>();//던전내의 몬스터
    public Dictionary<string, GameObject> m_Herolist = new Dictionary<string, GameObject>();//던전내의 영웅
    List<int> HitSPAll_list = new List<int>();
    public GameObject m_MonsterPrefab;
    public GameObject m_HeroPrefab;
    public bool hero1Die, hero2die, hero3die;
    Hero m_cS_Hero;
    Hero m_cS_Monster;
    User m_cUser;
    HpBar m_cHpBar;
    private void Awake()
    {
        m_cUser = new User();
        InitStage(eStage);
        m_bStageClear = false;
        // m_bHeroturn1 = true;
        m_bHeroturn1 = false;
        m_bHeroturn2 = false;
        m_bHeroturn3 = false;
    }
    // Use this for initialization
    void Start()
    {
        StageClearUI.SetActive(false);
        gameManager = new GameManager();
        m_cHpBar = new HpBar();
        DungeonInit();
        m_bStageClear = false;
    }

    // Update is called once per frame
    void Update()
    {
        m_fTime = Time.time;
        ddd();
        DungeonEnter();
    }
    public void ddd()
    {
        m_cHpBar.Set(m_cHeroPrefab1.GetStat(Stat.EStat.HP), m_cHeroPrefab1.GetStat(Stat.EStat.M_HP), HpBar.H_Hero.H1);
        m_cHpBar.Set(m_cHeroPrefab1.GetStat(Stat.EStat.HP), m_cHeroPrefab2.GetStat(Stat.EStat.M_HP), HpBar.H_Hero.H2);
        m_cHpBar.Set(m_cHeroPrefab1.GetStat(Stat.EStat.HP), m_cHeroPrefab3.GetStat(Stat.EStat.M_HP), HpBar.H_Hero.H3);
        m_cHpBar.Set(m_cMonsterPrefab_1.GetStat(Stat.EStat.HP), m_cHeroPrefab1.GetStat(Stat.EStat.M_HP), HpBar.H_Monster.M1);
        m_cHpBar.Set(m_cMonsterPrefab_2.GetStat(Stat.EStat.HP), m_cHeroPrefab1.GetStat(Stat.EStat.M_HP), HpBar.H_Monster.M2);
        m_cHpBar.Set(m_cMonsterPrefab_3.GetStat(Stat.EStat.HP), m_cHeroPrefab1.GetStat(Stat.EStat.M_HP), HpBar.H_Monster.M3);
    }
    public void Restart()
    {
        eStage = EStage.Stage1;
        StageClearUI.SetActive(false);
    }
    //private void OnGUI()
    //{
    //    GUI.Box(new Rect(0, 0, 100, 30), "1PlayerHP: " + m_cHeroPrefab1.GetStat(Stat.EStat.HP));
    //    GUI.Box(new Rect(0, 30, 100, 30), "1PlayerMP: " + m_cHeroPrefab1.GetStat(Stat.EStat.MP));
    //    GUI.Box(new Rect(0, 60, 100, 30), "1Level : " + m_cHeroPrefab1.GetStat(Stat.EStat.LEVEL));
    //    GUI.Box(new Rect(0, 90, 100, 30), "2PlayerHP: " + m_cHeroPrefab2.GetStat(Stat.EStat.HP));
    //    GUI.Box(new Rect(0, 120, 100, 30), "2PlayerMP: " + m_cHeroPrefab2.GetStat(Stat.EStat.MP));
    //    GUI.Box(new Rect(0, 150, 100, 30), "2Level : " + m_cHeroPrefab2.GetStat(Stat.EStat.LEVEL));
    //    GUI.Box(new Rect(0, 180, 100, 30), "3PlayerHP: " + m_cHeroPrefab3.GetStat(Stat.EStat.HP));
    //    GUI.Box(new Rect(0, 210, 100, 30), "3PlayerMP: " + m_cHeroPrefab3.GetStat(Stat.EStat.MP));
    //    GUI.Box(new Rect(0, 240, 100, 30), "3Level : " + m_cHeroPrefab3.GetStat(Stat.EStat.LEVEL));
    //    GUI.Box(new Rect(Screen.width - 100, 60, 100, 30), "1MonsterHP: " + m_cMonsterPrefab_1.GetStat(Stat.EStat.HP));
    //    GUI.Box(new Rect(Screen.width - 100, 90, 100, 30), "Level : " + m_cMonsterPrefab_1.GetStat(Stat.EStat.LEVEL));
    //    GUI.Box(new Rect(Screen.width - 100, 120, 100, 30), "2MonsterHP: " + m_cMonsterPrefab_2.GetStat(Stat.EStat.HP));
    //    GUI.Box(new Rect(Screen.width - 100, 150, 100, 30), "Level : " + m_cMonsterPrefab_2.GetStat(Stat.EStat.LEVEL));
    //    GUI.Box(new Rect(Screen.width - 100, 180, 100, 30), "3MonsterHP: " + m_cMonsterPrefab_3.GetStat(Stat.EStat.HP));
    //    GUI.Box(new Rect(Screen.width - 100, 210, 100, 30), "Level : " + m_cMonsterPrefab_3.GetStat(Stat.EStat.LEVEL));
    //}
    public void NextStage()
    {
        SceneManager.LoadScene((int)EStage.Stage2);
    }
    void DungeonInit()
    {

        m_fAttackDlaytime = 3;
        m_fTime = 0.0f;
        HitSPAll_list.Add(m_cHeroPrefab1.GetStat(Stat.EStat.HITSPEED));
        HitSPAll_list.Add(m_cHeroPrefab2.GetStat(Stat.EStat.HITSPEED));
        HitSPAll_list.Add(m_cHeroPrefab3.GetStat(Stat.EStat.HITSPEED));
        HitSPAll_list.Add(m_cMonsterPrefab_1.GetStat(Stat.EStat.HITSPEED));
        HitSPAll_list.Add(m_cMonsterPrefab_2.GetStat(Stat.EStat.HITSPEED));
        HitSPAll_list.Add(m_cMonsterPrefab_3.GetStat(Stat.EStat.HITSPEED));
        HitSPAll_list.Sort();
        Debug.Log("H1" + HitSPAll_list[0]);
        Debug.Log("H2" + HitSPAll_list[1]);
        Debug.Log("H3" + HitSPAll_list[2]);
        Debug.Log("M1" + HitSPAll_list[3]);
        Debug.Log("M2" + HitSPAll_list[4]);
        Debug.Log("M3" + HitSPAll_list[5]);
    }
  
    void DungeonEnter()
    {
        if (m_cMonsterPrefab_1.Dead() && m_cMonsterPrefab_2.Dead() && m_cMonsterPrefab_3.Dead())
            StageClear(EStage.Stage1);
        else if (m_cHeroPrefab1.Dead() && m_cHeroPrefab2.Dead() && m_cHeroPrefab3.Dead())
            GameOver();
        else if (!m_bStageClear)
            Battle();
        else
            return;
    }
    void GameOver()
    {

    }
    GameObject M_t_v;
    void SelectMonster_view(float axis_Z)
    {
        M_t_v = Instantiate(M_turnPrefab);
        M_t_v.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        M_t_v.transform.position = new Vector3(-3, 1.2f, axis_Z);
    }
    void SelectMonster()
    {
        switch(e_monster)
        {
            case Monster.Monster1: DestroyObject(M_t_v); m_cS_Monster = m_cMonsterPrefab_1; SelectMonster_view(-1.4f); break;
            case Monster.Monster2: DestroyObject(M_t_v); m_cS_Monster = m_cMonsterPrefab_2; SelectMonster_view(0); break;
            case Monster.Monster3: DestroyObject(M_t_v); m_cS_Monster = m_cMonsterPrefab_3; SelectMonster_view(1.4f); break;
        }
        
    }
    void SelectHero()
    {
        int RandHero = 0;
        RandHero=Random.Range(0, 2);
        if (RandHero == 0 && !m_cHeroPrefab1.Dead())
            m_cS_Hero = m_cHeroPrefab1;
        else if (RandHero == 1 && !m_cHeroPrefab2.Dead())
            m_cS_Hero = m_cHeroPrefab2;
        else if (RandHero == 2 && !m_cHeroPrefab3.Dead())
            m_cS_Hero = m_cHeroPrefab3;
        else
            return;
    }
    float m_fMonsterMoveAxisX=0;
    float m_fMonsterMoveAxisZ = 0;
    void MonsterMove()
    {
       if(m_cS_Hero==m_cHeroPrefab1)
        {
            m_fMonsterMoveAxisX = 0.26f;
            m_fMonsterMoveAxisZ = -1.72f;
        }
       else if(m_cS_Hero==m_cHeroPrefab2)
        {
            m_fMonsterMoveAxisX = 0.26f;
            m_fMonsterMoveAxisZ = -0.21f;
        }
        else if (m_cS_Hero == m_cHeroPrefab3)
        {
            m_fMonsterMoveAxisX = 0.26f;
            m_fMonsterMoveAxisZ = 2.14f;
        }
    }
    bool AllHitSPCheck(Hero mon,int idx)//매개변수 : 몬스터 및 플레이어를 관리하는 클래스와 인덱스 값 
    {
        //초기화 할때 미리 리스트 변수에 순차적으로 저장해둔 공격속도 중 인덱스 값에해당여부를 체크하는함수
        if (mon.GetStat(Stat.EStat.HITSPEED) == HitSPAll_list[idx] && !mon.Dead())
            return true;
        else
            return false;
    }
    void TurnReset()
    {
        turncnt = 1;
        m_bHeroturn1 = false;
        m_bHeroturn2 = false;
        m_bHeroturn3 = false;
        m_bMonsterturn1 = false;
        m_bMonsterturn2 = false;
        m_bMonsterturn3 = false;
    }
    private void TurnSel()
    {
        if (turncnt > 6)
        {
            TurnReset();//모든턴을 리셋하는 함수 
        }
        else
        {
            switch (turncnt)//턴 순서 카운트 정수형변수
            {
                case 1://1번째 턴을 정하는 부분
                    {
                        if (AllHitSPCheck(m_cHeroPrefab1, 5))//플레이어 캐릭터,인덱스 
                        {
                            m_bHeroturn1 = true;
                        }
                        else if (AllHitSPCheck(m_cHeroPrefab2, 5))
                        {
                            m_bHeroturn2 = true;
                        }
                        else if (AllHitSPCheck(m_cHeroPrefab3, 5))
                        {
                            m_bHeroturn3 = true;
                        }
                        else if (AllHitSPCheck(m_cMonsterPrefab_1, 5))
                        {
                            m_bMonsterturn1 = true;
                        }
                        else if (AllHitSPCheck(m_cMonsterPrefab_2, 5))
                        {
                            m_bMonsterturn2 = true;
                        }
                        else if (AllHitSPCheck(m_cMonsterPrefab_3, 5))
                        {
                            m_bMonsterturn3 = true;
                        }
                    }
                    break;
                case 2:
                    {
                        if (AllHitSPCheck(m_cHeroPrefab1, 4))
                        {
                            m_bHeroturn1 = true;
                        }
                        else if (AllHitSPCheck(m_cHeroPrefab2, 4))
                        {
                            m_bHeroturn2 = true;
                        }
                        else if (AllHitSPCheck(m_cHeroPrefab3, 4))
                        {
                            m_bHeroturn3 = true;
                        }
                        else if (AllHitSPCheck(m_cMonsterPrefab_1, 4))
                        {
                            m_bMonsterturn1 = true;
                        }
                        else if (AllHitSPCheck(m_cMonsterPrefab_2, 4))
                        {
                            m_bMonsterturn2 = true;
                        }
                        else if (AllHitSPCheck(m_cMonsterPrefab_3, 4))
                        {
                            m_bMonsterturn3 = true;
                        }
                    }
                    break;
                case 3:
                    {
                        if (AllHitSPCheck(m_cHeroPrefab1, 3))
                        {
                            m_bHeroturn1 = true;
                        }
                        else if (AllHitSPCheck(m_cHeroPrefab2, 3))
                        {
                            m_bHeroturn2 = true;
                        }
                        else if (AllHitSPCheck(m_cHeroPrefab3, 3))
                        {
                            m_bHeroturn3 = true;
                        }
                        else if (AllHitSPCheck(m_cMonsterPrefab_1, 3))
                        {
                            m_bMonsterturn1 = true;
                        }
                        else if (AllHitSPCheck(m_cMonsterPrefab_2, 3))
                        {
                            m_bMonsterturn2 = true;
                        }
                        else if (AllHitSPCheck(m_cMonsterPrefab_3, 3))
                        {
                            m_bMonsterturn3 = true;
                        }
                    }
                    break;
                case 4:
                    {
                        if (AllHitSPCheck(m_cHeroPrefab1, 2))
                        {
                            m_bHeroturn1 = true;
                        }
                        else if (AllHitSPCheck(m_cHeroPrefab2, 2))
                        {
                            m_bHeroturn2 = true;
                        }
                        else if (AllHitSPCheck(m_cHeroPrefab3, 2))
                        {
                            m_bHeroturn3 = true;
                        }
                        else if (AllHitSPCheck(m_cMonsterPrefab_1, 2))
                        {
                            m_bMonsterturn1 = true;
                        }
                        else if (AllHitSPCheck(m_cMonsterPrefab_2, 2))
                        {
                            m_bMonsterturn2 = true;
                        }
                        else if (AllHitSPCheck(m_cMonsterPrefab_3, 2))
                        {
                            m_bMonsterturn3 = true;
                        }
                    }
                    break;
                case 5:
                    {
                        if (AllHitSPCheck(m_cHeroPrefab1, 1))
                        {
                            m_bHeroturn1 = true;
                        }
                        else if (AllHitSPCheck(m_cHeroPrefab2, 1))
                        {
                            m_bHeroturn2 = true;
                        }
                        else if (AllHitSPCheck(m_cHeroPrefab3, 1))
                        {
                            m_bHeroturn3 = true;
                        }
                        else if (AllHitSPCheck(m_cMonsterPrefab_1, 1))
                        {
                            m_bMonsterturn1 = true;
                        }
                        else if (AllHitSPCheck(m_cMonsterPrefab_2, 1))
                        {
                            m_bMonsterturn2 = true;
                        }
                        else if (AllHitSPCheck(m_cMonsterPrefab_3, 1))
                        {
                            m_bMonsterturn3 = true;
                        }
                    }
                    break;
                case 6:
                    {
                        if (AllHitSPCheck(m_cHeroPrefab1, 0))
                        {
                            m_bHeroturn1 = true;
                        }
                        else if (AllHitSPCheck(m_cHeroPrefab2, 0))
                        {
                            m_bHeroturn2 = true;
                        }
                        else if (AllHitSPCheck(m_cHeroPrefab3, 0))
                        {
                            m_bHeroturn3 = true;
                        }
                        else if (AllHitSPCheck(m_cMonsterPrefab_1, 0))
                        {
                            m_bMonsterturn1 = true;
                        }
                        else if (AllHitSPCheck(m_cMonsterPrefab_2, 0))
                        {
                            m_bMonsterturn2 = true;
                        }
                        else if (AllHitSPCheck(m_cMonsterPrefab_3, 0))
                        {
                            m_bMonsterturn3 = true;
                        }
                    }
                    break;
            }
        }
    }
    Vector3 MonsterResetPosition(GameObject mon)
    {
       if(mon==m_Monsterlist["Monster1"])
        {
            return new  Vector3(-3f, 0.6285628f, -1.4f);
        }
       else if (mon == m_Monsterlist["Monster2"])
        {
            return new Vector3(-3f, 0.6285628f, 0);
        }
        else if (mon == m_Monsterlist["Monster3"])
        {
            return new Vector3(-3f, 0.6285628f, 1.4f);
        }

        return new Vector3();
    }
    void Battle()
    {
        TurnSel();
        if(m_bHeroturn1)
        {
            DestroyObject(M_t_v);
            SelectMonster();
            e_hero = EHero.Hero1;
            if(m_cHeroPrefab1.Dead())
            {
                hero1Die = true;
                m_cHeroPrefab1.SetStat(Stat.EStat.HP, 0);
                m_Herolist["Hero1"].SetActive(false);
                m_bHeroturn1 = false;
                TurnSel();
                turncnt++;
            }
            else
            {
                if (m_bAttack)
                {
                    m_Herolist["Hero1"].transform.position = new Vector3(-2.15f,0.17856f,-1.4f);
                    m_cHeroPrefab1.Attack(m_cS_Monster);
                    m_Herolist["Hero1"].transform.position = new Vector3(1.65f, 0.6285628f, -2.0f);
                    Debug.Log("ht1");
                    m_bHeroturn1 = false;
                    TurnSel();
                    turncnt++;
                }
                
                if (m_bskillkey)
                {
                    m_Herolist["Hero1"].transform.position = new Vector3(-2.15f, 0.17856f, -1.4f);
                    m_cHeroPrefab1.Skill(m_cS_Monster, Stat.ESkill.SKILL_1);
                    m_Herolist["Hero1"].transform.position = new Vector3(1.65f, 0.6285628f, -2.0f);
                    m_bHeroturn1 = false;
                    TurnSel();
                    turncnt++;
                }
            }
        }
        
      else  if (m_bHeroturn2)
        {
            DestroyObject(M_t_v);
            SelectMonster();
            e_hero = EHero.Hero2;
            if (m_cHeroPrefab1.Dead())
            {
                hero1Die = true;
                m_cHeroPrefab2.SetStat(Stat.EStat.HP, 0);
                m_Herolist["Hero2"].SetActive(false);
                m_bHeroturn2 = false;
                TurnSel();
                turncnt++;
            }
            else
            {
                if (m_bAttack)
                {
                    m_Herolist["Hero2"].transform.position = new Vector3(-2.15f, 0.17856f, -0.08f);
                    m_cHeroPrefab2.Attack(m_cS_Monster);
                      m_Herolist["Hero2"].transform.position = new Vector3(1.65f, 0.6285628f, 0);
                    Debug.Log("ht1");
                    m_bHeroturn2 = false;
                    TurnSel();
                    turncnt++;
                }
                if (m_bskillkey)
                {
                    m_Herolist["Hero2"].transform.position = new Vector3(-2.15f, 0.17856f, -0.08f);
                    m_cHeroPrefab2.Skill(m_cS_Monster, Stat.ESkill.SKILL_1);
                    m_Herolist["Hero2"].transform.position = new Vector3(1.65f, 0.6285628f, 0);
                    m_bHeroturn2 = false;
                    TurnSel();
                    turncnt++;
                }
            }
        }
      else if (m_bHeroturn3)
        {
            DestroyObject(M_t_v);
            SelectMonster();
            e_hero = EHero.Hero3;
            if (m_cHeroPrefab3.Dead())
            {
                hero1Die = true;
                m_cHeroPrefab3.SetStat(Stat.EStat.HP, 0);
                m_Herolist["Hero3"].SetActive(false);
                m_bHeroturn3 = false;
                TurnSel();
                turncnt++;
            }
            else
            {
                if (m_bAttack)
                {
                    m_Herolist["Hero3"].transform.position = new Vector3(-2.15f, 0.17856f, 1.19f);
                    m_cHeroPrefab3.Attack(m_cS_Monster);
                    m_Herolist["Hero3"].transform.position = new Vector3(1.65f, 0.6285628f, 2.0f);
                    Debug.Log("ht1");
                    m_bHeroturn3 = false;
                    TurnSel();
                    turncnt++;
                }
                if (m_bskillkey)
                {
                    m_Herolist["Hero3"].transform.position = new Vector3(-2.15f, 0.17856f, 1.19f);
                    m_cHeroPrefab3.Skill(m_cS_Monster, Stat.ESkill.SKILL_1);
                    m_Herolist["Hero3"].transform.position = new Vector3(1.65f, 0.6285628f, 2.0f);
                    m_bHeroturn2 = false;
                    TurnSel();
                    turncnt++;
                }
            }
        }
         if(m_bMonsterturn1)
        {
            Debug.Log("Monster1");
            DestroyObject(M_t_v);
            SelectHero();
            SelectMonster_view(1.4f);
            MonsterMove();
            m_fTime = 0;
            m_fTime = Time.time;
            if(m_cMonsterPrefab_1.Dead())
            {
                m_cMonsterPrefab_1.SetStat(Stat.EStat.HP, 0);
                m_bMonsterturn1 = false;
                TurnSel();
                turncnt++;
            }
            else
            {
                m_Monsterlist["Monster1"].transform.position =new Vector3(m_fMonsterMoveAxisX, 1.8f, m_fMonsterMoveAxisZ);
                m_cMonsterPrefab_1.Attack(m_cS_Hero);
                ;
                if (m_fAttackDlaytime<m_fTime)
                {
                    m_Monsterlist["Monster1"].transform.position = MonsterResetPosition(m_Monsterlist["Monster1"]); Debug.Log("Monster1at");
                    m_bMonsterturn1 = false;
                    TurnSel();
                    turncnt++;
                }
                else
                    return;
            }
        }
        else if (m_bMonsterturn2)
        {
            Debug.Log("Monster2");
            DestroyObject(M_t_v);
            SelectMonster_view(0);
            SelectHero();
            m_fTime = 0;
            m_fTime = Time.time;
            if (m_cMonsterPrefab_2.Dead())
            {
                m_cMonsterPrefab_2.SetStat(Stat.EStat.HP, 0);
                m_bMonsterturn2 = false;
                TurnSel();
                turncnt++;
            }
            else
            {
                m_Monsterlist["Monster2"].transform.position = new Vector3(m_fMonsterMoveAxisX, 1.8f, m_fMonsterMoveAxisZ);
                m_cMonsterPrefab_2.Attack(m_cS_Hero); ;
                if (m_fAttackDlaytime < m_fTime)
                {
                    m_Monsterlist["Monster2"].transform.position = MonsterResetPosition(m_Monsterlist["Monster2"]); Debug.Log("Monster2at");
                    m_bMonsterturn2 = false;
                    TurnSel();
                    turncnt++;
                }
                else
                    return;
            }
        }
        else if (m_bMonsterturn3)
        {
            Debug.Log("Monster3");
            DestroyObject(M_t_v);
            SelectMonster_view(-1.4f);
            SelectHero();
            m_fTime = 0;
            m_fTime = Time.time;
            if (m_cMonsterPrefab_3.Dead())
            {
                m_cMonsterPrefab_3.SetStat(Stat.EStat.HP, 0);
                m_bMonsterturn3 = false;
                TurnSel();
                turncnt++;
            }
            else
            {
                m_Monsterlist["Monster3"].transform.position = new Vector3(m_fMonsterMoveAxisX, 1.8f, m_fMonsterMoveAxisZ);
                m_cMonsterPrefab_3.Attack(m_cS_Hero); ;
                if (m_fAttackDlaytime < m_fTime)
                {
                    m_Monsterlist["Monster3"].transform.position = MonsterResetPosition(m_Monsterlist["Monster3"]); Debug.Log("Monster3at");
                    m_bMonsterturn3 = false;
                    TurnSel();
                    turncnt++;
                }
                else
                    return;
            }
        }
    }
    void MonsterStun(int idx, EStage stage)
    {
        
    }
    void SelectMonsterturn(int idx, EStage stage)
    {

    }
    void StageClear(EStage stage)
    {
        switch (stage)
        {
            case EStage.Stage1:
                m_bMonsterturn = false;
                m_fTime = 0;
                m_cHeroPrefab1.SetStat(Stat.EStat.EXP, 100);
                m_cHeroPrefab1.LvUp();
                m_cHeroPrefab2.SetStat(Stat.EStat.EXP, 100);
                m_cHeroPrefab2.LvUp();
                m_cHeroPrefab3.SetStat(Stat.EStat.EXP, 100);
                m_cHeroPrefab3.LvUp();
                StageClearUI.SetActive(true);
                gameManager.m_nStageClearCnt++;
                Reward(ItemManager.EItem.VITALITY);
                ReleaseMonsters();
                //  m_Button.SetActive(true);
                break;
            case EStage.Stage2:
                m_bMonsterturn = false;
                m_fTime = 0;
                m_cHeroPrefab1.SetStat(Stat.EStat.EXP, 100);
                m_cHeroPrefab1.LvUp();
                m_cHeroPrefab2.SetStat(Stat.EStat.EXP, 100);
                m_cHeroPrefab2.LvUp();
                m_cHeroPrefab3.SetStat(Stat.EStat.EXP, 100);
                m_cHeroPrefab3.LvUp();
                ReleaseMonsters();
                break;
            case EStage.Stage3:
                m_bMonsterturn = false;
                m_fTime = 0;
                m_cHeroPrefab1.SetStat(Stat.EStat.EXP, 100);
                m_cHeroPrefab1.LvUp();
                m_cHeroPrefab2.SetStat(Stat.EStat.EXP, 100);
                m_cHeroPrefab2.LvUp();
                m_cHeroPrefab3.SetStat(Stat.EStat.EXP, 100);
                m_cHeroPrefab3.LvUp();
                ReleaseMonsters();
                break;
        }
       m_HeroPrefab.SetActive(false);
        m_MonsterPrefab.SetActive(false);
        ReleaseMonsters();

    }
    void ReleaseMonsters()
    {
        m_Monsterlist.Clear();
        m_Herolist.Clear();
    }
    void AddMonster(float AxisZ, int idx)
    {
        GameObject Monster = Instantiate(m_MonsterPrefab);
        Monster.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        Monster.transform.position = new Vector3(-3f, 0.6285628f, AxisZ);
        Monster.name = "Monster" + idx;
        Monster.GetComponent<Hero>();
        m_Monsterlist.Add(Monster.name,Monster);
    }
    void AddHero(float AxisZ, int idx)
    {
        GameObject Hero = Instantiate(m_HeroPrefab);
        Hero.transform.localScale = new Vector3(1, 1, 1);
        Hero.transform.position = new Vector3(1.65f, 0.6285628f, AxisZ);
        Hero.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        Hero.transform.Rotate(0, -90, 0);
        Hero.name = "Hero" + idx;
       m_Herolist.Add(Hero.name,Hero);
    }
    void SaveData()
    {
        //PlayerPrefs.SetInt("Hero1_Lv", m_cHeroPrefab1.GetStat(Stat.EStat.LEVEL));
        //PlayerPrefs.SetInt("Hero1_Hp", m_cHeroPrefab1.GetStat(Stat.EStat.M_HP));
        //PlayerPrefs.SetInt("Hero1_Str", m_cHeroPrefab1.GetStat(Stat.EStat.STR));
        //PlayerPrefs.SetInt("Hero1_Shield", m_cHeroPrefab1.GetStat(Stat.EStat.SHIELD));
        //PlayerPrefs.SetInt("Hero1_HitSP", m_cHeroPrefab1.GetStat(Stat.EStat.HITSPEED));

        //PlayerPrefs.SetInt("Hero2_Lv", m_cHeroPrefab2.GetStat(Stat.EStat.LEVEL));
        //PlayerPrefs.SetInt("Hero2_Hp", m_cHeroPrefab2.GetStat(Stat.EStat.M_HP));
        //PlayerPrefs.SetInt("Hero2_Str", m_cHeroPrefab2.GetStat(Stat.EStat.STR));
        //PlayerPrefs.SetInt("Hero2_Shield", m_cHeroPrefab2.GetStat(Stat.EStat.SHIELD));
        //PlayerPrefs.SetInt("Hero2_HitSP", m_cHeroPrefab2.GetStat(Stat.EStat.HITSPEED));

        //PlayerPrefs.SetInt("Hero3_Lv", m_cHeroPrefab3.GetStat(Stat.EStat.LEVEL));
        //PlayerPrefs.SetInt("Hero3_Hp", m_cHeroPrefab3.GetStat(Stat.EStat.M_HP));
        //PlayerPrefs.SetInt("Hero3_Str", m_cHeroPrefab3.GetStat(Stat.EStat.STR));
        //PlayerPrefs.SetInt("Hero3_Shield", m_cHeroPrefab3.GetStat(Stat.EStat.SHIELD));
        //PlayerPrefs.SetInt("Hero3_HitSP", m_cHeroPrefab3.GetStat(Stat.EStat.HITSPEED));

    }
    void InitStage(EStage stage)
    {
        switch (stage)
        {
            case EStage.Stage1:
                m_HeroPrefab.SetActive(true);
                m_MonsterPrefab.SetActive(true);
                AddMonster(-1.4f, 1);
                AddMonster(0.0f, 2);
                AddMonster(1.4f, 3);
                AddHero(-2.0f, 1);
                AddHero(0.0f, 2);
                AddHero(2.0f, 3);
                GameManager.m_nEnergy -= 3;
                m_cMonsterPrefab_1 = m_Monsterlist["Monster1"].GetComponent<Hero>();
                m_cMonsterPrefab_2 = m_Monsterlist["Monster2"].GetComponent<Hero>();
                m_cMonsterPrefab_3 = m_Monsterlist["Monster3"].GetComponent<Hero>();
                m_cHeroPrefab1 = m_Herolist["Hero1"].GetComponent<Hero>();
                m_cHeroPrefab2 = m_Herolist["Hero2"].GetComponent<Hero>();
                m_cHeroPrefab3 = m_Herolist["Hero3"].GetComponent<Hero>();
                m_cMonsterPrefab_1.GetComponent<Hero>().SetStat(Stat.EStat.HITSPEED, 15);
                m_cMonsterPrefab_2.GetComponent<Hero>().SetStat(Stat.EStat.HITSPEED, 12);
                m_cMonsterPrefab_3.GetComponent<Hero>().SetStat(Stat.EStat.HITSPEED, 50);
                m_cHeroPrefab1.GetComponent<Hero>().SetStat(Stat.EStat.HITSPEED, 30);
                m_cHeroPrefab2.GetComponent<Hero>().SetStat(Stat.EStat.HITSPEED, 25);
                m_cHeroPrefab3.GetComponent<Hero>().SetStat(Stat.EStat.HITSPEED, 60);
                m_cHeroPrefab1.GetComponent<Hero>().SetStat(Stat.EStat.STR, 50);
                m_cHeroPrefab2.GetComponent<Hero>().SetStat(Stat.EStat.STR, 50);
                m_cHeroPrefab3.GetComponent<Hero>().SetStat(Stat.EStat.STR, 50);
                m_cMonsterPrefab_1.GetComponent<Hero>().SetStat(Stat.EStat.STR, 3);
                m_cMonsterPrefab_2.GetComponent<Hero>().SetStat(Stat.EStat.STR, 3);
                m_cMonsterPrefab_3.GetComponent<Hero>().SetStat(Stat.EStat.STR, 3);
                m_cMonsterPrefab_1.GetComponent<Hero>().SetStat(Stat.EStat.HP, 10);
                m_cMonsterPrefab_2.GetComponent<Hero>().SetStat(Stat.EStat.HP, 10);
                m_cMonsterPrefab_3.GetComponent<Hero>().SetStat(Stat.EStat.HP, 10);
                m_cHeroPrefab1.GetComponent<Hero>().SetStat(Stat.EStat.M_HP, 80);
                m_cHeroPrefab2.GetComponent<Hero>().SetStat(Stat.EStat.M_HP, 80);
                m_cHeroPrefab3.GetComponent<Hero>().SetStat(Stat.EStat.M_HP, 80);
                m_cHeroPrefab1.GetComponent<Hero>().SetStat(Stat.EStat.HP, 80);
                m_cHeroPrefab2.GetComponent<Hero>().SetStat(Stat.EStat.HP, 80);
                m_cHeroPrefab3.GetComponent<Hero>().SetStat(Stat.EStat.HP, 80);
                Debug.Log(GameManager.m_nEnergy);
                Debug.Log("mhp" + m_cMonsterPrefab_1.GetStat(Stat.EStat.HP));
                Debug.Log("Hhp" + m_cHeroPrefab1.GetStat(Stat.EStat.HP));
                m_bMonsterturn = false;
                break;
            case EStage.Stage2:

                m_HeroPrefab.SetActive(true);
                m_MonsterPrefab.SetActive(true);
                AddMonster(-1.4f, 1);
                AddMonster(0.0f, 2);
                AddMonster(1.4f, 3);
                AddHero(-2.0f, 1);
                AddHero(0.0f, 2);
                AddHero(2.0f, 3);
                m_cMonsterPrefab_1 = m_Monsterlist["Monster1"].GetComponent<Hero>();
                m_cMonsterPrefab_2 = m_Monsterlist["Monster2"].GetComponent<Hero>();
                m_cMonsterPrefab_3 = m_Monsterlist["Monster3"].GetComponent<Hero>();
                m_cHeroPrefab1 = m_Herolist["Hero1"].GetComponent<Hero>();
                m_cHeroPrefab2 = m_Herolist["Hero2"].GetComponent<Hero>();
                m_cHeroPrefab3 = m_Herolist["Hero3"].GetComponent<Hero>();
                break;
            case EStage.Stage3:
               m_HeroPrefab.SetActive(true);
                m_MonsterPrefab.SetActive(true);
                AddMonster(-1.4f, 1);
                AddMonster(0.0f, 2);
                AddMonster(1.4f, 3);
                AddHero(-2.0f, 1);
                AddHero(0.0f, 2);
                AddHero(2.0f, 3);
                m_cMonsterPrefab_1 = m_Monsterlist["Monster1"].GetComponent<Hero>();
                m_cMonsterPrefab_2 = m_Monsterlist["Monster2"].GetComponent<Hero>();
                m_cMonsterPrefab_3 = m_Monsterlist["Monster3"].GetComponent<Hero>();
                m_cHeroPrefab1 = m_Herolist["Hero1"].GetComponent<Hero>();
                m_cHeroPrefab2 = m_Herolist["Hero2"].GetComponent<Hero>();
                m_cHeroPrefab3 = m_Herolist["Hero3"].GetComponent<Hero>();
                break;
        }

    }
    void Reward(ItemManager.EItem eItem)
    {
        if (m_bStageClear)
        {
            m_cUser.SetInventory(eItem);
        }
        else
            return;
    }
    private void OnDestroy()
    {
        ReleaseMonsters();
    }
}
