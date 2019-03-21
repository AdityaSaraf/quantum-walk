#pragma warning disable 1591
using System;
using Microsoft.Quantum.Core;
using Microsoft.Quantum.Primitive;
using Microsoft.Quantum.Simulation.Core;

[assembly: Microsoft.Quantum.QsCompiler.Attributes.CallableDeclaration("{\"Kind\":{\"Case\":\"Operation\"},\"QualifiedName\":{\"Namespace\":\"Quantum.Walk\",\"Name\":\"Walk_Test\"},\"SourceFile\":\"C:/Users/Mirt/quantum-walk/QuantumWalk/Tests.qs\",\"Position\":{\"Item1\":19,\"Item2\":4},\"SymbolRange\":{\"Item1\":{\"Line\":1,\"Column\":11},\"Item2\":{\"Line\":1,\"Column\":20}},\"ArgumentTuple\":{\"Case\":\"QsTuple\",\"Fields\":[[]]},\"Signature\":{\"TypeParameters\":[],\"ArgumentType\":{\"Case\":\"UnitType\"},\"ReturnType\":{\"Case\":\"UnitType\"},\"SupportedFunctors\":[]},\"Documentation\":[]}")]
[assembly: Microsoft.Quantum.QsCompiler.Attributes.SpecializationDeclaration("{\"Kind\":{\"Case\":\"QsBody\"},\"Parent\":{\"Namespace\":\"Quantum.Walk\",\"Name\":\"Walk_Test\"},\"SourceFile\":\"C:/Users/Mirt/quantum-walk/QuantumWalk/Tests.qs\",\"Position\":{\"Item1\":19,\"Item2\":4},\"HeaderRange\":{\"Item1\":{\"Line\":1,\"Column\":11},\"Item2\":{\"Line\":1,\"Column\":20}},\"Documentation\":[]}")]
#line hidden
namespace Quantum.Walk
{
    public class Walk_Test : Operation<QVoid, QVoid>, ICallable
    {
        public Walk_Test(IOperationFactory m) : base(m)
        {
        }

        String ICallable.Name => "Walk_Test";
        String ICallable.FullName => "Quantum.Walk.Walk_Test";
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

        protected ICallable<QVoid, Double> MicrosoftQuantumExtensionsMathPI
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

        protected IUnitary<(Double,Qubit)> MicrosoftQuantumPrimitiveRx
        {
            get;
            set;
        }

        protected IUnitary<Qubit> MicrosoftQuantumPrimitiveX
        {
            get;
            set;
        }

        protected IUnitary<Qubit> MicrosoftQuantumPrimitiveY
        {
            get;
            set;
        }

        protected IUnitary<Qubit> MicrosoftQuantumPrimitiveZ
        {
            get;
            set;
        }

        protected ICallable<(QArray<Qubit>,Qubit), QVoid> Walk
        {
            get;
            set;
        }

