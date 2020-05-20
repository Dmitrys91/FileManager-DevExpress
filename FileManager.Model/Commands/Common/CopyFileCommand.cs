using FileManager.Model.Enum;

namespace FileManager.Model.Commands
{
    public class CopyFileCommand : IFileManagerCommand
    {
        public string[] AllowedExtensions => new string[] { "*" };
        public string Name => "Copy";
        public string Text => "Copy";
        public string IconId => string.Empty;
        public string ImageUrl => string.Empty;
        public CommandPosition Position => CommandPosition.ToolBarAndContextMenu;
    }
}
