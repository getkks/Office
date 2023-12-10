namespace Office.Runtime

open System
open System.Linq
open System.Runtime
open System.Runtime.InteropServices
open System.Runtime.CompilerServices
open System.Text.Json
open System.Text.Json.Serialization

open type Marshal
open type Office.Utilities.DllImports

module COMObjects =

    let GetRunningObjects () =
        match GetRunningObjectTable 0 with
        | null -> "GetRunningObjectTable failed to return a value." |> Exception |> raise
        | runningObjectTable ->
            match runningObjectTable.EnumRunning() with
            | null -> "Running Object Table did not return IEnumMoniker." |> Exception |> raise
            | monikerEnumerator ->
                monikerEnumerator.Reset()
                let result = Array.create 1 null

                seq {
                    while monikerEnumerator.Next(1, result, IntPtr.Zero) = 0 do
                        match runningObjectTable.GetObject result[0] with
                        | _, null -> ()
                        | _, object -> object
                }
