#r "paket: groupref Build"
#load ".fake/build.fsx/intellisense.fsx"

open Fake.Core

Target.create "Clean" (fun _ ->
    Trace.log "-- Clean --"
)

Target.create "Build" (fun _ ->
    Trace.log "-- Build --"
)

Target.create "Deploy" (fun _ ->
    Trace.log "-- Deploy --"
)

open Fake.Core.TargetOperators

"Clean"
    ==> "Build"
    ==> "Deploy"

Target.runOrDefault "Deploy"