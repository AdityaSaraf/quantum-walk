namespace Quantum.Walk {
    
    open Microsoft.Quantum.Primitive;
    open Microsoft.Quantum.Canon;
    open Microsoft.Quantum.Extensions.Convert;
    open Microsoft.Quantum.Extensions.Math;
    open Microsoft.Quantum.Extensions.Testing;
    open Microsoft.Quantum.Extensions.Diagnostics;
    
    //////////////////////////////////////////////////////////////////
    // This is the set of programming assignments for week 4.
    //////////////////////////////////////////////////////////////////

    operation Walk(register : Qubit[], chirality: Qubit) : Unit {
        H(chirality);
        let n = Length(register);
        let modulus = 2^n;
        // translate by +1 if chirality is 0
        (ControlledOnInt(0, ModularIncrementLE))([chirality], (1, modulus, LittleEndian(register)));
        // translate by -1 if chirality is 1
        (ControlledOnInt(1, Adjoint ModularIncrementLE))([chirality], (1, modulus, LittleEndian(register)));
    }



    operation WalkRun(numSteps : Int, numQubits: Int) : Unit {
        using ((register, chirality) = (Qubit[numQubits], Qubit())) {
            // set register to n/2
            X(register[Length(register)-1]);
            DumpMachine("step0.txt");
            for (i in 1..numSteps) {
                Walk(register, chirality);
                // Message(str2);
                DumpMachine($"step{i}.txt");
            }
            ResetAll(register);
            Reset(chirality);
        }
    }

	operation BalancedWalk(register : Qubit[], chirality: Qubit) : Unit {
		// implements the following balanced transformation: [1  i]
		//													 [i  1]

		Z(chirality);
		Y(chirality);
		Rx(PI()/2.0, chirality);
        let n = Length(register);
        let modulus = 2^n;
        // translate by +1 if chirality is 0
        (ControlledOnInt(0, ModularIncrementLE))([chirality], (1, modulus, LittleEndian(register)));
        // translate by -1 if chirality is 1
        (ControlledOnInt(1, Adjoint ModularIncrementLE))([chirality], (1, modulus, LittleEndian(register)));
	}


	operation BalancedWalkRun(numSteps : Int, numQubits: Int) : Unit {
        using ((register, chirality) = (Qubit[numQubits], Qubit())) {
            // set register to n/2
            X(register[Length(register)-1]);
			H(chirality);
            DumpMachine("balanced-step0.txt");
            for (i in 1..numSteps) {
                BalancedWalk(register, chirality);
                // Message(str2);
                DumpMachine($"balanced-step{i}.txt");
            }
            ResetAll(register);
            Reset(chirality);
        }
	}
    
}
