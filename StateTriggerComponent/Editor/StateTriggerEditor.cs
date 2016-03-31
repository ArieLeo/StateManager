// Copyright (c) 2015 Bartlomiej Wolk (bartlomiejwolk@gmail.com)
//  
// This file is part of the StateTrigger extension for Unity.
// Licensed under the MIT license. See LICENSE file in the project root folder.

using UnityEditor;
using UnityEngine;

namespace StateTriggerEx {

    [CustomEditor(typeof(StateTrigger))]
    [CanEditMultipleObjects]
    public sealed class StateTriggerEditor : Editor {
        #region FIELDS

        private StateTrigger Script { get; set; }

        #endregion FIELDS

        #region SERIALIZED PROPERTIES

        private SerializedProperty description;
        private SerializedProperty stateToActivate;
        private SerializedProperty lookupType;
        private SerializedProperty stateManager;

        #endregion SERIALIZED PROPERTIES

        #region UNITY MESSAGES

        public override void OnInspectorGUI() {
            serializedObject.Update();

            DrawVersionLabel();
            DrawDescriptionTextArea();

            EditorGUILayout.Space();

            DrawStateManagerGoField();
            DrawStateToActivateField();
            DrawLookupTypeDropdown();

            serializedObject.ApplyModifiedProperties();
        }
        private void OnEnable() {
            Script = (StateTrigger)target;

            description = serializedObject.FindProperty("description");
            stateToActivate = serializedObject.FindProperty("stateToActivate");
            lookupType = serializedObject.FindProperty("lookupType");
            stateManager = serializedObject.FindProperty("stateManager");
        }

        #endregion UNITY MESSAGES

        #region INSPECTOR CONTROLS
        private void DrawStateManagerGoField() {
            EditorGUILayout.PropertyField(
                stateManager,
                new GUIContent(
                    "State Manager",
                    "Reference to the StateManager component."));
        }

        private void DrawLookupTypeDropdown() {
            EditorGUILayout.PropertyField(
                lookupType,
                new GUIContent(
                    "Lookup Type",
                    "Where to look for StateManager component in the " +
                    "target game object."));
        }

        private void DrawStateToActivateField() {
            EditorGUILayout.PropertyField(
                stateToActivate,
                new GUIContent(
                    "State Name",
                    "Name of the state to activate."));
        }


        private void DrawVersionLabel() {
            EditorGUILayout.LabelField(
                string.Format(
                    "{0} ({1})",
                    StateTrigger.Version,
                    StateTrigger.Extension));
        }

        private void DrawDescriptionTextArea() {
            description.stringValue = EditorGUILayout.TextArea(
                description.stringValue);
        }

        #endregion INSPECTOR

        #region METHODS

        [MenuItem("Component/Component Framework/State Manager/StateTrigger")]
        private static void AddEntryToComponentMenu() {
            if (Selection.activeGameObject != null) {
                Selection.activeGameObject.AddComponent(typeof(StateTrigger));
            }
        }

        #endregion METHODS
    }

}
