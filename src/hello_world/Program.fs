// Learn more about F# at http://fsharp.org

open Suave

[<EntryPoint>]
let main _ =
    let config = { defaultConfig with bindings = [ HttpBinding.createSimple HTTP "0.0.0.0" 8080 ]}
    startWebServer config (Successful.OK "Hello World!")
    0