using System;

namespace StarThrower.EarleyParser
{
    public class EdgeEventArgs : EventArgs
    {
        private int _index;
        private Edge _edge;

        public int Index
        {
            get { return _index; }
        }

        public Edge Edge
        {
            get { return _edge; }
        }

        public EdgeEventArgs(int index, Edge edge)
        {
            _index = index;
            _edge = edge;
        }
    }
}
