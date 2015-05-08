using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WerewolfMgr : MonoBehaviour {
    public enum WereWolfRoles
    {
        Villiager,
        Werewolf,
        Witch,
        Girl,
        Hunter,
        Mayer,
        Idiot,
        LoveGod,
        HalfBlood,
        Gudian,
        Prophet
    }
    public List<int> roleList=new List<int>();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void InitGame(int playerCount)
    {
        roleList.Clear();
        List<int> sortedList = new List<int>();
        for (int i = playerCount-1; i >= 0; i--)
        {
            sortedList.Add(i);
        }
        for (int i = playerCount; i > 0; i--)
        {
            int index = Random.Range(0, sortedList.Count);
            roleList.Add(sortedList[index]);
            Debug.Log(sortedList[index]);
            sortedList.RemoveAt(index);
        }


    }
    public string GetRole(int index)
    {
        WereWolfRoles r = (WereWolfRoles)roleList[index];
        return r.ToString();
    }
}
