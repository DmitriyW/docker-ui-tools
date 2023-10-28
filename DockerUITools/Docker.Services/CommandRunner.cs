using Docker.Abstractions.Services;
using System.Diagnostics;

namespace Docker.Services
{
    public class CommandRunner : ICommandRunner
    {
        public string RunCommand(string appName, string args)
        {
            var proc = new Process();
            proc.StartInfo.FileName = appName;
            proc.StartInfo.Arguments = args;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.CreateNoWindow = true;
            proc.Start();
            var result = proc.StandardOutput.ReadToEnd();
            proc.Close();
            proc.Dispose();

            Thread.Sleep(200);

            return result;
        }
    }
}
