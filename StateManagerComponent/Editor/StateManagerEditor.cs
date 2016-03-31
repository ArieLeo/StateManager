// Copyright (c) 2015 Bartlomiej Wolk (bartlomiejwolk@gmail.com)
//  
// This file is part of the StateManager extension for Unity.
// Licensed under the MIT license. See LICENSE file in the project root folder.

using UnityEditor;
using UnityEngine;
using StateManagerEx.ReorderableList;

namespace StateManagerEx {

    [CustomEditor(typeof(StateManager))]
    [CanEditMultipleObjects]
    public sealed class StateManagerEditor : Editor {
        #region FIELDS

        private StateManager Script { get; set; }

        #endregion FIELDS

        #region SERIALIZED PROPERTIES

        private SerializedProperty description;
        private SerializedProperty currentState;
        private SerializedProperty states;

        #endregion SERIALIZED PROPERTIES

        #region UNITY MESSAGES

        public override void OnInspectorGUI() {
            serializedObject.Update();

            DrawVersionLabel();
            DrawDescriptionTextArea();

            EditorGUILayout.Space();

            DrawCurrentStateField();
            DrawStatesList();

            serializedObject.ApplyModifiedProperties();
        }
        private void OnEnable() {
            Script = (StateManager)target;

            description = serializedObject.FindProperty("description");
            currentState = serializedObject.FindProperty("currentState");
            states = serializedObject.FindProperty("states");
        }

        #endregion UNITY MESSAGES

        #region INSPECTOR CONTROLS
        private void DrawCurrentStateField() {
            EditorGUILayout.LabelField(
                new GUIContent(
                    "Current State: " + currentState.stringValue,
                    "State that was last activated."));
        }

        private void DrawStatesList() {
            ReorderableListGUI.Title("States");
            ReorderableListGUI.ListField(states);
        }


        private void DrawVersionLabel() {
            EditorGUILayout.LabelField(
                string.Format(
                    "{0} ({1})",
                    StateManager.Version,
                    StateManager.Extension));
        }

        private void DrawDescriptionTextArea() {
            description.stringValue = EditorGUILayout.TextArea(
                description.stringValue);
        }

        #endregion INSPECTOR

        #region METHODS

        [MenuItem("Component/Component Framework/State Manager/StateManager")]
        private static void AddEntryToComponentMenu() {
            if (Selection.activeGameObject != null) {
                Selection.activeGameObject.AddComponent(typeof(StateManager));
            }
        }

        #endregion METHODS
    }

}