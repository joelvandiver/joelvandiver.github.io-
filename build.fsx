#load @"packages/FSharp.Formatting/FSharp.Formatting.fsx"

open System.IO
open System.Text.RegularExpressions
open FSharp.Literate

let source = __SOURCE_DIRECTORY__
let template = Path.Combine(__SOURCE_DIRECTORY__, @"content/template.html")

// TODO:  Build markdown pages.
// TODO:  Separate links into sections by folders.
// TODO:  Fix VSCode F# Intellisense
// TODO:  Only build files that have changed after the template changed.

let getPosts (fileName: string) : string list =
   Directory.GetFiles(Path.Combine(source, "posts"), fileName, SearchOption.AllDirectories)
   |> List.ofSeq
   |> List.filter(fun f -> f.Contains("_archive") |> not)

let writeHome () =
   let convertToLink (path: string) : string = 
      let rel = 
         path
            .Replace(source, "")
            .Replace("\\index.fsx", "")
            .Replace("\\index.html", "")
      let dirs = 
         rel
            .Replace("\\posts\\", "")
            .Replace("\\", " - ")
            .Replace(" Fs", " F#")
      let clean = rel.Replace("\\", "/")
      sprintf "[%s](%s)" dirs clean

   let indexes = "index.*" |> getPosts |> List.map convertToLink

   let links = 
      indexes
      |> List.map(fun l -> "- " + l)
      |> List.sort
      |> List.distinct
      |> List.fold(fun a b -> a + "\r\n" + b) ""
   let home = Path.Combine(source, "index.md")
   let contents = File.ReadAllText(home)
   let pattern = "## Posts(.|\n)*"
   let replaced = 
      let text = sprintf "## Posts%s\r\n" links
      Regex.Replace(contents, pattern, text)
   File.WriteAllText(home, replaced)

   Literate.ProcessMarkdown(home, template)

"index.fsx" |> getPosts |> List.iter (fun script -> Literate.ProcessScriptFile(script, template))
writeHome()


