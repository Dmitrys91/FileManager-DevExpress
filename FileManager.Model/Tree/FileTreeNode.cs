
namespace FileManager.Model.Tree
{
    public class FileTreeNode
    {
        internal FileTreeNode(string fileName, string filePath, string parentPath, bool isFolder = false)
        {
            Path = filePath;
            FileName = fileName;
            ParentPath = parentPath;
            IsFolder = isFolder;
            ChildNodes = new FileTreeNodeCollection();
        }
       

        public string ParentPath { get; private set; }

        public string Path { get; private set; }

        public string FileName { get; private set; }

        public bool IsFile => !IsFolder;

        public bool IsFolder { get; private set; }

        public FileTreeNodeCollection ChildNodes { get; }
    }
}
