using System;
using System.IO;

namespace FileManager.Model.Tree
{
    public class FileTree
    {
        private readonly string _rootFolderPath;
        private readonly DirectoryInfo _rootDirectory;
        public FileTree(string rootFolderPath)
        {
            if (string.IsNullOrEmpty(rootFolderPath))
                throw new ArgumentNullException(nameof(rootFolderPath));

            _rootFolderPath = rootFolderPath;
            _rootDirectory = new DirectoryInfo(_rootFolderPath);

            Nodes = new FileTreeNodeCollection()
            {
                AddNodeAndDescendents(_rootDirectory)
            };
        }

        public FileTreeNodeCollection Nodes { get; }

        public string RootPath => _rootFolderPath;

        private FileTreeNode AddNodeAndDescendents(DirectoryInfo folder, FileTreeNode parentNode = null)
        {
            if (folder is null)
                return null;

            var node = new FileTreeNode(folder.Name, folder.FullName, parentNode?.Path, true);

            var subFolders = folder.GetDirectories();

            foreach (DirectoryInfo subFolder in subFolders)
            {
                var child = AddNodeAndDescendents(subFolder, node);
                node.ChildNodes.Add(child);
            }

            foreach (FileInfo file in folder.GetFiles())
            {
                var fileNode = new FileTreeNode(file.Name, file.FullName, node.Path);           
                node.ChildNodes.Add(fileNode);
            }

            return node;
        }
    }
}
