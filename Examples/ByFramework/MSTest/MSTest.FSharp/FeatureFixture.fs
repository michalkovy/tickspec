module NUnit.TickSpec

open TickSpec
open Microsoft.VisualStudio.TestTools.UnitTesting

open System.Reflection
open System.Runtime.ExceptionServices

/// Class containing all BDD tests in current assembly as NUnit unit tests
[<TestClass>]
type FeatureFixture () =
    /// Test method for all BDD tests in current assembly as NUnit unit tests
    [<TestMethod>]
    [<DynamicData("Scenarios")>]
    member __.Bdd (scenario:Scenario) =
        if scenario.Tags |> Seq.exists ((=) "ignore") then
            Assert.Inconclusive("Ignored: " + scenario.ToString())
        try
            scenario.Action.Invoke()
        with
        | :? TargetInvocationException as ex -> ExceptionDispatchInfo.Capture(ex.InnerException).Throw()

    /// All test scenarios from feature files in current assembly
    static member Scenarios =
        let assembly = Assembly.GetExecutingAssembly()
        let definitions = new StepDefinitions(assembly.GetTypes())

        assembly.GetManifestResourceNames()
        |> Seq.filter (fun (n:string) -> n.EndsWith(".feature") )
        |> Seq.collect (fun n ->
            definitions.GenerateFeature(n, assembly.GetManifestResourceStream(n)).Scenarios )
        |> Seq.map (fun i -> [| i |] )