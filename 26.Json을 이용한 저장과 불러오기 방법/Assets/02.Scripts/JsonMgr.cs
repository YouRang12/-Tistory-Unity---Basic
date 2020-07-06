using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;

public class Item
{
    public int ID;
    public string Name;
    public string Dis;

    public Item(int id, string name, string dis)
    {
        ID = id;
        Name = name;
        Dis = dis;
    }
}

public class JsonMgr : MonoBehaviour {

    public List<Item> ItemList = new List<Item>();

    public void Save()
    {
        Debug.Log("저장하기");

        JsonData ItemJson = JsonMapper.ToJson(ItemList);

        File.WriteAllText(Application.dataPath 
                            + "/ItemData.json"
                            , ItemJson.ToString());
    }

    public void Load()
    {
        Debug.Log("불러오기");

        string Jsonstring = File.ReadAllText(Application.dataPath
                                                + "/Resources/ItemData.json");
        Debug.Log(Jsonstring);

        JsonData itemData = JsonMapper.ToObject(Jsonstring);

        for(int i = 0; i < itemData.Count; i++)
        {
            Debug.Log(itemData[i]["ID"].ToString());
            Debug.Log(itemData[i]["Name"].ToString());
            Debug.Log(itemData[i]["Dis"].ToString());

        }
    }
}
