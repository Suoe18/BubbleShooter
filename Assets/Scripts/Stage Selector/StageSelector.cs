using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MegaCat
{
    public class StageSelector : MonoBehaviour
    {
        [SerializeField] GameObject errorBanner;
        public void SelectIceCave()
        {
            Stage.GetInstance().StageName = StageType.ICECAVE;
            SceneManager.LoadSceneAsync("ICE CAVE");
        }

        public void SelectMagmaForge()
        {
            Stage.GetInstance().StageName = StageType.MAGMAFORGE;
            errorBanner.SetActive(true);
            Invoke("DisableBanner", 2);
        }

        public void DisableBanner()
        {
            errorBanner.SetActive(false);
        }
    }
}
