using System;
using System.Collections;
using System.Collections.Generic;

namespace State
{
    public class ChainedState : State
    {
        private State[] chain;
        private int currentIndex;
        private bool loops;

        public ChainedState(State[] chain): base("")
        {
            if (chain.Length == 0)
                throw new Exception("State Chain must have something!");
                
            this.chain = chain;
            this.loops = false;
        }

        public ChainedState Loops()
        {
            this.loops = true;
            return this;
        }

        public override void Enter()
        {
            base.Enter();
            this.currentIndex = 0;
        }

        public bool Advance()
        {
            this.currentIndex++;
            if (this.currentIndex == this.chain.Length)
                return false;

            this.chain[this.currentIndex].Enter();
            return true;
        }

        public bool Advance(int to)
        {
            this.currentIndex = to;
            this.chain[this.currentIndex].Enter();
            return true;
        }

        public override bool Update(int frames)
        {
            if (base.Update(frames))
                return true;

            bool done = this.chain[this.currentIndex].Update(frames);
            if (done) {
                bool more = this.Advance();
                if (!more)
                {
                    if (this.loops)
                        this.Advance(0);
                    else
                        return true;
                }
            }
            return false;
        }

        public override string Name => this.chain[this.currentIndex].Name;
        public override int CurrentFrame => this.chain[this.currentIndex].CurrentFrame;
    }
}