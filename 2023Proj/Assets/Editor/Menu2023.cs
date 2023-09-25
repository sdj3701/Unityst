using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//에디터 메뉴 사용
using UnityEditor;
//씬 전환
using UnityEditor.SceneManagement;


public class Menu2023 : MonoBehaviour
{
    [MenuItem("Menu2023/Clear PlayerPrefs")]
    private static void Clear_PlayerPrefsAll()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("Clear PlayerPrefs");
    }

    //확장
    [MenuItem("Menu2023/Submenu/Select")]
    private static void subMenu_Select()
    {
        Debug.Log("Sub Menu 1 - Select");
    }
    /*
     *  % - Ctrl
     *  # - Shift
     *  & - Alt
     */
    [MenuItem("Menu2023/Submenu/Hotkey Test 1 %#[")]
    private static void SubMenu_Hotkey_1()
    {
        Debug.Log("Hotkey Test :  Ctrl + SHift + [");
    }
    [MenuItem("Assets/Load Selected Scene")]
    private static void LoadSelectedScene()
    {
        var selected = Selection.activeObject;

        if (EditorApplication.isPlaying)
            EditorSceneManager.LoadScene(AssetDatabase.GetAssetPath(selected));
        else
            EditorSceneManager.OpenScene(AssetDatabase.GetAssetPath(selected));
        //에디터가 실행되고 있지않은 상태에서 실행하는 것
        EditorSceneManager.OpenScene(AssetDatabase.GetAssetPath(selected));

    }
}
