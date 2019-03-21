#pragma warning disable 1591
using System;
using Microsoft.Quantum.Core;
using Microsoft.Quantum.Primitive;
using Microsoft.Quantum.Simulation.Core;

[assembly: Microsoft.Quantum.QsCompiler.Attributes.CallableDeclaration("{\"Kind\":{\"Case\":\"Operation\"},\"QualifiedName\":{\"Namespace\":\"Quantum.Walk\",\"Name\":\"Walk\"},\"SourceFile\":\"C:/Users/Mirt/quantum-walk/QuantumWalk/Walk.qs\",\"Position\":{\"Item1\":13,\"Item2\":4},\"SymbolRange\":{\"Item1\":{\"Line\":1,\"Column\":11},\"Item2\":{\"Line\":1,\"Column\":15}},\"ArgumentTuple\":{\"Case\":\"QsTuple\",\"Fields\":[[{\"Case\":\"QsTupleItem\",\"Fields\":[{\"VariableName\":{\"Case\":\"ValidName\",\"Fields\":[\"register\"]},\"Type\":{\"Case\":\"ArrayType\",\"Fields\":[{\"Case\":\"Qubit\"}]},\"IsMutable\":false,\"HasLocalQuantumDependency\":false,\"Position\":{\"Case\":\"Null\"},\"Range\":{\"Item1\":{\"Line\":1,\"Column\":16},\"Item2\":{\"Line\":1,\"Column\":24}}}]},{\"Case\":\"QsTupleItem\",\"Fields\":[{\"VariableName\":{\"Case\":\"ValidName\",\"Fields\":[\"chirality\"]},\"Type\":{\"Case\":\"Qubit\"},\"IsMutable\":false,\"HasLocalQuantumDependency\":false,\"Position\":{\"Case\":\"Null\"},\"Range\":{\"Item1\":{\"Line\":1,\"Column\":36},\"Item2\":{\"Line\":1,\"Column\":45}}}]}]]},\"Signature\":{\"TypeParameters\":[],\"ArgumentType\":{\"Case\":\"TupleType\",\"Fields\":[[{\"Case\":\"ArrayType\",\"Fields\":[{\"Case\":\"Qubit\"}]},{\"Case\":\"Qubit\"}]]},\"ReturnType\":{\"Case\":\"UnitType\"},\"SupportedFunctors\":[]},\"Documentation\":[]}")]
[assembly: Microsoft.Quantum.QsCompiler.Attributes.SpecializationDeclaration("{\"Kind\":{\"Case\":\"QsBody\"},\"Parent\":{\"Namespace\":\"Quantum.Walk\",\"Name\":\"Walk\"},\"SourceFile\":\"C:/Users/Mirt/quantum-walk/QuantumWalk/Walk.qs\",\"Position\":{\"Item1\":13,\"Item2\":4},\"HeaderRange\":{\"Item1\":{\"Line\":1,\"Column\":11},\"Item2\":{\"Line\":1,\"Column\":15}},\"Documentation\":[]}")]
[assembly: Microsoft.Quantum.QsCompiler.Attributes.CallableDeclaration("{\"Kind\":{\"Case\":\"Operation\"},\"QualifiedName\":{\"Namespace\":\"Quantum.Walk\",\"Name\":\"WalkRun\"},\"SourceFile\":\"C:/Users/Mirt/quantum-walk/QuantumWalk/Walk.qs\",\"Position\":{\"Item1\":23,\"Item2\":4},\"SymbolRange\":{\"Item1\":{\"Line\":1,\"Column\":11},\"Item2\":{\"Line\":1,\"Column\":18}},\"ArgumentTuple\":{\"Case\":\"QsTuple\",\"Fields\":[[{\"Case\":\"QsTupleItem\",\"Fields\":[{\"VariableName\":{\"Case\":\"ValidName\",\"Fields\":[\"numSteps\"]},\"Type\":{\"Case\":\"Int\"},\"IsMutable\":false,\"HasLocalQuantumDependency\":false,\"Position\":{\"Case\":\"Null\"},\"Range\":{\"Item1\":{\"Line\":1,\"Column\":19},\"Item2\":{\"Line\":1,\"Column\":27}}}]},{\"Case\":\"QsTupleItem\",\"Fields\":[{\"VariableName\":{\"Case\":\"ValidName\",\"Fields\":[\"numQubits\"]},\"Type\":{\"Case\":\"Int\"},\"IsMutable\":false,\"HasLocalQuantumDependency\":false,\"Position\":{\"Case\":\"Null\"},\"Range\":{\"Item1\":{\"Line\":1,\"Column\":35},\"Item2\":{\"Line\":1,\"Column\":44}}}]}]]},\"Signature\":{\"TypeParameters\":[],\"ArgumentType\":{\"Case\":\"TupleType\",\"Fields\":[[{\"Case\":\"Int\"},{\"Case\":\"Int\"}]]},\"ReturnType\":{\"Case\":\"UnitType\"},\"SupportedFunctors\":[]},\"Documentation\":[]}")]
[assembly: Microsoft.Quantum.QsCompiler.Attributes.SpecializationDeclaration("{\"Kind\":{\"Case\":\"QsBody\"},\"Parent\":{\"Namespace\":\"Quantum.Walk\",\"Name\":\"WalkRun\"},\"SourceFile\":\"C:/Users/Mirt/quantum-walk/QuantumWalk/Walk.qs\",\"Position\":{\"Item1\":23,\"Item2\":4},\"HeaderRange\":{\"Item1\":{\"Line\":1,\"Column\":11},\"Item2\":{\"Line\":1,\"Column\":18}},\"Documentation\":[]}")]
#line hidden
namespace Quantum.Walk
{
    public class Walk : Operation<(QArray<Qubit>,Qubit), QVoid>, ICallable
    {
        public Walk(IOperationFactory m) : base(m)
        {
        }

