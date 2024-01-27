// using System.Collections.Generic;
// using System.IO;
// using UnityEditor;
// using UnityEngine;
// using LitJson;
//
// public class Settings
// {
//     public string Language;
//     public float Bgm;
//     public float musicEffect;
// }
//
// public class UserSettingsList
// {
//     public Dictionary<string, string> dictionary = new Dictionary<string, string>();
// }
//
// public class UserSettings  {
//
//     Settings settings = new Settings();
//     public UserSettingsList UserSettingsList = new UserSettingsList();
//
//     private static UserSettings instance;
//
//     public static UserSettings GetInstance()
//     {
//         if (instance == null)
//         {
//             Debug.Log("UIManager is not exist");
//             return instance;
//         }
//         else
//         {
//             return instance;
//         }
//
//     }
//
//     public UserSettings()
//     {
//         instance = this;
//         LoadSettings();
//     }
//
//     /// <summary>
//     /// 保存JSON数据到本地的方法
//     /// </summary>
//     /// <param name="player">要保存的对象</param>
//     public void Save(Settings player)
//     {
//         //打包后Resources文件夹不能存储文件，如需打包后使用自行更换目录
//         string filePath = Application.persistentDataPath + "/game_SaveData/JsonUserSettings.json";
//
//         //判断如果不存在保存文件数据
//
//         
//         //更新值
//         {
//             UserSettingsList.dictionary["Language"] = player.Language;
//             UserSettingsList.dictionary["Bgm"] = player.Bgm.ToString();
//             UserSettingsList.dictionary["musicEffect"] = player.musicEffect.ToString();
//         }
//        
//         //找到当前路径
//         FileInfo file = new FileInfo(filePath);
//         //判断有没有文件，有则打开文件，，没有创建后打开文件
//         StreamWriter sw = file.CreateText();
//         //ToJson接口将你的列表类传进去，，并自动转换为string类型
//         string json = JsonMapper.ToJson(UserSettingsList.dictionary);
//         //将转换好的字符串存进文件，
//         sw.WriteLine(json);
//         //注意释放资源
//         sw.Close();
//         sw.Dispose();
//         
//
//     }
//     
//     /// <summary>
//     /// 读取保存数据的方法
//     /// </summary>
//     public void LoadSettings()
//     {
//         string datePath = Application.persistentDataPath + "/game_SaveData/JsonUserSettings.json";
//         Debug.Log(Application.persistentDataPath + "/game_SaveData/JsonUserSettings.json");
//         if (!File.Exists(datePath))
//         {
//             Debug.Log("------未找到文件------");
//             UserSettingsList.dictionary.Add("Language", "chineseSimple");
//             UserSettingsList.dictionary.Add("Bgm", "0.5");
//             UserSettingsList.dictionary.Add("musicEffect", "0.5");
//             //创建游戏存储目录文件
//             Directory.CreateDirectory(Application.persistentDataPath + "/game_SaveData");
//             //找到当前路径
//             FileInfo file = new FileInfo(datePath);
//             //判断有没有文件，有则打开文件，，没有创建后打开文件
//             StreamWriter sw = file.CreateText();
//             //ToJson接口将你的列表类传进去，，并自动转换为string类型
//             string json = JsonMapper.ToJson(UserSettingsList.dictionary);
//             //将转换好的字符串存进文件，
//             sw.WriteLine(json);
//             //注意释放资源
//             sw.Close();
//             sw.Dispose();
//         }
//         
//         StreamReader sr = new StreamReader(datePath);//创建读取流;
//         string jsonStr = sr.ReadToEnd();//使用方法ReadToEnd（）遍历的到保存的内容
//         sr.Close();
//         UserSettingsList.dictionary = JsonMapper.ToObject<Dictionary<string, string>>(jsonStr);//使用JsonMapper将遍历得到的jsonStr转换成Date对象
//         settings.Language = UserSettingsList.dictionary["Language"];
//         settings.Bgm = float.Parse(UserSettingsList.dictionary["Bgm"]);
//         settings.musicEffect = float.Parse(UserSettingsList.dictionary["musicEffect"]);
//         
//
//     }
//
//     public string GetSetting(string key)
//     {
//         LoadSettings();
//         return UserSettingsList.dictionary[key];
//     }
//
//     public void SetSettting(string key, string value)
//     {
//         settings.Language = UserSettingsList.dictionary["Language"];
//         settings.Bgm = float.Parse(UserSettingsList.dictionary["Bgm"]);
//         settings.musicEffect = float.Parse(UserSettingsList.dictionary["musicEffect"]);
//         if(key == "Language") 
//             settings.Language = value;
//         if (key == "Bgm")
//             settings.Bgm = float.Parse(value);
//         if (key == "musicEffect")
//             settings.musicEffect = float.Parse(value);
//         Save(settings);
//     }
// 	
// }