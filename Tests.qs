// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license.

namespace Quantum.Week4 {
    
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


    operation T11_Test() : Unit {
        let numQubits = 2;
        let testSize = Truncate(PowD(2.0, ToDouble(numQubits)));
        mutable results = new Result[testSize];
        for (i in 0..testSize - 1) {
            using ((qs, target) = (Qubit[numQubits], Qubit())) {
                let bitstring = BoolArrFromPositiveInt(i, numQubits);
                ApplyPauliFromBitString(PauliX, true, bitstring, Reverse(qs));
                Task11(qs, target);
                set results[i] = M(target);
                ResetAll(qs);
                Reset(target);
            }
        }
        let expected = [false, false, false, true];
        AssertBoolArrayEqual(BoolArrFromResultArr(results), [false, false, false, true], $"Got: {results}, Expected: {expected}");
    }

    operation T12_Test() : Unit {
        let numQubits = 2;
        let testSize = Truncate(PowD(2.0, ToDouble(numQubits)));
        mutable results = new Result[testSize];
        for (i in 0..testSize - 1) {
            using ((qs, target) = (Qubit[numQubits], Qubit())) {
                let bitstring = BoolArrFromPositiveInt(i, numQubits);
                ApplyPauliFromBitString(PauliX, true, bitstring, Reverse(qs));
                Task12(qs, target);
                set results[i] = M(target);
                ResetAll(qs);
                Reset(target);
            }
        }
        let expected = [false, true, true, true];
        AssertBoolArrayEqual(BoolArrFromResultArr(results), expected, $"Got: {results}, Expected: {expected}");
    }

    operation T13_Test() : Unit {
        let numQubits = 2;
        let testSize = Truncate(PowD(2.0, ToDouble(numQubits)));
        mutable results = new Result[testSize];
        for (i in 0..testSize - 1) {
            using ((qs, target) = (Qubit[numQubits], Qubit())) {
                let bitstring = BoolArrFromPositiveInt(i, numQubits);
                ApplyPauliFromBitString(PauliX, true, bitstring, Reverse(qs));
                Task13(qs, target);
                set results[i] = M(target);
                ResetAll(qs);
                Reset(target);
            }
        }
        let expected = [false, true, true, false];
        AssertBoolArrayEqual(BoolArrFromResultArr(results), expected, $"Got: {results}, Expected: {expected}");
    }

    operation T13Pt2_Test() : Unit {
        let numQubits = 3;
        let testSize = Truncate(PowD(2.0, ToDouble(numQubits)));
        mutable results = new Result[testSize];
        for (i in 0..testSize - 1) {
            using ((qs, target) = (Qubit[numQubits], Qubit())) {
                let bitstring = BoolArrFromPositiveInt(i, numQubits);
                ApplyPauliFromBitString(PauliX, true, bitstring, Reverse(qs));
                Task13(qs, target);
                set results[i] = M(target);
                ResetAll(qs);
                Reset(target);
            }
        }
        let expected = [false, true, true, false, true, false, false, false];
        AssertBoolArrayEqual(BoolArrFromResultArr(results), expected, $"Got: {results}, Expected: {expected}");
    }

    operation T14_Test() : Unit {
        let numQubits = 3;
        let testSize = 2^3;
        let pattern = [0, -1, 1];
        mutable results = new Result[testSize];
        for (i in 0..testSize - 1) {
            using ((qs, target) = (Qubit[numQubits], Qubit())) {
                let bitstring = BoolArrFromPositiveInt(i, numQubits);
                // the reversal turns the little endian bitstring into big endian encoding
                ApplyPauliFromBitString(PauliX, true, bitstring, Reverse(qs));
                Task14(qs, target, pattern);
                set results[i] = M(target);
                ResetAll(qs);
                Reset(target);
            }
        }
        let expected = [false, true, false, true, false, false, false, false];
        AssertBoolArrayEqual(BoolArrFromResultArr(results), expected, $"Got: {results}, Expected: {expected}");
    }

