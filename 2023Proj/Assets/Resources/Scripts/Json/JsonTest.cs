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

        playerinfoList.Add(new PlayerInfo(1, "�̸�1", 1001));
        playerinfoList.Add(new PlayerInfo(1, "�̸�2", 1002));
        playerinfoList.Add(new PlayerInfo(1, "�̸�3", 1003));
        playerinfoList.Add(new PlayerInfo(1, "�̸�4", 1004));
        playerinfoList.Add(new PlayerInfo(1, "�̸�5", 1005));

        //Json�����͸� ��ü�� �����ϰų� ��ü�� Json�������� ����ȭ�ϴ� �� ���Ǵ� Ŭ����
        JsonData infoJson = JsonMapper.ToJson(playerinfoList);
        //�ؽ�Ʈ�� �ۼ��ϰų� ���� �ؽ�Ʈ�� ������
        File.WriteAllText(Application.dataPath + "/Resources/Data/PlayerInfoData.json", infoJson.ToString());

    }

    public void LoadPlayerInfo()
    {
        Debug.Log("LoadPlayerInfo()");
        if (File.Exists(Application.dataPath + "/Resources/Data/PlayerInfoData.json"))
        {
            //������ �о���� �޼���
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
 *  ������ �����ϱ� �� Ȯ�� ����
 *  ������ ������ ����� �� �����
 *  �����͸� �ҷ��ö� �ڷ�ƾ���� �ð��� �������� �ε� �ٸ� ������༭ �ε� �ɶ����� �˷��ָ� �ȴ�.
 *  public ���� ���ϸ��� ������ ������ �ȵɼ��� ���� ****
 * 
 */

#endregion