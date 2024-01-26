using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public class StartGameShortcut : MonoBehaviour
{ 
    [MenuItem("GameTools/Start Game %g")] //Ctrl+G  
    public static void StartGame()
    {
        int option = EditorUtility.DisplayDialogComplex("Start game",
            "Do you want to run game?", "Save and Go", "Discard and Go", "Cancel");
        if(option == 0)
        {
            AssetDatabase.SaveAssets();
            EditorSceneManager.SaveOpenScenes();
        }
        if (option == 0 || option == 1)
        {
            EditorApplication.isPaused = false;
            EditorApplication.isPlaying = false;
            EditorSceneManager.OpenScene("Assets/Scenes/Scene1.unity");
            EditorApplication.isPlaying = true;   
        }
    }
}
