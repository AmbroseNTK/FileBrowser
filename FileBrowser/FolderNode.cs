using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileBrowser
{
    public enum NodeType
    {
        Folder,
        File,
    }
    class FolderNode
    {
        public List<FolderNode> ChildFolders { get; set; }
        public List<FileNode> ChildFiles { get; set; }

        public NodeType Type { get; set; }
        public string folderDirectory;
        public string FolderDirectory { get => folderDirectory;
            set {
                folderDirectory = value;
                FolderName = folderDirectory.Split('\\')[folderDirectory.Split('\\').Length - 1];
            } }

        public string FolderName { get; set; }
        public string IconName { get => Type.ToString() + ".png"; }
        public FolderNode()
        {
            Type = NodeType.Folder;
            ChildFolders = new List<FolderNode>();
            ChildFiles = new List<FileNode>();
        }
    }
}