        public override Func<QVoid, QVoid> Body => (__in__) =>
        {
#line hidden
            {
#line 21 "C:\\Users\\Mirt\\quantum-walk\\QuantumWalk\\Tests.qs"
                var (register,chirality) = (Allocate.Apply(4L), Allocate.Apply());
#line 23 "C:\\Users\\Mirt\\quantum-walk\\QuantumWalk\\Tests.qs"
                MicrosoftQuantumPrimitiveX.Apply(register[(register.Length - 1L)]);
#line 24 "C:\\Users\\Mirt\\quantum-walk\\QuantumWalk\\Tests.qs"
                MicrosoftQuantumExtensionsDiagnosticsDumpMachine.Apply("step0.txt");
#line 25 "C:\\Users\\Mirt\\quantum-walk\\QuantumWalk\\Tests.qs"
                Walk.Apply((register?.Copy(), chirality));
#line 26 "C:\\Users\\Mirt\\quantum-walk\\QuantumWalk\\Tests.qs"
                MicrosoftQuantumExtensionsDiagnosticsDumpMachine.Apply("step1.txt");
#line 27 "C:\\Users\\Mirt\\quantum-walk\\QuantumWalk\\Tests.qs"
                Walk.Apply((register?.Copy(), chirality));
#line 28 "C:\\Users\\Mirt\\quantum-walk\\QuantumWalk\\Tests.qs"
                MicrosoftQuantumExtensionsDiagnosticsDumpMachine.Apply("step2.txt");
#line 29 "C:\\Users\\Mirt\\quantum-walk\\QuantumWalk\\Tests.qs"
                Walk.Apply((register?.Copy(), chirality));
#line 30 "C:\\Users\\Mirt\\quantum-walk\\QuantumWalk\\Tests.qs"
                MicrosoftQuantumExtensionsDiagnosticsDumpMachine.Apply("step3.txt");
#line 31 "C:\\Users\\Mirt\\quantum-walk\\QuantumWalk\\Tests.qs"
                Walk.Apply((register?.Copy(), chirality));
#line 32 "C:\\Users\\Mirt\\quantum-walk\\QuantumWalk\\Tests.qs"
                MicrosoftQuantumExtensionsDiagnosticsDumpMachine.Apply("step4.txt");
#line 33 "C:\\Users\\Mirt\\quantum-walk\\QuantumWalk\\Tests.qs"
                ResetAll.Apply(register?.Copy());
#line 34 "C:\\Users\\Mirt\\quantum-walk\\QuantumWalk\\Tests.qs"
                Reset.Apply(chirality);
#line 35 "C:\\Users\\Mirt\\quantum-walk\\QuantumWalk\\Tests.qs"
                MicrosoftQuantumPrimitiveZ.Apply(chirality);
#line 36 "C:\\Users\\Mirt\\quantum-walk\\QuantumWalk\\Tests.qs"
                MicrosoftQuantumPrimitiveY.Apply(chirality);
#line 37 "C:\\Users\\Mirt\\quantum-walk\\QuantumWalk\\Tests.qs"
                MicrosoftQuantumPrimitiveRx.Apply(((MicrosoftQuantumExtensionsMathPI.Apply(QVoid.Instance) / 2D), chirality));
#line 38 "C:\\Users\\Mirt\\quantum-walk\\QuantumWalk\\Tests.qs"
                MicrosoftQuantumExtensionsDiagnosticsDumpMachine.Apply("BLAH.txt");
#line 39 "C:\\Users\\Mirt\\quantum-walk\\QuantumWalk\\Tests.qs"
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
            this.MicrosoftQuantumExtensionsMathPI = this.Factory.Get<ICallable<QVoid, Double>>(typeof(Microsoft.Quantum.Extensions.Math.PI));
            this.Allocate = this.Factory.Get<Allocate>(typeof(Microsoft.Quantum.Primitive.Allocate));
            this.Release = this.Factory.Get<Release>(typeof(Microsoft.Quantum.Primitive.Release));
            this.Reset = this.Factory.Get<ICallable<Qubit, QVoid>>(typeof(Microsoft.Quantum.Primitive.Reset));
            this.ResetAll = this.Factory.Get<ICallable<QArray<Qubit>, QVoid>>(typeof(Microsoft.Quantum.Primitive.ResetAll));
            this.MicrosoftQuantumPrimitiveRx = this.Factory.Get<IUnitary<(Double,Qubit)>>(typeof(Microsoft.Quantum.Primitive.Rx));
            this.MicrosoftQuantumPrimitiveX = this.Factory.Get<IUnitary<Qubit>>(typeof(Microsoft.Quantum.Primitive.X));
            this.MicrosoftQuantumPrimitiveY = this.Factory.Get<IUnitary<Qubit>>(typeof(Microsoft.Quantum.Primitive.Y));
            this.MicrosoftQuantumPrimitiveZ = this.Factory.Get<IUnitary<Qubit>>(typeof(Microsoft.Quantum.Primitive.Z));
            this.Walk = this.Factory.Get<ICallable<(QArray<Qubit>,Qubit), QVoid>>(typeof(Walk));
        }

        public override IApplyData __dataIn(QVoid data) => data;
        public override IApplyData __dataOut(QVoid data) => data;
        public static System.Threading.Tasks.Task<QVoid> Run(IOperationFactory __m__)
        {
            return __m__.Run<Walk_Test, QVoid, QVoid>(QVoid.Instance);
        }
    }
}