    operation T14Pt2_Test() : Unit {
        let numQubits = 3;
        let testSize = Truncate(PowD(2.0, ToDouble(numQubits)));
        let pattern = [-1, -1, 1];
        mutable results = new Result[testSize];
        for (i in 0..testSize - 1) {
            using ((qs, target) = (Qubit[numQubits], Qubit())) {
                let bitstring = BoolArrFromPositiveInt(i, numQubits);
                // the reversal turns the little endian bitstring into big endian encoding
                ApplyPauliFromBitString(PauliX, true, bitstring, Reverse(qs));
                Task14(qs, target, pattern);
                set results[i] = M(target);
                ResetAll(qs);
                Reset(target);
            }
        }
        let expected = [false, true, false, true, false, true, false, true];
        AssertBoolArrayEqual(BoolArrFromResultArr(results), expected, $"Got: {results}, Expected: {expected}");
    }

    operation T15_Test() : Unit {
        let numQubits = 3;
        let testSize = Truncate(PowD(2.0, ToDouble(numQubits)));
        let pattern = [false, true];
        mutable results = new Result[testSize];
        for (i in 0..testSize - 1) {
            using ((qs, target) = (Qubit[numQubits], Qubit())) {
                let bitstring = BoolArrFromPositiveInt(i, numQubits);
                // the reversal turns the little endian bitstring into big endian encoding
                ApplyPauliFromBitString(PauliX, true, bitstring, Reverse(qs));
                Task15(qs, target, pattern);
                set results[i] = M(target);
                ResetAll(qs);
                Reset(target);
            }
        }
        let expected = [false, true, true, true, false, true, false, false];
        AssertBoolArrayEqual(BoolArrFromResultArr(results), expected, $"Got: {results}, Expected: {expected}");
    }

    operation T15Pt2_Test() : Unit {
        let numQubits = 3;
        let testSize = Truncate(PowD(2.0, ToDouble(numQubits)));
        let pattern = [false];
        mutable results = new Result[testSize];
        for (i in 0..testSize - 1) {
            using ((qs, target) = (Qubit[numQubits], Qubit())) {
                let bitstring = BoolArrFromPositiveInt(i, numQubits);
                // the reversal turns the little endian bitstring into big endian encoding
                ApplyPauliFromBitString(PauliX, true, bitstring, Reverse(qs));
                Task15(qs, target, pattern);
                set results[i] = M(target);
                ResetAll(qs);
                Reset(target);
            }
        }
        let expected = [true, true, true, true, true, true, true, false];
        AssertBoolArrayEqual(BoolArrFromResultArr(results), expected, $"Got: {results}, Expected: {expected}");
    }
    
    operation T15Pt3_Test() : Unit {
        let numQubits = 3;
        let testSize = Truncate(PowD(2.0, ToDouble(numQubits)));
        let pattern = [true, false, true];
        mutable results = new Result[testSize];
        for (i in 0..testSize - 1) {
            using ((qs, target) = (Qubit[numQubits], Qubit())) {
                let bitstring = BoolArrFromPositiveInt(i, numQubits);
                // the reversal turns the little endian bitstring into big endian encoding
                ApplyPauliFromBitString(PauliX, true, bitstring, Reverse(qs));
                Task15(qs, target, pattern);
                set results[i] = M(target);
                ResetAll(qs);
                Reset(target);
            }
        }
        let expected = [false, false, false, false, false, true, false, false];
        AssertBoolArrayEqual(BoolArrFromResultArr(results), expected, $"Got: {results}, Expected: {expected}");
    }

    operation T31_Test() : Unit {
        using (qs = Qubit[2]) {
            Task31(qs);
            DumpMachine("t31.txt");
            ResetAll(qs);
        }
    }

    operation T32_Test() : Unit {
        using (qs = Qubit[2]) {
            Task32(qs);
            DumpMachine("t32.txt");
            ResetAll(qs);
        }
    }

    operation T33_Test() : Unit {
        using (qs = Qubit[2]) {
            Task33(qs); 
            DumpMachine("t33.txt");
            ResetAll(qs);
        }
    }
        
}
