namespace TickSpec

open System
open System.Collections.Generic
open System.Diagnostics
open BoDi

/// Creates instance service provider
[<Sealed>]
type ServiceProvider () =
    let container = new ObjectContainer()
    /// Type instances constructed for invoked steps
    let instances = Dictionary<_,_>()
    /// Gets type instance for specified type
    [<DebuggerStepThrough>]
    let getInstance (t:Type) =
        match instances.TryGetValue t with
        | true, instance -> instance
        | false, _ ->
            let instance = container.Resolve t
            instances.Add(t,instance)
            instance
    interface System.IServiceProvider with
        [<DebuggerStepThrough>]
        member this.GetService(t:Type) =
            getInstance t
    interface IDisposable with
        member this.Dispose() =
            container.Dispose()

