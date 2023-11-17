using UnityEditor;
using System.Linq;

[CustomEditor(typeof(GameManager))]
public class GameManagerEditor : Editor
{
    public bool showFoldout;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        GameManager fsm = (GameManager)target;

        EditorGUILayout.Space(30);
        EditorGUILayout.LabelField("State Machine");

        if (fsm.stateMachine == null) return;
        if(fsm.stateMachine.currentState != null)
            EditorGUILayout.LabelField("Current State: ", fsm.stateMachine.currentState.ToString());

        showFoldout = EditorGUILayout.Foldout(showFoldout, "Available States");

        if (showFoldout)
        {
            if(fsm.stateMachine.dictionaryStates != null)
            {

                var keys = fsm.stateMachine.dictionaryStates.Keys.ToArray();
                var vals = fsm.stateMachine.dictionaryStates.Values.ToArray();

                for(int i = 0; i < keys.Length; i++)
                {
                    EditorGUILayout.LabelField(string.Format("{0} :: {1}", keys[i], vals[i]));
                }

            }
        }
    }
}
