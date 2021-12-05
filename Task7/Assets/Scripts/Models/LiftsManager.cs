using System;
using System.Collections.Generic;
using UnityEngine;

namespace TdgMvc
{
    public class LiftsManager : IDisposable
    {
        private List<LevelObjectView> _liftViews;
        private List<LevelObjectView> _turnTriggers;
        private JointMotor2D _jointMotor;

        public LiftsManager(List<LevelObjectView> liftViews, List<LevelObjectView> turnTriggers)
        {
            _liftViews = liftViews;
        }

        public void Dispose()
        {
            
        }
    }
}
