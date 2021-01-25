#nullable enable
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace HackedDesign
{
    public class GameManager : MonoBehaviour
    {
        public const string gameVersion = "1.0";

        [Header("Game")]
        [SerializeField] private Camera? mainCamera = null;
        [SerializeField] private Ship? playerShip = null;
        [SerializeField] private List<Ship> ships = null;
        [SerializeField] private MermaidPool mermaidPool = null;
        [SerializeField] private ProjectilePool projectilePool = null;

        [Header("UI")]
        [SerializeField] private UI.HudPresenter hudPanel = null;

        private IState currentState = new EmptyState();

#pragma warning disable CS8618
        public static GameManager Instance { get; private set; }
#pragma warning restore CS8618        

        public Camera? MainCamera { get { return mainCamera; } private set { mainCamera = value; } }
        public Ship? Player { get { return playerShip; } private set { playerShip = value; } }
        public List<Ship> Ships { get { return this.ships; }}
        public MermaidPool MermaidPool { get => mermaidPool; private set => mermaidPool = value; }
        public ProjectilePool ProjectilePool { get => projectilePool; private set => projectilePool = value; }

        public IState CurrentState
        {
            get
            {
                return this.currentState;
            }
            private set
            {
                this.currentState.End();

                this.currentState = value;

                this.currentState.Begin();
            }
        }

        

        private GameManager() => Instance = this;

        void Awake() => CheckBindings();
        void Start() => Initialization();

        void Update() => CurrentState?.Update();
        void LateUpdate() => CurrentState?.LateUpdate();
        void FixedUpdate() => CurrentState?.FixedUpdate();

        public void SetPlaying() => CurrentState = new PlayingState(this.ships, this.hudPanel);
        public void SetMainMenu() => CurrentState = new EmptyState();
        public void SetGameOverCrash() => CurrentState = new GameOverCrashState();
        public void SetGameWin() => CurrentState = new GameOverWinState();
        public void SetGameLose() => CurrentState = new GameOverLoseState();

        private void CheckBindings()
        {
            
        }

        private void Initialization()
        {
            SetPlaying();
        }        

        private void HideAllUI()
        {
            this.hudPanel.Hide();
            // this.startMenuPanel.Hide();
            // this.deadPanel.Hide();
            // this.dialogPanel.Hide();
            // this.missionPanel.Hide();
            // this.missionCompletePanel.Hide();
            // this.levelPanel.Hide();
            // this.gameOverPanel.Hide();
        }

    }

}