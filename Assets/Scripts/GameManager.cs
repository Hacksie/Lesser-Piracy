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
        [SerializeField] private PlayerController? player = null;
        [SerializeField] private List<Ship> ships = new List<Ship>();
        [SerializeField] private List<GameObject> cursors = new List<GameObject>();
        [SerializeField] private MermaidPool? mermaidPool = null;
        [SerializeField] private ProjectilePool? projectilePool = null;
        [SerializeField] private AudioSource? music = null;

        [Header("UI")]
        
        [SerializeField] private UI.HudPresenter? hudPanel = null;
        [SerializeField] private UI.MainMenuPresenter? mainMenuPanel = null;
        [SerializeField] private UI.CreditsPresenter? creditsPanel = null;
        [SerializeField] private UI.OptionsPresenter? optionsPanel = null;

        private IState currentState = new EmptyState();

#pragma warning disable CS8618
        public static GameManager Instance { get; private set; }
#pragma warning restore CS8618        

        public Camera? MainCamera { get { return mainCamera; } private set { mainCamera = value; } }
        public PlayerController? Player { get { return player; } private set { player = value; } }
        public List<Ship> Ships { get { return this.ships; }}
        public MermaidPool? MermaidPool { get => mermaidPool; private set => mermaidPool = value; }
        public ProjectilePool? ProjectilePool { get => projectilePool; private set => projectilePool = value; }

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

        public void SetPlaying() => CurrentState = new PlayingState(this.player, this.ships, this.cursors, this.music, this.hudPanel);
        public void SetMainMenu() => CurrentState = new MainMenuState(this.player, this.ships, this.mainMenuPanel);
        public void SetCredits() => CurrentState = new CreditsState(this.player, this.ships, this.creditsPanel);
        public void SetOptions() => CurrentState = new OptionsState(this.player, this.ships, this.optionsPanel);
        public void SetGameOverCrash() => CurrentState = new GameOverCrashState();
        public void SetGameWin() => CurrentState = new GameOverWinState();
        public void SetGameLose() => CurrentState = new GameOverLoseState();

        private void CheckBindings()
        {
            
        }

        private void Initialization()
        {
            HideAllUI();
            SetMainMenu();
        }        

        private void HideAllUI()
        {
            this.hudPanel?.Hide();
            this.mainMenuPanel?.Hide();
            this.creditsPanel?.Hide();
            this.optionsPanel?.Hide();
            this.cursors.ForEach(c => c.SetActive(false));
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