        public class In : QTuple<(QArray<Qubit>,Qubit)>, IApplyData
        {
            public In((QArray<Qubit>,Qubit) data) : base(data)
            {
            }

            System.Collections.Generic.IEnumerable<Qubit> IApplyData.Qubits => Qubit.Concat(((IApplyData)Data.Item1)?.Qubits, ((IApplyData)Data.Item2)?.Qubits);
        }

        String ICallable.Name => "Walk";
        String ICallable.FullName => "Quantum.Walk.Walk";
        protected ICallable MicrosoftQuantumCanonControlledOnInt
        {
            get;
            set;
        }

        protected IUnitary<(Int64,Int64,Microsoft.Quantum.Canon.LittleEndian)> MicrosoftQuantumCanonModularIncrementLE
        {
            get;
            set;
        }

        protected ICallable Length
        {
            get;
            set;
        }

        protected IUnitary<Qubit> MicrosoftQuantumPrimitiveH
        {
            get;
            set;
        }

        public override Func<(QArray<Qubit>,Qubit), QVoid> Body => (__in__) =>
        {
            var (register,chirality) = __in__;
#line 15 "C:\\Users\\Mirt\\quantum-walk\\QuantumWalk\\Walk.qs"
            MicrosoftQuantumPrimitiveH.Apply(chirality);
#line 16 "C:\\Users\\Mirt\\quantum-walk\\QuantumWalk\\Walk.qs"
            var n = register.Length;
#line 17 "C:\\Users\\Mirt\\quantum-walk\\QuantumWalk\\Walk.qs"
            var modulus = 2L.Pow(n);
#line 19 "C:\\Users\\Mirt\\quantum-walk\\QuantumWalk\\Walk.qs"
            MicrosoftQuantumCanonControlledOnInt.Apply<IUnitary>((0L, MicrosoftQuantumCanonModularIncrementLE)).Apply((new QArray<Qubit>()
            {chirality}, (1L, modulus, new Microsoft.Quantum.Canon.LittleEndian(register?.Copy()))));
#line 21 "C:\\Users\\Mirt\\quantum-walk\\QuantumWalk\\Walk.qs"
            MicrosoftQuantumCanonControlledOnInt.Apply<IUnitary>((1L, MicrosoftQuantumCanonModularIncrementLE.Adjoint)).Apply((new QArray<Qubit>()
            {chirality}, (1L, modulus, new Microsoft.Quantum.Canon.LittleEndian(register?.Copy()))));
#line hidden
            return QVoid.Instance;
        }

        ;
        public override void Init()
        {
            this.MicrosoftQuantumCanonControlledOnInt = this.Factory.Get<ICallable>(typeof(Microsoft.Quantum.Canon.ControlledOnInt<>));
            this.MicrosoftQuantumCanonModularIncrementLE = this.Factory.Get<IUnitary<(Int64,Int64,Microsoft.Quantum.Canon.LittleEndian)>>(typeof(Microsoft.Quantum.Canon.ModularIncrementLE));
            this.Length = this.Factory.Get<ICallable>(typeof(Microsoft.Quantum.Core.Length<>));
            this.MicrosoftQuantumPrimitiveH = this.Factory.Get<IUnitary<Qubit>>(typeof(Microsoft.Quantum.Primitive.H));
        }

        public override IApplyData __dataIn((QArray<Qubit>,Qubit) data) => new In(data);
        public override IApplyData __dataOut(QVoid data) => data;
        public static System.Threading.Tasks.Task<QVoid> Run(IOperationFactory __m__, QArray<Qubit> register, Qubit chirality)
        {
            return __m__.Run<Walk, (QArray<Qubit>,Qubit), QVoid>((register, chirality));
        }
    }

