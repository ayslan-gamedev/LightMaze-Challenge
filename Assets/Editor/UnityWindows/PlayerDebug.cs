#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;


public class PlayerDebug : EditorWindow
{

    [MenuItem("Debug/PlayerDebug")]
    public static void MostrarJanela()
    {
        // Crie uma inst�ncia da sua janela
        PlayerDebug window = (PlayerDebug)GetWindow(typeof(PlayerDebug));
        window.titleContent = new GUIContent("PlayerDebug"); // Defina o t�tulo da janela
        window.Show();

    }

    //void OnGUI()
    //{


    //    //if(playerMovement != null)
    //    //{
    //    //    playerAtributts = playerMovement.PlayerAtributts; // Obtenha as constantes do PlayerMovement

    //    //    GUILayout.Label("Informa��es do Jogador:", EditorStyles.boldLabel);

    //    //    // Mostrar a velocidade atual
    //    //    GUILayout.Label("Velocidade Atual: " + playerMovement.CurrentSpeed);

    //    //    // Mostrar as constantes
    //    //    GUILayout.Label("Constantes:");
    //    //    GUILayout.Label("Velocidade: " + playerAtributts.speed);
    //    //    GUILayout.Label("Acelera��o: " + playerAtributts.aceletarion);
    //    //    GUILayout.Label("Desacelera��o: " + playerAtributts.slowdown);
    //    //}
    //    //else
    //    //{
    //    //    GUILayout.Label("Script PlayerMovement n�o encontrado na cena.", EditorStyles.boldLabel);
    //    //    playerMovement = FindObjectOfType<PlayerMovement>(); // Procure o objeto com o script PlayerMovement
    //    //}
    //}

}
#endif