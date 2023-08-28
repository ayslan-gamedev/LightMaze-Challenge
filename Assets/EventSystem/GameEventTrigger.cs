using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class GameEventTrigger : MonoBehaviour
{
    public UnityEvent OnStartEvent;

    public UnityEvent OnTriggerEnterEvent;

    public UnityEvent OnTriggerStayEvent;

    public UnityEvent OnTriggerExitEvent;





    private void CallEvent(UnityEvent @event)
    {
        @event.Invoke();
    }




}

public class GameEventInspector : Editor 
{
    public override void OnInspectorGUI()
    {
        GameEventTrigger minhaInstancia = (GameEventTrigger)target;

        // Personalize o Inspector da classe MinhaClasse aqui
        EditorGUILayout.LabelField("Meu Campo Personalizado");

        if(GUILayout.Button("Meu Bot�o Personalizado"))
        {
            // L�gica para quando o bot�o for pressionado
        }

        // Chame o OnInspectorGUI padr�o para manter o comportamento padr�o do Inspector
        DrawDefaultInspector();
    }

}



//using System;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEditor;
//using UnityEngine.Events;

//[ExecuteInEditMode]
//public class GameEventTrigger : MonoBehaviour
//{
//    [Serializable]
//    public struct GameEvent
//    {
//        public string eventName;      // Nome do evento personalizado.
//        public UnityEvent onEvent;    // Evento Unity associado a este evento personalizado.
//    }

//    public List<GameEvent> customEvents;

//    [Header("Configura��es de Colis�o")]
//    public List<string> playerTags = new List<string>();  // Lista de tags do jogador dispon�veis para escolha.
//    public int selectedTagIndex = 0; // �ndice da tag selecionada na lista.

//    static GameEventTrigger()
//    {
//        // Carregue as tags dispon�veis ao inicializar no modo de edi��o.
//        LoadAvailableTags();
//    }

//    private void OnTriggerEnter(Collider other)
//    {
//        if(selectedTagIndex >= 0 && selectedTagIndex < playerTags.Count)
//        {
//            string selectedTag = playerTags[selectedTagIndex];
//            // Verifique se a colis�o envolve um objeto com a tag selecionada.
//            if(other.CompareTag(selectedTag))
//            {
//                // Chamamos um evento personalizado quando ocorre uma colis�o.
//                TriggerEvent("PlayerEnterEvent");
//            }
//        }
//    }

//    private void OnTriggerExit(Collider other)
//    {
//        if(selectedTagIndex >= 0 && selectedTagIndex < playerTags.Count)
//        {
//            string selectedTag = playerTags[selectedTagIndex];
//            // Verifique se a colis�o envolve um objeto com a tag selecionada.
//            if(other.CompareTag(selectedTag))
//            {
//                // Chamamos um evento personalizado quando a colis�o com o jogador termina.
//                TriggerEvent("PlayerExitEvent");
//            }
//        }
//    }

//    /// <summary>
//    /// Triggers a custom event by name.
//    /// </summary>
//    /// <param name="eventName">O nome do evento a ser acionado.</param>
//    public void TriggerEvent(string eventName)
//    {
//        // Iterar atrav�s da lista de eventos personalizados.
//        foreach(var customEvent in customEvents)
//        {
//            if(customEvent.eventName == eventName)
//            {
//                // Invoca o evento Unity associado ao evento personalizado.
//                customEvent.onEvent.Invoke();
//                break;
//            }
//        }
//    }

//    // M�todo para carregar as tags dispon�veis no Unity Editor.
//    [InitializeOnLoadMethod]
//    private static void LoadAvailableTags()
//    {
//        // Obtenha as tags dispon�veis usando UnityEditorInternal.InternalEditorUtility.tags.
//        string[] tags = UnityEditorInternal.InternalEditorUtility.tags;

//        // Atualize a lista de tags no GameEventTrigger.
//        Instance.playerTags.Clear();
//        Instance.playerTags.AddRange(tags);
//    }

//    // Obt�m uma inst�ncia do GameEventTrigger. Substitua pelo objeto GameEventTrigger em seu cen�rio.
//    private static GameEventTrigger Instance
//    {
//        get
//        {
//            GameEventTrigger instance = FindObjectOfType<GameEventTrigger>();
//            if(instance == null)
//            {
//                Debug.LogError("GameEventTrigger n�o encontrado no cen�rio. Certifique-se de que existe um objeto GameEventTrigger.");
//            }
//            return instance;
//        }
//    }
//}
