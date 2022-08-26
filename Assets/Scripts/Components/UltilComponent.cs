using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UltilComponent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadAgain()
    {
        UltilComponent.writeData(string.Empty);
        SceneManager.LoadScene(ConstantsComp.LEVEL1);
    }

    public void LoadMap2()
    {
        UltilComponent.writeData(string.Empty);
        SceneManager.LoadScene(ConstantsComp.LEVEL2);
    }

    public void LoadStartUp()
    {
        SceneManager.LoadScene(ConstantsComp.STARTUP);
    }

    public void Exit()
    {
        SceneManager.LoadScene("MenuMain");
    }

    public void Resume()
    {
        if (!string.IsNullOrEmpty(ReadData()) && int.Parse(ReadData().Split('|')[2]) > 0)
        {
            SceneManager.LoadScene(ReadData().Split('|')[0]);
        }
        else
        {
            SceneManager.LoadScene(ConstantsComp.LEVEL1);
        }
    }

    public void Quit()
    {
        Application.Quit();
    }

    public static void writeData(string input)
    {
        // Định dạng dữ liệu: Màn chơi|Nhân vật|Số mạng|Số chìa khóa|Vị trí x|Vị trí y|Vị trí z
        var filename = "data.txt";
        string contentfile = input;
        var fullpath = Path.Combine("Data", filename);
        File.WriteAllText(filename, Base64Encode(contentfile));
    }

    public static string ReadData()
    {
        string fullpath = "data.txt";
        string s = File.ReadAllText(fullpath);
        return Base64Decode(s);
    }

    private static string Base64Encode(string input)
    {
        return Convert.ToBase64String(Encoding.UTF8.GetBytes(input));
    }

    private static string Base64Decode(string input)
    {
        byte[] decode = Convert.FromBase64String(input);
        return ASCIIEncoding.UTF8.GetString(decode);
    }
}