    public class WalkRun : Operation<(Int64,Int64), QVoid>, ICallable
    {
        public WalkRun(IOperationFactory m) : base(m)
        {
        }

        public class In : QTuple<(Int64,Int64)>, IApplyData
        {
            public In((Int64,Int64) data) : base(data)
            {
            }

            System.Collections.Generic.IEnumerable<Qubit> IApplyData.Qubits => null;
        }

        String ICallable.Name => "WalkRun";
        String ICallable.FullName => "Quantum.Walk.WalkRun";
        protected ICallable Length
        {
            get;
            set;
        }

        protected ICallable MicrosoftQuantumExtensionsDiagnosticsDumpMachine
        {
            get;
            set;
        }

        protected Allocate Allocate
        {
            get;
            set;
        }

        protected Release Release
        {
            get;
            set;
        }

        protected ICallable<Qubit, QVoid> Reset
        {
            get;
            set;
        }

        protected ICallable<QArray<Qubit>, QVoid> ResetAll
        {
            get;
            set;
        }

        protected IUnitary<Qubit> MicrosoftQuantumPrimitiveX
        {
            get;
            set;
        }

        protected ICallable<(QArray<Qubit>,Qubit), QVoid> Walk
        {
            get;
            set;
        }

        public override Func<(Int64,Int64), QVoid> Body => (__in__) =>
        {
            var (numSteps,numQubits) = __in__;
#line hidden
            {
#line 25 "C:\\Users\\Mirt\\quantum-walk\\QuantumWalk\\Walk.qs"
                var (register,chirality) = (Allocate.Apply(numQubits), Allocate.Apply());
#line 27 "C:\\Users\\Mirt\\quantum-walk\\QuantumWalk\\Walk.qs"
                MicrosoftQuantumPrimitiveX.Apply(register[(register.Length - 1L)]);
#line 28 "C:\\Users\\Mirt\\quantum-walk\\QuantumWalk\\Walk.qs"
                MicrosoftQuantumExtensionsDiagnosticsDumpMachine.Apply("step0.txt");
#line 29 "C:\\Users\\Mirt\\quantum-walk\\QuantumWalk\\Walk.qs"
                foreach (var i in new Range(1L, numSteps))
#line hidden
                {
#line 30 "C:\\Users\\Mirt\\quantum-walk\\QuantumWalk\\Walk.qs"
                    Walk.Apply((register?.Copy(), chirality));
#line 32 "C:\\Users\\Mirt\\quantum-walk\\QuantumWalk\\Walk.qs"
                    MicrosoftQuantumExtensionsDiagnosticsDumpMachine.Apply(String.Format("step{0}.txt", i));
                }

#line 34 "C:\\Users\\Mirt\\quantum-walk\\QuantumWalk\\Walk.qs"
                ResetAll.Apply(register?.Copy());
#line 35 "C:\\Users\\Mirt\\quantum-walk\\QuantumWalk\\Walk.qs"
                Reset.Apply(chirality);
#line hidden
                Release.Apply(register);
#line hidden
                Release.Apply(chirality);
            }

#line hidden
            return QVoid.Instance;
        }

        ;
        public override void Init()
        {
            this.Length = this.Factory.Get<ICallable>(typeof(Microsoft.Quantum.Core.Length<>));
            this.MicrosoftQuantumExtensionsDiagnosticsDumpMachine = this.Factory.Get<ICallable>(typeof(Microsoft.Quantum.Extensions.Diagnostics.DumpMachine<>));
            this.Allocate = this.Factory.Get<Allocate>(typeof(Microsoft.Quantum.Primitive.Allocate));
            this.Release = this.Factory.Get<Release>(typeof(Microsoft.Quantum.Primitive.Release));
            this.Reset = this.Factory.Get<ICallable<Qubit, QVoid>>(typeof(Microsoft.Quantum.Primitive.Reset));
            this.ResetAll = this.Factory.Get<ICallable<QArray<Qubit>, QVoid>>(typeof(Microsoft.Quantum.Primitive.ResetAll));
            this.MicrosoftQuantumPrimitiveX = this.Factory.Get<IUnitary<Qubit>>(typeof(Microsoft.Quantum.Primitive.X));
            this.Walk = this.Factory.Get<ICallable<(QArray<Qubit>,Qubit), QVoid>>(typeof(Walk));
        }

        public override IApplyData __dataIn((Int64,Int64) data) => new In(data);
        public override IApplyData __dataOut(QVoid data) => data;
        public static System.Threading.Tasks.Task<QVoid> Run(IOperationFactory __m__, Int64 numSteps, Int64 numQubits)
        {
            return __m__.Run<WalkRun, (Int64,Int64), QVoid>((numSteps, numQubits));
        }
    }
}