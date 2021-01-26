
using System.Collections.Generic;
using UnityEngine;

namespace HackedDesign
{
    public class PauseState : IState
    {
        private UI.AbstractPresenter pausePresenter;


        public bool PlayerActionAllowed => false;


        public PauseState(UI.AbstractPresenter pausePresenter)
        {
            this.pausePresenter = pausePresenter;

        }


        public void Begin()
        {
            Cursor.visible = true;
            Time.timeScale = 0;
            this.pausePresenter.Show();
            this.pausePresenter.Repaint();
        }

        public void End()
        {
            Time.timeScale = 1;
            this.pausePresenter.Hide();
        }


        public void FixedUpdate()
        {

        }

        public void LateUpdate()
        {

        }


        public void Start()
        {
            GameManager.Instance.SetPlaying();
        }

        public void Select()
        {

        }

        public void Update()
        {

        }

    }
}