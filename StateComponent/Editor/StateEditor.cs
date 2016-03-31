// Copyright (c) 2015 Bartlomiej Wolk (bartlomiejwolk@gmail.com)
//  
// This file is part of the StateManager extension for Unity.
// Licensed under the MIT license. See LICENSE file in the project root folder.

using UnityEditor;
using UnityEngine;

namespace StateManagerEx {

    [CustomEditor(typeof(State))]
    [CanEditMultipleObjects]
    public sealed class StateEditor : Editor {
        #region FIELDS

        private State Script { get; set; }

        #endregion FIELDS

        #region SERIALIZED PROPERTIES

        private SerializedProperty description;
        private SerializedProperty name;
        private SerializedProperty callbacks;

        #endregion SERIALIZED PROPERTIES

        #region UNITY MESSAGES

        public override void OnInspectorGUI() {
            serializedObject.Update();

            DrawVersionLabel();
            DrawDescriptionTextArea();

            EditorGUILayout.Space();

            DrawNameField();
            DrawCallbacksControl();

            serializedObject.ApplyModifiedProperties();
        }
        private void OnEnable() {
            Script = (State)target;

            description = serializedObject.FindProperty("description");
            name = serializedObject.FindProperty("name");
            callbacks = serializedObject.FindProperty("callbacks");
        }

        #endregion UNITY MESSAGES

        #region INSPECTOR CONTROLS
        private void DrawNameField() {
            EditorGUILayout.PropertyField(
                name,
                new GUIContent(
                    "State Name",
                    ""));
        }

        private void DrawCallbacksControl() {
            EditorGUILayout.PropertyField(
                callbacks,
                new GUIContent(
                    "Callbacks",
                    "Callbacks to be executed when this state is activated."));
        }


        private void DrawVersionLabel() {
            EditorGUILayout.LabelField(
                string.Format(
                    "{0} ({1})",
                    State.Version,
                    State.Extension));
        }

        private void DrawDescriptionTextArea() {
            description.stringValue = EditorGUILayout.TextArea(
                description.stringValue);
        }

        #endregion INSPECTOR

        #region METHODS

        [MenuItem("Component/Component Framework/State Manager/State")]
        private static void AddEntryToComponentMenu() {
            if (Selection.activeGameObject != null) {
                Selection.activeGameObject.AddComponent(typeof(State));
            }
        }

        #endregion METHODS
    }

}