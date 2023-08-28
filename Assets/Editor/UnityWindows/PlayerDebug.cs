#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;


public class PlayerDebug : EditorWindow
{

    [MenuItem("Debug/PlayerDebug")]
    public static void MostrarJanela()
    {
        // Crie uma instância da sua janela
        PlayerDebug window = (PlayerDebug)GetWindow(typeof(PlayerDebug));
        window.titleContent = new GUIContent("PlayerDebug"); // Defina o título da janela
        window.Show();

    }

    //void OnGUI()
    //{


    //    //if(playerMovement != null)
    //    //{
    //    //    playerAtributts = playerMovement.PlayerAtributts; // Obtenha as constantes do PlayerMovement

    //    //    GUILayout.Label("Informações do Jogador:", EditorStyles.boldLabel);

    //    //    // Mostrar a velocidade atual
    //    //    GUILayout.Label("Velocidade Atual: " + playerMovement.CurrentSpeed);

    //    //    // Mostrar as constantes
    //    //    GUILayout.Label("Constantes:");
    //    //    GUILayout.Label("Velocidade: " + playerAtributts.speed);
    //    //    GUILayout.Label("Aceleração: " + playerAtributts.aceletarion);
    //    //    GUILayout.Label("Desaceleração: " + playerAtributts.slowdown);
    //    //}
    //    //else
    //    //{
    //    //    GUILayout.Label("Script PlayerMovement não encontrado na cena.", EditorStyles.boldLabel);
    //    //    playerMovement = FindObjectOfType<PlayerMovement>(); // Procure o objeto com o script PlayerMovement
    //    //}
    //}

}
#endif