using System.Collections;
using System.Collections.Generic;

namespace State
{
    public class State
    {
        public State(string name)
        {
            this.Name = name;
        }
        
        public virtual void Enter()
        {
        }

        public virtual bool Update(int frames)
        {
            return false;
        }

        public virtual int CurrentFrame
        {
            get { return 1; }
        }

        public virtual string Name { get; }
    }
}