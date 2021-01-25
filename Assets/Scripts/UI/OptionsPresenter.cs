using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace HackedDesign.UI
{
    public class OptionsPresenter : AbstractPresenter
    {


        public override void Repaint()
        {

        }
        public void CloseEvent()
        {
            //GameManager.Instance.PlayerPreferences.Save();
            GameManager.Instance.SetMainMenu();
        }
    }
}