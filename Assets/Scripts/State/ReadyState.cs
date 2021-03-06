using System.Collections.Generic;
using UnityEngine;

namespace HackedDesign
{
    public class ReadyState : IState
    {
        private PlayerController player;
        private List<Ship> ships;
        private List<GameObject> cursors;
        private UI.AbstractPresenter hudPresenter;
        private UI.ReadyPresenter readyPresenter;
        private ObstaclePool obstaclePool;
        private PropsPool propsPool;
        private AudioSource music;

        public bool PlayerActionAllowed => false;

        private int count = 3;
        private float timerStart = 0;


        public ReadyState(PlayerController player, List<Ship> ships, List<GameObject> cursors, ObstaclePool obstaclePool, PropsPool propsPool, AudioSource music, UI.ReadyPresenter readyPresenter, UI.AbstractPresenter hudPresenter)
        {
            this.player = player;
            this.ships = ships;
            this.cursors = cursors;
            this.music = music;
            this.obstaclePool = obstaclePool;
            this.propsPool = propsPool;
            this.hudPresenter = hudPresenter;
            this.readyPresenter = readyPresenter;
        }


        public void Begin()
        {
            this.player.SetCameraGimbal(new Vector3(0f, 0f, 0));
            this.ships.ForEach(s => s.Reset());
            this.ships.ForEach(s => s.gameObject.SetActive(true));
            this.hudPresenter.Show();
            this.music.Play();
            this.obstaclePool.SpawnRandomObstacles();
            this.propsPool.SpawnRandomProps();
            this.readyPresenter.Show();
            this.timerStart = Time.time;
        }

        public void End()
        {
            Cursor.visible = true;
            this.hudPresenter.Hide();
            this.readyPresenter.Hide();
        }

        public void Update()
        {
            Cursor.visible = false;

            count = 3 - Mathf.FloorToInt(Time.time - timerStart);
            
            if (count < 0)
            {
                GameManager.Instance.SetPlaying();
            }
        }


        public void FixedUpdate()
        {

        }

        public void LateUpdate()
        {

            this.hudPresenter.Repaint();
            this.readyPresenter.Count = count;
            this.readyPresenter.Repaint();
        }

        public void Start()
        {

        }

        public void Select()
        {

        }



    }
}