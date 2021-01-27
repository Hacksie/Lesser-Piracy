using System.Collections.Generic;
using UnityEngine;

namespace HackedDesign
{
    public class PlayingState : IState
    {
        private PlayerController player;
        private List<Ship> ships;
        private List<GameObject> cursors;
        private UI.AbstractPresenter hudPresenter;
        private ObstaclePool obstaclePool;
        private PropsPool propsPool;
        private AudioSource music;

        public bool PlayerActionAllowed => true;


        public PlayingState(PlayerController player, List<Ship> ships, List<GameObject> cursors, ObstaclePool obstaclePool,PropsPool propsPool, AudioSource music, UI.AbstractPresenter hudPresenter)
        {
            this.player = player;
            this.ships = ships;
            this.cursors = cursors;
            this.music = music;
            this.obstaclePool = obstaclePool;
            this.propsPool = propsPool;
            this.hudPresenter = hudPresenter;
        }


        public void Begin()
        {
            this.ships.ForEach(s => s.Begin());
            this.cursors.ForEach(c => c.SetActive(true));
            this.hudPresenter.Show();
        }

        public void End()
        {
            Cursor.visible = true;
            this.hudPresenter.Hide();
            this.cursors.ForEach(c => c.SetActive(false));
        }

        public void Update()
        {
            Cursor.visible = false;
        }


        public void FixedUpdate()
        {
            foreach (var ship in this.ships)
            {
                ship.FixedUpdateBehaviour();
            }
        }

        public void LateUpdate()
        {
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