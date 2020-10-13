using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace InterviewPreparationKit
{
    public static class _2DArrayDS
    {
        // Complete the hourglassSum function below.
        public static int HourglassSum(int[][] arr)
        {
            // n - rows
            // m - columns
            // must be: n == m
            int n = arr.Length;
            int m = arr[0].Length;
            const int hourglassN = 3;
            const int hourglassM = 3;

            int hourglassCount = (n - hourglassN + 1) * (m - hourglassM + 1);
            var sums = new List<int>(hourglassCount);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    bool isHourglassAnchor =
                            i < (n - hourglassN + 1) &&
                            j < (m - hourglassM + 1);

                    if (isHourglassAnchor)
                    {
                        int sum =
                            arr[i][j]     + arr[i][j + 1]     + arr[i][j + 2]      +
                                            arr[i + 1][j + 1]                      +
                            arr[i + 2][j] + arr[i + 2][j + 1] + arr[i + 2][j + 2];
                        
                        sums.Add(sum);
                    }
                }
            }

            return sums.Max();
        }

        public static void Run()
        {
            string taskName = nameof(_2DArrayDS);

            string inputDirectoryPath = "./InputData";
            string inputPath = Path.Combine(inputDirectoryPath, "_2DArrayDS.txt");
            string outpuDirectoryPath = "./OutputData";
            string outputPath = Path.Combine(outpuDirectoryPath, "_2DArrayDS.txt");

            if (!Directory.Exists(inputDirectoryPath))
            {
                Directory.CreateDirectory(inputDirectoryPath);
            }
            if (!Directory.Exists(outpuDirectoryPath))
            {
                Directory.CreateDirectory(outpuDirectoryPath);
            }

            int[][] arr = new int[6][];

            TextReader textReader = new StreamReader(inputPath, true);
            for (int i = 0; i < 6; i++)
            {
                string line = textReader.ReadLine();
                arr[i] = Array.ConvertAll(line.Split(' '), arrTemp => Convert.ToInt32(arrTemp));
            }

            int result = HourglassSum(arr);

            TextWriter textWriter = new StreamWriter(outputPath, true);
            textWriter.WriteLine(result);

            textWriter.Flush();
            textWriter.Close();

            Console.WriteLine($"Task {taskName}:");
            Console.WriteLine($"Result: {result}.");
            Console.ReadKey();
        }
    }
}
