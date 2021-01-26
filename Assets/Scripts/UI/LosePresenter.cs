using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace HackedDesign.UI
{
    public class LosePresenter : AbstractPresenter
    {
        

        public override void Repaint()
        {
           
        }

        public void CloseEvent()
        {
            GameManager.Instance.SetMainMenu();
        }        
    }
}