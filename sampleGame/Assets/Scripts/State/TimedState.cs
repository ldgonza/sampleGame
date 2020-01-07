using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace State
{
    public class TimedState : State
    {
        private int frames;
        private bool resets;
        private Nullable<int> maxFrames;

        public TimedState(string name): base(name)
        {
            this.maxFrames = null;
            this.resets = false;
        }

        public TimedState(string name, int maxFrames) : base(name)
        {
            this.maxFrames = maxFrames;
            this.resets = false;
        }

        public TimedState(string name, int maxFrames, bool resets) : base(name)
        {
            this.maxFrames = maxFrames;
            this.resets = resets;
        }

        public TimedState Resets()
        {
            this.resets = true;
            return this;
        }

        public override void Enter()
        {
            base.Enter();
            this.frames = 0;
        }

        public override bool Update(int frames)
        {
            if (base.Update(frames))
                return true;

            bool done = false;
            this.frames += frames;

            if (this.maxFrames != null)
            {
                done = this.frames >= this.maxFrames;              
                this.frames = Math.Min(this.frames, this.maxFrames.Value);
            }

            if (done && this.resets) {
                this.Enter();
                return false;
            }

            return done;
        }

        public override int CurrentFrame
        {
            get { return this.frames; }
        }
    }
}