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
            //this.ships = ships;
            // this.pool = pool;
            //this.hudPresenter = hudPresenter;
            // this.weaponManager = weaponManager;
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
            //this.hudPresenter.Hide();
        }


        public void FixedUpdate()
        {
            //this.player.FixedUpdateBehaviour();
            // foreach(var ship in this.ships)
            // {
            //     ship.FixedUpdateBehaviour();
            // }
        }

        public void LateUpdate()
        {
            // this.player.LateUpdateBehaviour();
            // this.pool.UpdateLateBehaviour();
            //this.hudPresenter.Repaint();
        }


        public void Start()
        {

        }

        public void Select()
        {

        }

        public void Update()
        {
            // Cursor.visible = false;
            // //this.player.UpdateBehaviour();
            // foreach(var ship in this.ships)
            // {
            //     ship.UpdateBehaviour();
            // }            
        }

    }
}