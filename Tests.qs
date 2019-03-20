// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license.

namespace Quantum.Walk {
    
    open Microsoft.Quantum.Primitive;
    open Microsoft.Quantum.Canon;
    open Microsoft.Quantum.Extensions.Convert;
    open Microsoft.Quantum.Extensions.Math;
    open Microsoft.Quantum.Extensions.Testing;
    open Microsoft.Quantum.Extensions.Diagnostics;
    

    //////////////////////////////////////////////////////////////////
    // Here are several examples of how you can run and test
    // your solutions to the programming assignments in Q#.
    //////////////////////////////////////////////////////////////////


    operation Walk_Test() : Unit {
        using ((register, chirality) = (Qubit[4], Qubit())) {
            // set register to n/2
            X(register[Length(register)-1]);
            DumpMachine("step0.txt");
            Walk(register, chirality);
            DumpMachine("step1.txt");
            Walk(register, chirality);
            DumpMachine("step2.txt");
            Walk(register, chirality);
            DumpMachine("step3.txt");
            Walk(register, chirality);
            DumpMachine("step4.txt");
            ResetAll(register);
            Reset(chirality);
        }
    }        
}
