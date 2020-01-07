using System;
using System.Collections;
using System.Collections.Generic;

namespace State
{
    public class TimedState : State
    {
        private int frames;
        private Nullable<int> maxFrames;

        public TimedState(string name): base(name)
        {
            this.maxFrames = null;
        }

        public TimedState(string name, int maxFrames) : base(name)
        {
            this.maxFrames = maxFrames;
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

            return done;
        }

        public override int CurrentFrame
        {
            get { return this.frames; }
        }
    }
}