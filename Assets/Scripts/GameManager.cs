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
        [SerializeField] private ObstaclePool? obstaclePool = null;
        [SerializeField] private Waves? waves = null;
        [SerializeField] private PropsPool? propsPool = null;
        [SerializeField] private AudioSource? menuMusic = null;
        [SerializeField] private AudioSource? playMusic = null;

        [Header("UI")]
        
        [SerializeField] private UI.HudPresenter? hudPanel = null;
        [SerializeField] private UI.MainMenuPresenter? mainMenuPanel = null;
        [SerializeField] private UI.ReadyPresenter? readyPanel = null;
        [SerializeField] private UI.CrashPresenter? crashPanel = null;
        [SerializeField] private UI.LosePresenter? losePanel = null;
        [SerializeField] private UI.WinPresenter? winPanel = null;
        [SerializeField] private UI.PausePresenter? pausePanel = null;

        private IState currentState = new EmptyState();

#pragma warning disable CS8618
        public static GameManager Instance { get; private set; }
#pragma warning restore CS8618        

        public Camera? MainCamera { get { return mainCamera; } private set { mainCamera = value; } }
        public PlayerController? Player { get { return player; } private set { player = value; } }
        public List<Ship> Ships { get { return this.ships; }}
        public MermaidPool? MermaidPool { get => mermaidPool; private set => mermaidPool = value; }
        public ProjectilePool? ProjectilePool { get => projectilePool; private set => projectilePool = value; }
        public Waves? Waves { get => waves; private set => waves = value; }

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

        public void SetPlaying() => CurrentState = new PlayingState(this.player, this.ships, this.cursors, this.obstaclePool, this.propsPool, this.playMusic, this.hudPanel);
        public void SetMainMenu() => CurrentState = new MainMenuState(this.player, this.ships, this.menuMusic, this.mainMenuPanel);
        public void SetGameOverCrash() => CurrentState = new GameOverCrashState(this.crashPanel, this.playMusic);
        public void SetGameWin() => CurrentState = new GameOverWinState(this.winPanel, this.playMusic);
        public void SetGameLose() => CurrentState = new GameOverLoseState(this.losePanel, this.playMusic);
        public void SetReady() => CurrentState = new ReadyState(this.player, this.ships, this.cursors, this.obstaclePool, this.propsPool, this.playMusic, this.readyPanel, this.hudPanel);
        public void SetPause() => CurrentState = new PauseState(this.pausePanel);

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
            this.readyPanel?.Hide();
            this.crashPanel?.Hide();
            this.losePanel?.Hide();
            this.winPanel?.Hide();
            this.pausePanel?.Hide();
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