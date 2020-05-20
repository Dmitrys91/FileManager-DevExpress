using System.Collections;
using System.Collections.Generic;

namespace FileManager.Model.Tree
{
    public class FileTreeNodeCollection : ICollection<FileTreeNode>
    {
        private ICollection<FileTreeNode> _items;

        internal FileTreeNodeCollection()
        {
            _items = new List<FileTreeNode>();
        }

        protected FileTreeNodeCollection(ICollection<FileTreeNode> collection)
        {
            _items = collection;
        }

        public void Add(FileTreeNode item)
        {
            _items.Add(item);
        }

        public void Clear()
        {
            _items.Clear();
        }

        public bool Contains(FileTreeNode item)
        {
            return _items.Contains(item);
        }

        public void CopyTo(FileTreeNode[] array, int arrayIndex)
        {
            _items.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return _items.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(FileTreeNode item)
        {
            return _items.Remove(item);
        }

        public IEnumerator<FileTreeNode> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _items.GetEnumerator();
        }
    }
}
