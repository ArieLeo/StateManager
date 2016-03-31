// Copyright (c) 2015 Bartlomiej Wolk (bartlomiejwolk@gmail.com)
//  
// This file is part of the StateManager extension for Unity.
// Licensed under the MIT license. See LICENSE file in the project root folder.

using System.Collections.Generic;
using UnityEngine;

namespace StateManagerEx {

    public sealed class StateManager : MonoBehaviour {

        #region CONSTANTS

        public const string Version = "v0.1.0";
        public const string Extension = "StateManager";

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
        private string componentName = "StateManager";
#pragma warning restore0414

        #endregion FIELDS

        #region INSPECTOR FIELDS

        [SerializeField]
        private string description = "Description";

        [SerializeField]
        private string currentState;

        [SerializeField]
        private List<State> states;

        #endregion INSPECTOR FIELDS

        #region PROPERTIES

        /// <summary>
        ///     Optional text to describe purpose of this instance of the component.
        /// </summary>
        public string Description {
            get { return description; }
            set { description = value; }
        }

        public string CurrentState {
            get { return currentState; }
            set { currentState = value; }
        }

        /// <summary>
        /// List of states managed by the <c>StateManager</c>.
        /// </summary>
        public List<State> States {
            get { return states; }
            set { states = value; }
        }

        #endregion PROPERTIES

        #region UNITY MESSAGES

        private void Awake() {
            ActivateInitialState();
        }
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
        /// <summary>
        /// Activate the first state in the state list.
        /// </summary>
        private void ActivateInitialState() {
            // Activate state.
            States[0].ActivateState();

            // Display current state name.
            CurrentState = States[0].Name;
        }

        /// <summary>
        /// Activate state by its name.
        /// </summary>
        /// <param name="stateName">State name.</param>
        public void ActivateState(string stateName) {
            foreach (var state in States) {
                if (state.Name == stateName) {
                    state.ActivateState();
                    // Update current state name.
                    CurrentState = state.Name;
                }
            }
        }

        #endregion METHODS

    }

}