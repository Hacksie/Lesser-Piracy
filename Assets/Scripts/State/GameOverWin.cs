using System.Collections.Generic;
using UnityEngine;

namespace HackedDesign
{
    public class GameOverWinState : IState
    {
        //private List<Ship> ships;
        // private EntityPool pool;
        //private UI.AbstractPresenter hudPresenter;
        // private WeaponManager weaponManager;

        public bool PlayerActionAllowed => false;

        //public PlayingState(PlayerController player, WeaponManager weaponManager, EntityPool pool, UI.AbstractPresenter hudPresenter)
        public GameOverWinState()
        {
            
            //this.ships = ships;
            // this.pool = pool;
            //this.hudPresenter = hudPresenter;
            // this.weaponManager = weaponManager;
        }


        public void Begin()
        {
            Logger.Log("GameOverWinState", "Game Over!");
            // GameManager.Instance.SaveGame();
            //this.hudPresenter.Show();
            // this.weaponManager.ShowCurrentWeapon();
            // Cursor.lockState = CursorLockMode.Locked;
            // AudioManager.Instance.PlayRandomGameMusic();
            // AudioManager.Instance.PlayGo();
        }

        public void End()
        {
            Cursor.visible = true;
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