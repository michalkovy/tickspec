﻿module Room

open TickSpec
open NUnit.Framework

type RoomTemperature = RoomTemperature of float
      
let [<Given>] ``room with temperature (.*) degrees`` (f:float) =
    RoomTemperature f

let [<Then>] ``room temperature is (.*) degrees`` (f:float) (RoomTemperature ct) =
    Assert.AreEqual(f, ct)