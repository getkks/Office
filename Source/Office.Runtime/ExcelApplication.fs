namespace Office.Runtime

open Microsoft.Office.Interop.Excel
open COMObjects

module ExcelApplication =

    let GetRunningExcelWorkBooks () =
        seq {
            for runningObject in GetRunningObjects() do
                match runningObject with
                | :? Workbook as workbook -> workbook
                | _ -> ()
        }
