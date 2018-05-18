using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileBrowser
{
    class Node
    {
        private List<Node> childs;

        protected List<Node> Childs { get => childs; set => childs = value; }
    }
}
