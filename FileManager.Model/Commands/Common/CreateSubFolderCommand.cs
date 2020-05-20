using FileManager.Model.Enum;

namespace FileManager.Model.Commands
{
    public class CreateSubFolderCommand : IFileManagerCommand
    {
        /// <summary>
        /// Empty string = folder type
        /// </summary>
        public string[] AllowedExtensions => new string[] { string.Empty };
        public string Name => "CreateSubFolder";
        public string Text => "Create New Subfolder";
        public string IconId => string.Empty;
        public string ImageUrl => string.Empty;
        public CommandPosition Position => CommandPosition.ToolBarAndContextMenu;       
    }
}
