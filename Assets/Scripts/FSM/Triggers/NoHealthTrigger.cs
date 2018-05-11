﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.FSM
{
    /// <summary>
    /// 没有生命条件
    /// </summary>
    public class NoHealthTrigger : FSMTrigger
    {
        public override bool HandleTrigger(BaseFSM fsm)
        { 
            return fsm.status.HP <= 0;
        }

        public override void Init()
        {
            TriggerID = FSMTriggerID.NoHealth;
        }
    }
}
