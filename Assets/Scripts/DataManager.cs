using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class DataManager : MonoBehaviour
{
    static GameObject container;

    static DataManager instance;

    public static DataManager Instance
    {
        get
        {
            if (!instance)
            {
                container = new GameObject();
                container.name = "DataManager";
                instance = container.AddComponent(typeof(DataManager)) as DataManager;
                DontDestroyOnLoad(container);
            }
            return instance;
        }
    }

    string GameDataFileName = "GameData.json";

    public Data data = new Data();

    public void LoadGameData()
    {
        string filePath = Application.persistentDataPath + "/" + GameDataFileName;

        //����� ������ �����Ѵٸ�
        if(File.Exists(filePath))
        {
            //����� ���� �о���� Json�� Ŭ���� �������� ��ȯ�ؼ� �Ҵ�
            string FromJsonData = File.ReadAllText(filePath);
            data = JsonUtility.FromJson<Data>(FromJsonData);
        }
    }
    public void SaveGameData()
    {
        //Ŭ������ Json�������� ��ȯ
        string ToJsonData = JsonUtility.ToJson(data, true);
        string filePath = Application.persistentDataPath + "/" + GameDataFileName;

        //�̹� ����� ������ �ִٸ� ������, ���ٸ� ���θ���� ����
        File.WriteAllText(filePath, ToJsonData);
    }
}

