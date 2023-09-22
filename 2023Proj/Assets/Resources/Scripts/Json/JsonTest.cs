using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using LitJson;

public class PlayerInfo
{
    public int ID;
    public string Name;
    public double Gold;

    public PlayerInfo(int id, string name, double gold)
    {
        ID = id;
        Name = name;
        Gold = gold;
    }
}

public class JsonTest : MonoBehaviour
{
    public List<PlayerInfo> playerinfoList = new List<PlayerInfo>();

    void Start()
    {
        //SavePlayerInfo();
        LoadPlayerInfo();

    }

    public void SavePlayerInfo()
    {
        Debug.Log("SavePlayerInfo()");

        playerinfoList.Add(new PlayerInfo(1, "이름1", 1001));
        playerinfoList.Add(new PlayerInfo(1, "이름2", 1002));
        playerinfoList.Add(new PlayerInfo(1, "이름3", 1003));
        playerinfoList.Add(new PlayerInfo(1, "이름4", 1004));
        playerinfoList.Add(new PlayerInfo(1, "이름5", 1005));

        //Json데이터를 객체로 매핑하거난 객체를 Json형식으로 직렬화하는 데 사용되는 클래스
        JsonData infoJson = JsonMapper.ToJson(playerinfoList);
        //텍스트를 작성하거나 기존 텍스트를 덮어씌우기
        File.WriteAllText(Application.dataPath + "/Resources/Data/PlayerInfoData.json", infoJson.ToString());

    }

    public void LoadPlayerInfo()
    {
        Debug.Log("LoadPlayerInfo()");
        if (File.Exists(Application.dataPath + "/Resources/Data/PlayerInfoData.json"))
        {
            //파일을 읽어오는 메서드
            string jsonString = File.ReadAllText(Application.dataPath + "/Resources/Data/PlayerInfoData.json");
            Debug.Log(jsonString);

            JsonData playerData = JsonMapper.ToObject(jsonString);
            ParsingJsonPlayerInfo(playerData);
        }
    }

    private void ParsingJsonPlayerInfo(JsonData data)
    {
        Debug.Log("ParsingJsonPlayerInfo()");

        for(int i =0;i <data.Count;i++)
        {
            print(data[i]["ID"].ToString() + " , " + data[i]["Name"] + " , " + data[i]["Gold"]);

            int id = (int)data[i]["ID"];
            print(id.ToString());
            double gold = (double)data[i]["Gold"];
            print(gold.ToString());
        }
    }

    void Update()
    {
        
    }
}

#region
/*
 *  
 *  생성이 느리니까 잘 확인 하자
 *  가벼운 정보를 사용할 때 사용함
 *  데이터를 불러올때 코루틴으로 시간을 지연시켜 로딩 바를 출력해줘서 로드 될때까지 알려주면 된다.
 *  public 으로 안하면은 데이터 저장이 안될수도 있음 ****
 * 
 */

#endregion