using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace HackedDesign
{
    public class MainMenuState : IState
    {
        private PlayerController player;
        private List<Ship> ships;
        private UI.AbstractPresenter mainMenuPresenter;

        public bool PlayerActionAllowed => false;



        public MainMenuState(PlayerController player, List<Ship> ships, UI.AbstractPresenter mainMenuPresenter)
        {
            this.player = player;
            this.ships = ships;
            this.mainMenuPresenter = mainMenuPresenter;
        }

        public void Begin()
        {
            this.player.SetCameraGimbal(new Vector3(0f, 270f, 0f));
            this.mainMenuPresenter.Show();
            this.mainMenuPresenter.Repaint();

            this.ships.ForEach(s => s.gameObject.SetActive(false));
            GameManager.Instance.Player.gameObject.SetActive(true);
        }

        public void End()
        {
            this.mainMenuPresenter.Hide();
        }

        public void Update()
        {
            Cursor.visible = true;
            //this.player.UpdateBehaviour();
            foreach (var ship in this.ships)
            {
                ship.UpdateBehaviour();
            }
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


    }
}