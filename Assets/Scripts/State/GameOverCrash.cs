using System.Collections.Generic;
using UnityEngine;

namespace HackedDesign
{
    public class GameOverCrashState : IState
    {
        private UI.AbstractPresenter crashPresenter;
        private AudioSource music;

        public bool PlayerActionAllowed => false;

        public GameOverCrashState(UI.AbstractPresenter crashPresenter, AudioSource music)
        {
            this.crashPresenter = crashPresenter;
            this.music = music;
        }


        public void Begin()
        {
            Logger.Log("GameOverCrashState", "Game Over!");
            this.crashPresenter.Show();
            this.crashPresenter.Repaint();

        }

        public void End()
        {
            Cursor.visible = true;
            this.crashPresenter.Hide();
            this.music.Stop();
        }


        public void FixedUpdate()
        {
            
        }

        public void LateUpdate()
        {
            
        }


        public void Start()
        {

        }

        public void Select()
        {

        }

        public void Update()
        {
                       
        }

    }
}