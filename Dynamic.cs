using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dynamic : MonoBehaviour {
    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        InputKey();
    }
   public void InputKey()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                  if(hit.collider.name=="Monster1")
                  {
                    Dungeon.e_monster = Dungeon.Monster.Monster1;
                  }
                  else if (hit.collider.name == "Monster2")
                  {
                    Dungeon.e_monster = Dungeon.Monster.Monster2;
                  }
                  else if (hit.collider.name == "Monster3")
                  {
                    Dungeon.e_monster = Dungeon.Monster.Monster3;
                  }
            }
        }


        if (Input.GetKeyDown(KeyCode.Space))
            Dungeon.m_bAttack = true;
        else
            Dungeon.m_bAttack = false;
        if (Input.GetKeyDown(KeyCode.LeftShift))
            Dungeon.m_bskillkey = true;
        else
            Dungeon.m_bskillkey = false;
    }
   
}
