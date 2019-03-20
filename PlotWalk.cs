// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license.

using Microsoft.Quantum.Simulation.XUnit;
using Microsoft.Quantum.Simulation.Simulators;
using Xunit.Abstractions;
using System.Diagnostics;
using System;

namespace Quantum.Walk
{
    // public class TestSuiteRunner
    // {
    //     private readonly ITestOutputHelper output;

    //     public TestSuiteRunner(ITestOutputHelper output)
    //     {
    //         this.output = output;
    //     }

    //     /// <summary>
    //     /// This driver will run all Q# tests (operations named "...Test") 
    //     /// that belong to namespace Quantum.Walk.
    //     /// </summary>
    //     // [OperationDriver(TestNamespace = "Quantum.Walk")]
    //     public void TestTarget(TestOperation op)
    //     {
    //         using (var sim = new QuantumSimulator())
    //         {
    //             // OnLog defines action(s) performed when Q# test calls function Message
    //             sim.OnLog += (msg) => { output.WriteLine(msg); };
    //             sim.OnLog += (msg) => { Debug.WriteLine(msg); };
    //             op.TestOperationRunner(sim);
    //         }
    //     }
    // }

    class Program
    {        
        static void Main(string[] args)
        {   
            using (var qsim = new QuantumSimulator())
            {
                WalkRun.Run(qsim, 15, 5);                
            }
            Console.WriteLine("hello");
        }
    }
}
