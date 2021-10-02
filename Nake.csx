#r "nuget: Nake.Utility, 3.0.0-beta-01"
#r "nuget: Nake.Meta, 3.0.0-beta-01"

using Nake;
using System.IO;
using static Nake.FS;
using static Nake.Session;
using static Nake.Log;
using static Nake.Location;

[Step] void Install()
{
    CheckIfRepoIsPlacedCorrectly();
    CopySourcesToDestinationDir();
}

void CheckIfRepoIsPlacedCorrectly()
{
    if (!NakeScriptDirectory().EndsWith("sbox\\Nostalgia"))
    {
        Fail("It looks like the repository is in the wrong directory. Make sure the repository is cloned at \"...\\steamapps\\common\\sbox\".");
    }
}

void CopySourcesToDestinationDir()
{
    var exclude = new[] { "bin", "obj", "Nostalgia.csproj" };
    var coreDestinationDir = "../addons/nostalgia/code/";
    DirectoryCopy("Nostalgia", coreDestinationDir, exclude);
}

void DirectoryCopy(string sourceDirName, string destDirName, string[] exclude)
{
    var srcDirInfo = new DirectoryInfo(sourceDirName);

    if (!srcDirInfo.Exists)
    {
        throw new DirectoryNotFoundException($"Source directory does not exist or could not be found: {sourceDirName}");
    }

    Directory.CreateDirectory(destDirName);

    var dirs = from dir in srcDirInfo.GetDirectories()
               where !exclude.Contains(dir.Name)
               select dir;
    var files = from file in srcDirInfo.GetFiles()
                where !exclude.Contains(file.Name)
                select file;

    foreach (var file in files)
    {
        var newPath = Path.Combine(destDirName, file.Name);
        Message($"{file} -> {newPath}");
        file.CopyTo(newPath, overwrite: true);
    }

    foreach (var subdir in dirs)
    {
        var newPath = Path.Combine(destDirName, subdir.Name);
        Message($"{subdir} -> {newPath}");
        DirectoryCopy(subdir.FullName, newPath, exclude);
    }
}
