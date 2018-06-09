using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Button : MonoBehaviour {
    
    GameManager m_cGameManager;
    Dungeon m_cDungeon;
    UI m_cUi;
    Hero m_cHero;
    public string StageName;
    public bool m_bBgm;
    public bool m_bEfectterSound;
    public bool m_bOn, m_bOff;
    public enum EMonsterUI {UN_Info_UI,UN_Skill_UI,UN_Loon_UI}
    public EMonsterUI m_eMonsterUI;
    public enum Rune { RUNE1,RUNE2,RUNE3,NONE}
    public enum E_Hero { H1,H2,H3}
    public enum E_R_M { RM1,RM2,RM3}
    public E_Hero e_Hero;
    public Rune E_Rune;
    // Use this for initialization
    public E_R_M E_RM;
    void Start () {
        m_cGameManager = new GameManager();
        m_cDungeon = new Dungeon();
        m_cUi = new UI();
        m_cHero = new Hero();
    }
	
	// Update is called once per frame
	void Update () {
		

	}
   public void NextStage()
    {
        switch(Dungeon.eStage)
        {
            case Dungeon.EStage.Stage1:
                Dungeon.eStage = Dungeon.EStage.Stage1;break;
            case Dungeon.EStage.Stage2:
                Dungeon.eStage = Dungeon.EStage.Stage2;break;
        }
      
    }
    public void MonsterUI()
    {
        switch(m_eMonsterUI)
        {
            case EMonsterUI.UN_Info_UI:
                UI.MonsterUI_BT(UI.UIs.Info_UI_bt);break;
            case EMonsterUI.UN_Skill_UI:
                UI.MonsterUI_BT(UI.UIs.Skill_UI_bt);break;
            case EMonsterUI.UN_Loon_UI:
                UI.MonsterUI_BT(UI.UIs.Loon_UI_bt);break;
        }
    }
    public void dungeon()
    {
        UI.SelecteUIs(UI.UIs.Dungeon_UI);
        m_cGameManager.SelectScence(GameManager.Scenes.Dungeon);
    }
    public void StageChoose()
    {

        //SceneManager.LoadScene(1);
        SceneManager.LoadSceneAsync(1);
        switch(StageName)
        {
            case "Stage1":Dungeon.eStage=Dungeon.EStage.Stage1;
                break;
            case "Stage2": Dungeon.eStage = Dungeon.EStage.Stage2; break;
            case "Stage3": Dungeon.eStage = Dungeon.EStage.Stage3; break;
               
        }
    }
    public void DungeonCloser()
    {
        UI.Closer(UI.UIs.Dungeon_UI);
    }
    public void Drop_Info()
    {
        UI.SelecteUIs(UI.UIs.Drop_info);
    }
    public void Drop_InfoCloser()
    {
        UI.Closer(UI.UIs.Drop_info);
        
    }
    public void MonsterUICloser()
    {
        UI.Closer(UI.UIs.Monster_UI);
    }
    public void MonsterUIOpen()
    {
        UI.SelecteUIs(UI.UIs.Monster_UI);
    }
    public void Dungeon_Enter()
    {
        UI.SelecteUIs(UI.UIs.Dungeon_Enter);
    }
    public void Dungeon_Enter_Closer()
    {
        UI.Closer(UI.UIs.Dungeon_Enter);
    }
    public void StageChoose_UI()
    {
        UI.SelecteUIs(UI.UIs.ChooseStage);
    }
    public void StageChoose_close()
    {
        UI.Closer(UI.UIs.ChooseStage);
    }
    public void StageRestart()
    {
        //m_cDungeon.Restart();
        SceneManager.LoadSceneAsync(1);
    }
    public void ReturnTown()
    {
         
        SceneManager.LoadSceneAsync(0);
    }
    public void Attack()
    {
        Dungeon.m_bAttack = true;
    }
    public void Skill()
    {
        Dungeon.m_bskillkey = true;
    }
    public void RuneMount_bt()
    {
        switch(E_RM)
        {
            case E_R_M.RM1:
                UI.SelecteUIs(UI.UIs.LM_1);
                break;
            case E_R_M.RM2:
                UI.SelecteUIs(UI.UIs.LM_2);
                break;
            case E_R_M.RM3:
                UI.SelecteUIs(UI.UIs.LM_3);
                break;
        }
    }
    public void SetRune()
    {
        switch(E_Rune)
        {
            case Rune.RUNE1:
                UI.SetRuneImg(E_Rune);
                m_cUi.SetRune(ItemManager.EItem.VITALITY);
                break;
            case Rune.RUNE2:
                UI.SetRuneImg(E_Rune);
                m_cUi.SetRune(ItemManager.EItem.PATRONAGE);
                break;
            case Rune.RUNE3:
                UI.SetRuneImg(E_Rune);
                m_cUi.SetRune(ItemManager.EItem.ONSLAUGHT);
                break;

        }
    }
    public void RSet()
    {
        switch(E_Rune)
        {
            case Rune.RUNE1:
                UI.SelecteUIs(UI.UIs.R1);
                break;
            case Rune.RUNE2:
                UI.SelecteUIs(UI.UIs.R2);
                break;
            case Rune.RUNE3:
                UI.SelecteUIs(UI.UIs.R3);
                break;

        }
    }
    public void RCloser()
    {
        switch (E_Rune)
        {
            case Rune.RUNE1:
                UI.Closer(UI.UIs.R1);
                break;
            case Rune.NONE:
                UI.Closer(UI.UIs.R1);break;
            case Rune.RUNE2:
                UI.Closer(UI.UIs.R2);
                break;
            case Rune.RUNE3:
                UI.Closer(UI.UIs.R3);
                break;

        }
    }
    public void UnMt_Rune()
    {
        switch(E_Rune)
        {
            case Rune.RUNE1:
                UI.RuneImgReset(E_Rune);
                break;
            case Rune.RUNE2:
                UI.RuneImgReset(E_Rune);
                break;
            case Rune.RUNE3:
                UI.RuneImgReset(E_Rune);
                break;
        }
    }
    public void RuneMount_Closer()
    {
        switch (E_RM)
        {
            case E_R_M.RM1:
                UI.Closer(UI.UIs.LM_1);
                break;
            case E_R_M.RM2:
                UI.Closer(UI.UIs.LM_2);
                break;
            case E_R_M.RM3:
                UI.Closer(UI.UIs.LM_3);
                break;
        }
    }
    public void RuneCase_Closer()
    {
        switch (E_Rune)
        {
            case Rune.RUNE1:
                UI.Closer(UI.UIs.Rune1_case);
                break;
            case Rune.RUNE2:
                UI.Closer(UI.UIs.Rune2_case);
                break;
            case Rune.RUNE3:
                UI.Closer(UI.UIs.Rune3_case);
                break;
        }
    }
    public void RuneCaseBt()
    {
        switch(E_Rune)
        {
            case Rune.RUNE1:
                UI.SelecteUIs(UI.UIs.Rune1_case);
                break;
            case Rune.RUNE2:
                UI.SelecteUIs(UI.UIs.Rune2_case);
                break;
            case Rune.RUNE3:
                UI.SelecteUIs(UI.UIs.Rune3_case);
                break;
        }
    }
    public void LoonMounting()
    
    {
        switch(E_Rune)
        {
            case Rune.RUNE1:
                UI.SetRuneImg(E_Rune);
                m_cGameManager.LoonMounting(ItemManager.EItem.VITALITY);
                break;
            case Rune.RUNE2:
                UI.SetRuneImg(E_Rune);
                m_cGameManager.LoonMounting(ItemManager.EItem.ONSLAUGHT);
                break;
            case Rune.RUNE3:
                UI.SetRuneImg(E_Rune);
                m_cGameManager.LoonMounting(ItemManager.EItem.PATRONAGE);
                break;
        }
    }
    public void Quest()
    {
        UI.SelecteUIs(UI.UIs.Quest);
    }
    public void Quest_Info()
    {
        UI.SelecteUIs(UI.UIs.Quest_Info);
    }
    public void QuestCloser()
    {
        UI.Closer(UI.UIs.Quest);
    }
    public void Quest_InfoCloser()
    {
        UI.Closer(UI.UIs.Quest_Info);
    }
}
