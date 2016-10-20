using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Microsoft.CSharp;

namespace TOSARunner
{
    static class Runner
    {
        private const string SAMPLES_DIR = "samples";
        private const string INPUT_SEARCH_PATTERN = "input*.txt";
        private const string OUTPUT_SEARCH_PATTERN = "output*.txt";

        private static string _expectedResult;

        static void Main(string[] args)
        {
            if (args == null || args.Length != 1)
            {
                DisplayHelp();
                return;
            }

            var contestPath = args[0];

            var allPrograms = GetAllContestPrograms(contestPath);

            foreach (var programToTest in allPrograms)
            {
                try
                {
                    GenerateAndExecute(programToTest);
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.Write("Error: ");
                    Console.ResetColor();
                    Console.Write(e.Message);
                   
                    
                }
                
            }

            // Console.ReadLine();
        }

        private static IEnumerable<FileInfo> GetAllContestPrograms(string contestPath)
        {
            var dir = new DirectoryInfo(contestPath);
            var allPrograms = dir.GetFiles("Program.cs", SearchOption.AllDirectories);
            return allPrograms;
        }

        private static void GenerateAndExecute(FileInfo programToTest)
        {
            if (programToTest.Directory == null) return;

            Console.WriteLine("##### " + programToTest.Directory.Name + " #####");
            Console.WriteLine();

            var generatedExePath = GeneratedExecutable(programToTest.FullName);
            if (generatedExePath == null)
                return;

            ExecuteExeWithSamples(programToTest, generatedExePath);
            Console.WriteLine();
        }

        private static void ExecuteExeWithSamples(FileInfo programToTest, string generatedExePath)
        {
            try
            {
                if (programToTest.Directory == null) return;

                var samplesPath = Path.Combine(programToTest.Directory.FullName, SAMPLES_DIR);
                var inputFiles = Directory.GetFiles(samplesPath, INPUT_SEARCH_PATTERN);
                var outputFiles = Directory.GetFiles(samplesPath, OUTPUT_SEARCH_PATTERN);

                for (int i = 0; i < inputFiles.Length; i++)
                {
                    var currentInput = inputFiles[i];
                    var currentExpected = outputFiles[i];

                    var filename = Path.GetFileName(currentInput);
                    Console.Write("- " + filename + ": ");
                    var input = File.ReadAllText(currentInput);
                    _expectedResult = File.ReadAllText(currentExpected);

                    StartProcessWithInput(generatedExePath, input);

                    Console.WriteLine();
                }
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("Error: ");
                Console.ResetColor();
                Console.Write(e.Message);
            }

        }

        private static void StartProcessWithInput(string generatedExe, string input)
        {
            var p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardError = true;
            p.OutputDataReceived += OutputHandler;
            p.ErrorDataReceived += OutputErrorHandler;
            p.StartInfo.FileName = generatedExe;
            p.Start();
            p.BeginOutputReadLine();
            p.BeginErrorReadLine();
            p.StandardInput.WriteLine(input);
            p.WaitForExit();
        }

        private static string GeneratedExecutable(string contestPath)
        {
            var generatedExe = contestPath.Replace(" ", ".").Replace(@"/", ".").Trim('.') + ".exe";

            generatedExe = generatedExe.Trim('.');

            var compilerParameters = new CompilerParameters
            {
                GenerateExecutable = true,
                OutputAssembly = generatedExe
            };

            compilerParameters.ReferencedAssemblies.Add("System.dll");
            compilerParameters.ReferencedAssemblies.Add("System.Core.dll");
            compilerParameters.ReferencedAssemblies.Add("System.Drawing.dll");

            var codeProvider = new CSharpCodeProvider(new Dictionary<String, String> { { "CompilerVersion", "v4.0" } });

            var compileResult = codeProvider.CompileAssemblyFromFile(compilerParameters, contestPath);

            if (compileResult.Errors.Count > 0)
            {
                foreach (var error in compileResult.Errors)
                {
                    Console.WriteLine(error.ToString());
                }
                return null;
            }

            return generatedExe;
        }

        private static void OutputHandler(object sender, DataReceivedEventArgs e)
        {
            if (e.Data == null) return;

            if (e.Data != _expectedResult)
            {
                WriteRedResult(e.Data);
            }
            else
            {
                WriteGoodResult(e.Data);
            }

        }

        private static void WriteGoodResult(string result)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("GOOD ");
            Console.ResetColor();
            Console.Write(result);
        }

        private static void WriteRedResult(string result)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("BAD ");
            Console.ResetColor();
            Console.Write(result + " expected to be " + _expectedResult);
        }

        private static void OutputErrorHandler(object sender, DataReceivedEventArgs e)
        {
            if (e.Data == null) return;

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("Error: ");
            Console.ResetColor();
            Console.Write(e.Data);
        }
        private static void DisplayHelp()
        {
            Console.WriteLine("Usage: TOSARunner.exe [contestDirectory]");
        }
    }


}
