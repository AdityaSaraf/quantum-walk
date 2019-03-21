// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license.

using Microsoft.Quantum.Simulation.XUnit;
using Microsoft.Quantum.Simulation.Simulators;
using Xunit.Abstractions;
using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Globalization;

namespace Quantum.Walk
{
    public class TestSuiteRunner
    {
        private readonly ITestOutputHelper output;

        public TestSuiteRunner(ITestOutputHelper output)
        {
            this.output = output;
        }

        /// <summary>
        /// This driver will run all Q# tests (operations named "...Test") 
        /// that belong to namespace Quantum.Walk.
        /// </summary>
        // [OperationDriver(TestNamespace = "Quantum.Walk")]
        public void TestTarget(TestOperation op)
        {
            using (var sim = new QuantumSimulator())
            {
                // OnLog defines action(s) performed when Q# test calls function Message
                sim.OnLog += (msg) => { output.WriteLine(msg); };
                sim.OnLog += (msg) => { Debug.WriteLine(msg); };
                op.TestOperationRunner(sim);
            }
        }
    }

    class Program
    {        
        static void Main(string[] args)
        {   
            int numSteps = 30;
            int numBits = 6;
            using (var qsim = new QuantumSimulator())
            {
                var result = WalkRun.Run(qsim, numSteps, numBits).Result;
                for (int i = 0; i <= numSteps; i++) {
                    var dump = File.ReadAllLines($"step{i}.txt");
                    dump = dump.Skip(1).ToArray();
                    Dictionary<double, double> dict = ParseDumpFile(dump);
                    Console.WriteLine(String.Join(";" , dict));
                }
            }

            for (int i = 0; i <= numSteps; i++) {
                Dictionary<double, double> dict = ClassicalRandomWalk(numSteps, numBits);
                Console.WriteLine(String.Join(";" , dict));
            }
        }

        static Dictionary<double, double> ClassicalRandomWalk(int numSteps, int numBits) {
            double startPos = Math.Pow(2, numBits - 1);
            double currPos;
            Dictionary<double, double> probDict = new Dictionary<double, double>();
            Dictionary<double, int> countDict = new Dictionary<double, int>();
            Random rand = new Random();
            int numTrials = 1000000;
            for (int i = 0; i < Math.Pow(2, numBits); i++) {
                probDict[i] = 0;
            }
            for (int i = 0; i < numTrials; i++) {
                currPos = startPos;
                for (int j = 0; j < numSteps; j++) {
                    if (rand.NextDouble() > 0.5) {
                        currPos++;
                    } else {
                        currPos--;
                    }
                }
                if (!countDict.ContainsKey(currPos)) {
                    countDict[currPos] = 0;
                }
                countDict[currPos]++;
            }
            foreach (var num in countDict.Keys) {
                probDict[num] = (double)countDict[num]/numTrials;
            }
            return probDict;
        }

        static Dictionary<double, double> ParseDumpFile(String[] dump) {
            Dictionary<double, double> dict = new Dictionary<double, double>();
            int offset = dump.Length/2;
            for (int i = 0; i < dump.Length/2; i++) {
                string line = dump[i];
                (double num, double prob) = ParseLine(line);
                string offsetLine = dump[i+offset];
                (double offsetNum, double offsetProb) = ParseLine(offsetLine);
                double finalProb = prob + offsetProb;
                if (finalProb < 0.0000005) {
                    finalProb = 0;
                }
                dict[num] = finalProb;
            }
            return dict;
        }
        
        static (double, double) ParseLine(String line) {
            string[] arr = line.Split("\t", 3);
            double num = Int32.Parse(arr[0].Remove(arr[0].Length-1));
            double prob = Double.Parse(arr[1], NumberStyles.Float);
            // need to square the amplitude to get the probability. this also ensures it's positive
            prob *= prob;
            return (num, prob);
        }
    }
}
