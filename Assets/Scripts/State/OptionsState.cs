using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace HackedDesign
{
    public class OptionsState : IState
    {
        private PlayerController player;
        private List<Ship> ships;
        private UI.AbstractPresenter optionsPresenter;

        public bool PlayerActionAllowed => false;



        public OptionsState(PlayerController player, List<Ship> ships, UI.AbstractPresenter optionsPresenter)
        {
            this.player = player;
            this.ships = ships;
            this.optionsPresenter = optionsPresenter;
        }

        public void Begin()
        {
            this.player.SetCameraGimbal(new Vector3(0f, 270f, 0f));
            this.optionsPresenter.Show();
            this.optionsPresenter.Repaint();

            this.ships.ForEach(s => s.gameObject.SetActive(false));
            GameManager.Instance.Player.gameObject.SetActive(true);
        }

        public void End()
        {
            this.optionsPresenter.Hide();
        }

        public void Update()
        {
            Cursor.visible = true;
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