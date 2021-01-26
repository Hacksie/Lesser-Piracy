using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace HackedDesign.UI
{
    public class MainMenuPresenter : AbstractPresenter
    {

        [Header("Main")]
        [SerializeField] private GameObject defaultPanel = null;
        [SerializeField] private GameObject optionsPanel = null;
        [SerializeField] private GameObject howtoPanel = null;
        [SerializeField] private GameObject creditsPanel = null;

        private MainMenuState state = MainMenuState.Default;

        public override void Repaint()
        {
            switch (state)
            {
                default:
                case MainMenuState.Default:
                    defaultPanel.SetActive(true);
                    optionsPanel.SetActive(false);
                    howtoPanel.SetActive(false);
                    creditsPanel.SetActive(false);
                    break;
                case MainMenuState.Options:
                    defaultPanel.SetActive(false);
                    optionsPanel.SetActive(true);
                    howtoPanel.SetActive(false);
                    creditsPanel.SetActive(false);
                    break;
                case MainMenuState.Howto:
                    defaultPanel.SetActive(false);
                    optionsPanel.SetActive(false);
                    howtoPanel.SetActive(true);
                    creditsPanel.SetActive(false);
                    break;
                case MainMenuState.Credits:
                    defaultPanel.SetActive(false);
                    optionsPanel.SetActive(false);
                    howtoPanel.SetActive(false);
                    creditsPanel.SetActive(true);
                    break;
            }
        }

        public void StartEvent()
        {
            GameManager.Instance.SetReady();
        }

        public void OptionsEvent()
        {
            state = MainMenuState.Options;
            Repaint();
        }

        public void CreditsEvent()
        {
            state = MainMenuState.Credits;
            Repaint();
        }

        public void HowtoEvent()
        {
            state = MainMenuState.Howto;
            Repaint();
        }

        public void DefaultEvent()
        {
            state = MainMenuState.Default;
            Repaint();
        }

        public void QuitEvent()
        {
            //GameManager.Instance.PlayerPreferences.Save();
            Application.Quit();
        }

        private enum MainMenuState
        {
            Default,
            Options,
            Howto,
            Credits,
        }
    }


}