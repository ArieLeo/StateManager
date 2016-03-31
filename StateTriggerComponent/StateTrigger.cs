// Copyright (c) 2015 Bartlomiej Wolk (bartlomiejwolk@gmail.com)
//  
// This file is part of the StateTrigger extension for Unity.
// Licensed under the MIT license. See LICENSE file in the project root folder.

using StateManagerEx;
using UnityEngine;

namespace StateTriggerEx {

    public sealed class StateTrigger : MonoBehaviour {

        #region CONSTANTS

        public const string Version = "v0.1.0";
        public const string Extension = "StateTrigger";

        #endregion CONSTANTS

        #region DELEGATES
        #endregion DELEGATES

        #region EVENTS
        #endregion EVENTS

        #region FIELDS

#pragma warning disable 0414
        /// <summary>
        ///     Allows identify component in the scene file when reading it with
        ///     text editor.
        /// </summary>
        [SerializeField]
        private string componentName = "StateTrigger";
#pragma warning restore0414

        #endregion FIELDS

        #region INSPECTOR FIELDS

        [SerializeField]
        private string description = "Description";

        [SerializeField]
        private LookupType lookupType;

        [SerializeField]
        private string stateToActivate;

        [SerializeField]
        private StateManager stateManager;

        #endregion INSPECTOR FIELDS

        #region PROPERTIES

        /// <summary>
        ///     Optional text to describe purpose of this instance of the component.
        /// </summary>
        public string Description {
            get { return description; }
            set { description = value; }
        }

        public LookupType LookupType {
            get { return lookupType; }
            set { lookupType = value; }
        }

        public string StateToActivate {
            get { return stateToActivate; }
            set { stateToActivate = value; }
        }

        public StateManager StateManager {
            get { return stateManager; }
            set { stateManager = value; }
        }

        #endregion PROPERTIES

        #region UNITY MESSAGES

        private void Awake() { }

        private void FixedUpdate() { }

        private void LateUpdate() { }

        private void OnEnable() { }

        private void Reset() { }

        private void Start() { }

        private void Update() { }

        private void OnValidate() { }

        private void OnDisable() { }

        private void OnDestroy() { }

        #endregion UNITY MESSAGES

        #region EVENT INVOCATORS
        #endregion INVOCATORS

        #region EVENT HANDLERS
        #endregion EVENT HANDLERS

        #region METHODS

        private StateManager FindStateManagerComponent(GameObject other) {
            StateManager stateManager = null;

            switch (LookupType) {
                case LookupType.Parent:
                    stateManager =
                        other.GetComponentInParent<StateManager>();

                    break;
                case LookupType.Children:
                    stateManager =
                        other.GetComponentInChildren<StateManager>();

                    break;
                case LookupType.ParentAndChildren:
                    stateManager =
                        other.GetComponentInParent<StateManager>();

                    if (stateManager != null) break;

                    stateManager =
                        other.GetComponentInChildren<StateManager>();

                    break;
            }

            return stateManager;
        }

        public void ActivateState(GameObject other) {
            var stateManager = FindStateManagerComponent(other);

            if (stateManager == null) return;

            stateManager.ActivateState(StateToActivate);
        }

        public void ActivateState(RaycastHit hitInfo) {
            var targetGO = hitInfo.transform.gameObject;
            var stateManager = FindStateManagerComponent(targetGO);

            if (stateManager == null) return;

            stateManager.ActivateState(StateToActivate);
        }

        public void ActivateState() {
            if (stateManager == null) {
                return;
            }

            stateManager.ActivateState(StateToActivate);
        }

        #endregion METHODS

    }

}