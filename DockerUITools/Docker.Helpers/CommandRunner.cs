using System.Diagnostics;

namespace Docker.Helpers;

public static class CommandRunner
{
    public static string RunCommand(string appName, string args)
    {
        var proc = new Process();
        proc.StartInfo.FileName = appName;
        proc.StartInfo.Arguments = args;
        proc.StartInfo.UseShellExecute = false;
        proc.StartInfo.RedirectStandardOutput = true;
        proc.StartInfo.CreateNoWindow = true;
        proc.Start();
        proc.WaitForExit();

        return proc.StandardOutput.ReadToEnd();
    }
}
