using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Build.Utilities;
using System.Diagnostics;

namespace MSBuildRunner
{
    class Program
    {
        static int Main(string[] args)
        {
            var msbuild = ToolLocationHelper.GetPathToDotNetFrameworkFile("msbuild.exe", TargetDotNetFrameworkVersion.VersionLatest);

            for (int i = 0; i < args.Length; i++)
                args[i] = "\"" + args[i] + "\"";

            var newArgs = string.Join(" ", args);
            Console.WriteLine("{0} {1}", msbuild, newArgs);
            var psi = new ProcessStartInfo(msbuild, newArgs);
            psi.UseShellExecute = false;
            var p = Process.Start(psi);
            p.WaitForExit();
            return p.ExitCode;
        }
    }
}
