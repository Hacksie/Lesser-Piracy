using System.Collections.Generic;
using UnityEngine;

namespace HackedDesign
{
    public class PlayingState : IState
    {
        private PlayerController player;
        private List<Ship> ships;
        private List<GameObject> cursors;
        // private EntityPool pool;
        private UI.AbstractPresenter hudPresenter;
        private AudioSource music;
        // private WeaponManager weaponManager;

        public bool PlayerActionAllowed => true;


        public PlayingState(PlayerController player, List<Ship> ships, List<GameObject> cursors, AudioSource music, UI.AbstractPresenter hudPresenter)
        {
            this.player = player;
            this.ships = ships;
            this.cursors = cursors;
            this.music = music;
            // this.pool = pool;
            this.hudPresenter = hudPresenter;
            // this.weaponManager = weaponManager;
        }


        public void Begin()
        {
            this.player.SetCameraGimbal(new Vector3(0f, 0f, 0));
            this.cursors.ForEach(c => c.SetActive(true));
            // GameManager.Instance.SaveGame();
            this.ships.ForEach(s => s.gameObject.SetActive(true));
            this.cursors.ForEach(c => c.gameObject.SetActive(true));
            this.hudPresenter.Show();
            this.music.Play();
            // this.weaponManager.ShowCurrentWeapon();
            // Cursor.lockState = CursorLockMode.Locked;
            // AudioManager.Instance.PlayRandomGameMusic();
            // AudioManager.Instance.PlayGo();
        }

        public void End()
        {
            Cursor.visible = true;
            this.hudPresenter.Hide();
            this.music.Stop();
            this.cursors.ForEach(c => c.SetActive(false));
        }

        public void Update()
        {
            Cursor.visible = false;
            //this.player.UpdateBehaviour();
            foreach (var ship in this.ships)
            {
                ship.UpdateBehaviour();
            }
        }


        public void FixedUpdate()
        {
            //this.player.FixedUpdateBehaviour();
            foreach (var ship in this.ships)
            {
                ship.FixedUpdateBehaviour();
            }
        }

        public void LateUpdate()
        {
            // this.player.LateUpdateBehaviour();
            // this.pool.UpdateLateBehaviour();
            this.hudPresenter.Repaint();
        }




        public void Start()
        {

        }

        public void Select()
        {

        }



    }
}