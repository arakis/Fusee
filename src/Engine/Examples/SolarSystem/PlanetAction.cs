﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fusee.Engine;
using Fusee.Math;
using Fusee.SceneManagement;

namespace Examples.Solar
{
    public class PlanetAction : ActionCode
    {
        private  float3 _rotationSpeed;

        public PlanetAction(float3 rotationSpeed)
        {
            _rotationSpeed = rotationSpeed;
        }
        public override void Start()
        {
            transform.LocalEulerAngles = new float3(0, 0, 0);
        }

        public override void Update()
        {
            transform.LocalEulerAngles += _rotationSpeed*(float)Time.Instance.DeltaTime;
            if(SceneEntity.parent!=null)
            SceneManager.RC.DebugLine(SceneEntity.parent.transform.GlobalPosition,transform.GlobalPosition, new float4(1,0,0,1));
        }
    }
}
