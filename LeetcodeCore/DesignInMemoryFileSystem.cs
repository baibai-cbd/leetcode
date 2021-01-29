using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetcodeCore
{
    public class FileSystem
    {
        // 588. Design In-Memory File System
        // For this solution same name for a file and directory in the same level of directory is possible
        // If same name shall not be allowed, then use a unified node class for File and Directory is a reasonable solution
        private Directory _root;

        public FileSystem()
        {
            _root = new Directory("root");
        }

        public IList<string> Ls(string path)
        {
            var pathSegments = path.Split('/', StringSplitOptions.RemoveEmptyEntries);
            var currDirectory = _root;
            //
            if (pathSegments.Length == 0)
            {
                return currDirectory.Directories.Keys.Concat(currDirectory.Files.Keys).OrderBy(name => name).ToList();
            }
            //
            for (int i = 0; i < pathSegments.Length - 1; i++)
            {
                if (currDirectory.Directories.ContainsKey(pathSegments[i]))
                    currDirectory = currDirectory.Directories[pathSegments[i]];
                else
                    return new List<string>();
            }
            //
            if (currDirectory.Files.ContainsKey(pathSegments[^1]))
            {
                var list = new List<string>();
                list.Add(pathSegments[^1]);
                return list;
            }
            else if (currDirectory.Directories.ContainsKey(pathSegments[^1]))
            {
                currDirectory = currDirectory.Directories[pathSegments[^1]];
                return currDirectory.Directories.Keys.Concat(currDirectory.Files.Keys).OrderBy(name => name).ToList();
            }
            else
            {
                return new List<string>();
            }
        }

        public void Mkdir(string path)
        {
            var pathSegments = path.Split('/', StringSplitOptions.RemoveEmptyEntries);
            var currDirectory = _root;
            for (int i = 0; i < pathSegments.Length; i++)
            {
                if (currDirectory.Directories.ContainsKey(pathSegments[i]))
                {
                    currDirectory = currDirectory.Directories[pathSegments[i]];
                }
                else
                {
                    currDirectory.Directories.Add(pathSegments[i], new Directory(pathSegments[i]));
                    currDirectory = currDirectory.Directories[pathSegments[i]];
                }
            }
        }

        public void AddContentToFile(string filePath, string content)
        {
            var pathSegments = filePath.Split('/', StringSplitOptions.RemoveEmptyEntries);
            var currDirectory = _root;
            for (int i = 0; i < pathSegments.Length - 1; i++)
            {
                if (currDirectory.Directories.ContainsKey(pathSegments[i]))
                    currDirectory = currDirectory.Directories[pathSegments[i]];
                else
                    return;
            }
            //
            if (currDirectory.Files.ContainsKey(pathSegments[^1]))
            {
                currDirectory.Files[pathSegments[^1]].Content = currDirectory.Files[pathSegments[^1]].Content + content;
            }
            else
            {
                currDirectory.Files.Add(pathSegments[^1], new File(pathSegments[^1], content));
            }
        }

        public string ReadContentFromFile(string filePath)
        {
            var pathSegments = filePath.Split('/', StringSplitOptions.RemoveEmptyEntries);
            var currDirectory = _root;
            for (int i = 0; i < pathSegments.Length - 1; i++)
            {
                if (currDirectory.Directories.ContainsKey(pathSegments[i]))
                    currDirectory = currDirectory.Directories[pathSegments[i]];
                else
                    return null;
            }
            //
            if (currDirectory.Files.ContainsKey(pathSegments[^1]))
            {
                return currDirectory.Files[pathSegments[^1]].Content;
            }
            else
            {
                return null;
            }
        }
    }

    public class Directory
    {
        public string Name { get; private set; }

        public Dictionary<string, Directory> Directories { get; set; }

        public Dictionary<string, File> Files { get; set; }

        public Directory(string name)
        {
            Name = name;
            Directories = new Dictionary<string, Directory>();
            Files = new Dictionary<string, File>();
        }
    }

    public class File
    {
        public string Name { get; private set; }

        public string Content { get; set; }

        public File(string name, string content)
        {
            Name = name;
            Content = content;
        }
    }
}
