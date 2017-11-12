module Room

open TickSpec
open NUnit.Framework

type RoomTemperature = RoomTemperature of int
      
let [<Given>] ``room with temperature (.*) degrees`` (n:int) =
    RoomTemperature n

let [<Then>] ``room temperature is (.*) degrees`` (n:int) (RoomTemperature t) =
    Assert.AreEqual(n, t)