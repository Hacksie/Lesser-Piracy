using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace HackedDesign.UI
{
    public class WinPresenter : AbstractPresenter
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