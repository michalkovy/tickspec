module Computer

open TickSpec
open NUnit.Framework
open Room

type ComputerState =
    | Off
    | Booting of int
    | Login

let [<When>] ``computer is started in the room`` () =
    Booting 0

let [<When>] ``computer runs for (.*) minutes`` (time:int) (state:ComputerState) (RoomTemperature temperature) =
    let newState =
        match state with
        | Booting n ->
            if (n + time > 8) then Login else Booting (n + time)
        | _ -> state
    let newTemp = RoomTemperature (temperature + time/5)
    newState, newTemp

let [<Then>] ``computer is on login screen`` (state:ComputerState) =
    Assert.AreEqual(Login, state)