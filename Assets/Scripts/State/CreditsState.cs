using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace HackedDesign
{
    public class CreditsState : IState
    {
        private PlayerController player;
        private List<Ship> ships;
        private UI.AbstractPresenter creditsPresenter;

        public bool PlayerActionAllowed => false;



        public CreditsState(PlayerController player, List<Ship> ships, UI.AbstractPresenter creditsPresenter)
        {
            this.player = player;
            this.ships = ships;
            this.creditsPresenter = creditsPresenter;
        }

        public void Begin()
        {
            this.player.SetCameraGimbal(new Vector3(0f, 270f, 0f));
            this.creditsPresenter.Show();
            this.creditsPresenter.Repaint();

            this.ships.ForEach(s => s.gameObject.SetActive(false));
            GameManager.Instance.Player.gameObject.SetActive(true);
        }

        public void End()
        {
            this.creditsPresenter.Hide();
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