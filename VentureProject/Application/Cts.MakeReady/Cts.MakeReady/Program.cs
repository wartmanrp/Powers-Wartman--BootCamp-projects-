using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Cts.MakeReady
{
    class Program
    {
        public static string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }

        static void Main(string[] args)
        {
            if (args.Length != 4)
            {
                DisplayHelp();
                return;
            }

            var inputs = ReadInput(args);

            var rootFolder = AssemblyDirectory;
            if (inputs.IsClientNameValid()) Replace(rootFolder, "Cts.", inputs.Client + ".");
            if (inputs.IsProjectNameValid()) Replace(rootFolder, ".Venture", "." + inputs.ProjectName);
            Replace(rootFolder, "VENTUREDbContext", inputs.ProjectName.ToUpper() + "DbContext");
        }

        private static ReplaceCriteria ReadInput(string[] args)
        {
            var inputs = new ReplaceCriteria();

            for (int i = 0; i < args.Length; i++)
            {
                var data = args[i];
                if (data.Equals(inputs.ClientKey))
                {
                    inputs.Client = args[i + 1];
                }
                else if (data.Equals(inputs.ProjectNameKey))
                {
                    inputs.ProjectName = args[i + 1];
                }
            }

            return inputs;
        }

        private static void DisplayHelp()
        {
            Console.WriteLine("Usage:");
            Console.WriteLine("MakeReady <Abbr of the project>");
            Console.WriteLine("-c /t/t/t/t Name of the client");
            Console.WriteLine("-n /t/t/t/t Abbr of the project name");
            Console.WriteLine("MakeReady -c Regions -n klb");
            Console.WriteLine("Outcome: ");
            Console.WriteLine("/t/tRegions.klb.Common");
            Console.WriteLine("/t/tRegions.klb.Data");
            Console.WriteLine("/t/tRegions.klb.Domain");
            Console.WriteLine("/t/tRegions.klb.Dto");
            Console.WriteLine("/t/tRegions.klb.Service");
            Console.WriteLine("/t/tRegions.klb.UI");
        }

        private static void Replace(string directory, string toReplace, string withReplace)
        {
            var rootFolder = directory;
            var before = toReplace;
            var after = withReplace;
            try
            {
                // Rename Folders
                RenameFolders(rootFolder, before, after);

                // Rename Files
                RenameFiles(rootFolder, before, after);

                // Find and Replace within files
                FindAndReplaceInFiles(rootFolder, before, after);

                // Remove TFS configuration files
                RemoveSourceControlFiles(rootFolder);

            }
            catch (Exception ex)
            {
                DisplayError(ex);
            }
        }

        private static void DisplayError(Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ex.Message);

            Console.ResetColor();
        }

        private static void RenameFolders(string rootPath, string before, string after)
        {
            var root = new System.IO.DirectoryInfo(rootPath);
            foreach (DirectoryInfo folder in root.GetDirectories("*", SearchOption.TopDirectoryOnly))
            {
                string newFolderName = folder.FullName.Replace(before, after);

                if (folder.Name.ToLower().Contains(before.ToLower()))
                {
                    if (newFolderName != folder.FullName)
                    {
                        try
                        {
                            folder.MoveTo(newFolderName);
                        }
                        catch (Exception ex)
                        {
                            DisplayError(ex);
                        }
                    }
                }
                if (folder.GetDirectories().Count() > 0 && folder.Name != "Views")
                {
                    RenameFolders(folder.FullName, before, after);
                }
            }
        }

        private static void RenameFiles(string rootPath, string before, string after)
        {
            var ignoreExtensions = new List<string>() { ".cs" };
            var root = new System.IO.DirectoryInfo(rootPath);
            // Rename root folder files
            var rootFiles = root.EnumerateFiles();
            foreach (var file in rootFiles)
            {
                if (!ignoreExtensions.Contains(file.Extension))
                {
                    //string newFileName = file.FullName.Replace(before, after);
                    string newFileName = file.Name.Replace(before, after);

                    if (newFileName != file.Name)
                    {
                        try
                        {
                            var folder = Path.GetDirectoryName(file.FullName);
                            var fullName = Path.Combine(folder, newFileName);
                            file.MoveTo(fullName);
                        }
                        catch (Exception ex)
                        {
                            DisplayError(ex);
                        }
                    }
                }
            }

            // Rename sub-folder files
            foreach (DirectoryInfo folder in root.GetDirectories("*", SearchOption.AllDirectories))
            {
                var files = folder.EnumerateFiles();
                foreach (var file in files)
                {
                    if (!ignoreExtensions.Contains(file.Extension))
                    {
                        string newFileName = file.Name.Replace(before, after);

                        if (newFileName != file.Name)
                        {
                            try
                            {
                                var folder1 = Path.GetDirectoryName(file.FullName);
                                var fullName = Path.Combine(folder1, newFileName);
                                file.MoveTo(fullName);
                            }
                            catch (Exception ex)
                            {
                                DisplayError(ex);
                            }
                        }
                    }
                }
            }
        }

        private static void FindAndReplaceInFiles(string rootPath, string before, string after)
        {
            var ignoreExtensions = new List<string>() { ".dll", ".pdb", ".ttinclude", ".exe", ".cmd" };
            var root = new System.IO.DirectoryInfo(rootPath);
            // Root folder
            var rootFiles = root.EnumerateFiles();
            foreach (var file in rootFiles)
            {
                if (!ignoreExtensions.Contains(file.Extension) && !file.Attributes.ToString().Contains("Hidden"))
                {
                    bool changed = false;
                    var text = File.ReadAllText(file.FullName);

                    var before1 = string.Format("{0}", before);
                    var after1 = string.Format("{0}", after);
                    if (text.Contains(before1))
                    {
                        text = text.Replace(before1, after1);
                        changed = true;
                    }
                    FileAttributes fa = file.Attributes;
                    if (changed)
                        File.WriteAllText(file.FullName, text);
                }
            }

            // Sub Folders
            foreach (DirectoryInfo folder in root.GetDirectories("*", SearchOption.AllDirectories))
            {

                var files = folder.EnumerateFiles();
                foreach (var file in files)
                {
                    if (!ignoreExtensions.Contains(file.Extension) && !file.Attributes.ToString().Contains("Hidden"))
                    {
                        bool changed = false;
                        var text = File.ReadAllText(file.FullName);

                        var before1 = string.Format("{0}", before);
                        var after1 = string.Format("{0}", after);
                        if (text.Contains(before1))
                        {
                            text = text.Replace(before1, after1);
                            changed = true;
                        }
                        FileAttributes fa = file.Attributes;
                        if (changed)
                            File.WriteAllText(file.FullName, text);
                    }
                }
            }
        }

        private static void RemoveSourceControlFiles(string rootPath)
        {
            var sourceControlFileExtensions = new List<string>() { ".vspscc", ".vssscc" };
            var root = new System.IO.DirectoryInfo(rootPath);

            var rootFiles = root.EnumerateFiles();
            foreach (var file in rootFiles)
            {
                if (sourceControlFileExtensions.Contains(file.Extension))
                {
                    File.Delete(file.FullName);
                }
            }
            foreach (DirectoryInfo folder in root.GetDirectories("*", SearchOption.AllDirectories))
            {
                var files = folder.EnumerateFiles();
                foreach (var file in files)
                {
                    if (sourceControlFileExtensions.Contains(file.Extension))
                    {
                        File.Delete(file.FullName);
                    }
                }
            }
        }
    }
}
