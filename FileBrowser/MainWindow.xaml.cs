using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Collections.ObjectModel;

namespace FileBrowser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            
            InitializeComponent();
        }

        FolderNode root;
        ObservableCollection<FolderNode> dir;
        AutoCompleteEntry autoCompleteEntry;
       
        private void Window_Activated(object sender, EventArgs e)
        {
           
        }
        private void CreateRoot(string rootPath)
        {
            root = new FolderNode() { FolderDirectory = rootPath };
            GetChildNode(root);
            dir = new ObservableCollection<FolderNode>();
            dir.Add(root);

            treeDirectory.ItemsSource = dir;
        }
        private void GetChildNode(FolderNode parent, string currentPath = "")
        {
            try
            {
                foreach (string folder in Directory.EnumerateDirectories(parent.FolderDirectory))
                {
                    FolderNode folderNode = new FolderNode() { FolderDirectory = folder };
                    parent.ChildFolders.Add(folderNode);
                    
                }
                foreach (string file in Directory.EnumerateFiles(parent.FolderDirectory))
                {
                    FolderNode folderNode = new FolderNode() { FolderDirectory = file };
                    folderNode.Type = NodeType.File;
                    parent.ChildFolders.Add(folderNode);
                }
            }
            catch { }

        }


        private void tbRoot_TextChanged(object sender, TextChangedEventArgs e)
        {

           
        }

        private void treeDirectory_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            FolderNode currentNode = (treeDirectory.SelectedItem as FolderNode);
            GetChildNode(currentNode);
        }

        private void tbRoot_KeyDown(object sender, KeyEventArgs e)
        {
            

        }

        private void tbRoot_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            if (Directory.Exists(tbRoot.Text))
            {
                tbRoot.IsEnabled = false;
                CreateRoot(tbRoot.Text);
                tbRoot.IsEnabled = true;
            }
            //else
            //{
            //    string src = "";
            //    string[] paths = tbRoot.Text.Split('\\');
            //    for (int i = 0; i < paths.Length - 1; i++)
            //    {
            //        src += paths[i];
            //    }
            //    if (Directory.Exists(src))
            //    {
            //        foreach (string path in Directory.EnumerateDirectories(src))
            //        {
            //            //tbRoot.AddItem(new AutoCompleteEntry(path, new string[] { System.IO.Path.GetFileName(System.IO.Path.GetDirectoryName(src))}));
            //        }

            //    }
            //}
        }
    }
   
}
