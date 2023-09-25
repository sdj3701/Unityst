using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//������ �޴� ���
using UnityEditor;
//�� ��ȯ
using UnityEditor.SceneManagement;


public class Menu2023 : MonoBehaviour
{
    [MenuItem("Menu2023/Clear PlayerPrefs")]
    private static void Clear_PlayerPrefsAll()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("Clear PlayerPrefs");
    }

    //Ȯ��
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
        //�����Ͱ� ����ǰ� �������� ���¿��� �����ϴ� ��
        EditorSceneManager.OpenScene(AssetDatabase.GetAssetPath(selected));

    }
}
