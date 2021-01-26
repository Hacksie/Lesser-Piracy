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
        private ObstaclePool obstaclePool;
        private PropsPool propsPool;
        private AudioSource music;
        // private WeaponManager weaponManager;

        public bool PlayerActionAllowed => true;


        public PlayingState(PlayerController player, List<Ship> ships, List<GameObject> cursors, ObstaclePool obstaclePool,PropsPool propsPool, AudioSource music, UI.AbstractPresenter hudPresenter)
        {
            this.player = player;
            this.ships = ships;
            this.cursors = cursors;
            this.music = music;
            this.obstaclePool = obstaclePool;
            this.propsPool = propsPool;
            // this.pool = pool;
            this.hudPresenter = hudPresenter;
            // this.weaponManager = weaponManager;
        }


        public void Begin()
        {
            this.cursors.ForEach(c => c.SetActive(true));
            this.ships.ForEach(s => s.Begin());
            this.cursors.ForEach(c => c.gameObject.SetActive(true));
            this.hudPresenter.Show();
            //this.music.Play();
            //this.obstaclePool.SpawnRandomObstacles();
            //this.propsPool.SpawnRandomProps();
        }

        public void End()
        {
            Cursor.visible = true;
            this.hudPresenter.Hide();
            //this.music.Stop();
            this.cursors.ForEach(c => c.SetActive(false));
            //this.obstaclePool.DestroyObstacles(); // FIXME: Move to end state
            //this.propsPool.DestroyProps();
        }

        public void Update()
        {
            Cursor.visible = false;
            //this.player.UpdateBehaviour();
            // foreach (var ship in this.ships)
            // {
            //     ship.UpdateBehaviour();
            // }
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
            GameManager.Instance.SetPause();
        }

        public void Select()
        {

        }



    }
}