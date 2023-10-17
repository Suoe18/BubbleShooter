using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MegaCat
{
    public class Stage
    {
        private static Stage instance;

        public static Stage GetInstance()
        {
            if (instance == null)
            {
                instance = new Stage();
            }
            return instance;
        }

        private StageType stageName;

        public StageType StageName { get => stageName; set => stageName = value; }
    }

}
