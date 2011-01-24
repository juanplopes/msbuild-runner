using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Build.Utilities;
using System.Diagnostics;

namespace MSBuildRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            var msbuild = ToolLocationHelper.GetPathToDotNetFrameworkFile("msbuild.exe", TargetDotNetFrameworkVersion.VersionLatest);
            var newArgs = string.Join(" ", args.Select(x => "\"" + x + "\"").ToArray());
            Console.WriteLine("{0} {1}", msbuild, newArgs);
            var psi = new ProcessStartInfo(msbuild, newArgs);
            psi.UseShellExecute = false;
            var p = Process.Start(psi);
            p.WaitForExit();
        }
    }
}
