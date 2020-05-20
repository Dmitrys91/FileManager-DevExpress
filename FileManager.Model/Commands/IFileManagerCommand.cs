
using FileManager.Model.Enum;

namespace FileManager.Model.Commands
{
    public interface IFileManagerCommand
    {
        /// <summary>
        /// Allowed extensions
        /// </summary>
        string[] AllowedExtensions { get; }

        /// <summary>
        /// Name of command
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Visible caption text
        /// </summary>
        string Text { get; }

        /// <summary>
        /// System IconId path
        /// </summary>
        string IconId { get; }

        /// <summary>
        /// Image url
        /// </summary>
        string ImageUrl { get; }

        /// <summary>
        /// Visible position
        /// </summary>
        CommandPosition Position { get; }
    }
}
