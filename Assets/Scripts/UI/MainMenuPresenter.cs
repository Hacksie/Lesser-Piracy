using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace HackedDesign.UI
{
    public class MainMenuPresenter : AbstractPresenter
    {


        public override void Repaint()
        {

        }

        public void StartEvent()
        {
            GameManager.Instance.SetPlaying();
        }

        public void OptionsEvent()
        {
            GameManager.Instance.SetOptions();
        }

        public void CreditsEvent()
        {
            GameManager.Instance.SetCredits();
        }                

        public void QuitEvent()
        {
            //GameManager.Instance.PlayerPreferences.Save();
            Application.Quit();
        }
    }
}