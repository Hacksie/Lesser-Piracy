using System.Collections.Generic;
using UnityEngine;

namespace HackedDesign
{
    public class GameOverLoseState : IState
    {
        private UI.AbstractPresenter losePresenter;
        private AudioSource music;

        public bool PlayerActionAllowed => false;

        
        public GameOverLoseState(UI.AbstractPresenter losePresenter,AudioSource music)
        {
            this.losePresenter = losePresenter;
            this.music = music;
            //this.ships = ships;
            // this.pool = pool;
            //this.hudPresenter = hudPresenter;
            // this.weaponManager = weaponManager;
        }


        public void Begin()
        {
            Logger.Log("GameOverLoseState", "Game Over!");
            this.losePresenter.Show();
            this.losePresenter.Repaint();
        }

        public void End()
        {
            Cursor.visible = true;
            this.losePresenter.Hide();
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