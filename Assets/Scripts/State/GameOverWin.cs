using System.Collections.Generic;
using UnityEngine;

namespace HackedDesign
{
    public class GameOverWinState : IState
    {
        private UI.AbstractPresenter winPresenter;
        private AudioSource music;

        public bool PlayerActionAllowed => false;

        
        public GameOverWinState(UI.AbstractPresenter winPresenter, AudioSource music)
        {
           this.winPresenter = winPresenter; 
           this.music = music;
           
        }


        public void Begin()
        {
            Logger.Log("GameOverWinState", "Game Over!");
            this.winPresenter.Show();
            this.winPresenter.Repaint();
        }

        public void End()
        {
            Cursor.visible = true;
            this.winPresenter.Hide();
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
